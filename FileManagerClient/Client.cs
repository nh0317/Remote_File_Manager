using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Diagnostics;
using PacketLibrary;


namespace FileManagerClient
{
    public partial class Client : Form
    {
        public NetworkStream networkStream;
        private int PORT;
        private IPAddress IP;

        public bool stopFlag = false;
        public bool connect = false;
        TcpClient client;

        private int bufferSize = 1024 * 4;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        public Client()
        {
            InitializeComponent();

        }
        public void Connect()
        {
            client = new TcpClient();
            try { client.Connect(IP, PORT); }
            catch
            {
                MessageBox.Show("서버접속 오류");
                connect = false;
                return;
            }
            connect = true;
            networkStream = client.GetStream();
            try { InitData(); }
            catch
            {
                MessageBox.Show("초기화 오류");
                Disconnect();
            }
        }
        public void Disconnect()
        {
            if (!connect)
                return;

            connect = false;

            //서버에 클라이언트 접속 종료를 알림
            SendExit();

            client?.Close();
            networkStream?.Close();

            trvDir.Nodes.Clear();
            lvwFiles.Items.Clear();

            btnConnect.Text = "서버연결";
            btnConnect.ForeColor = Color.Black;
        }
        
        //treeView와 ListView를 초기화한다. 
        void InitData()
        {
            trvDir.Nodes.Clear();
            lvwFiles.Items.Clear();

            //서버에 초기화 데이터를 요청한다. 
            RequestInitialData();

            //초기화 데이터를 수신한다. 
            this.networkStream.Read(readBuffer, 0, bufferSize);
            Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
            if ((int)packet.Type == (int)PacketType.init)
            {
                Init initData = (Init)Packet.Desserialize(this.readBuffer);

                //서버의 경로를 root로 설정한다. 
                TreeNode root;
                root = trvDir.Nodes.Add(initData.path);
                root.ImageIndex = 0;
                if(trvDir.SelectedNode==null)
                    trvDir.SelectedNode = root;
                root.SelectedImageIndex = root.ImageIndex;

                if(initData.size>0)
                    root.Nodes.Add("");
            }

            //자세히 보기를 위한 열 추가 
            lvwFiles.Columns.Add("파일이름", 150, HorizontalAlignment.Left);
            lvwFiles.Columns.Add("파일크기", 150, HorizontalAlignment.Left);
            lvwFiles.Columns.Add("수정한날짜", 150, HorizontalAlignment.Left);
        }

        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            try
            {
                e.Node.Nodes.Clear();
                string path = e.Node.FullPath;
                TreeNode node;
                DirectoryInfo dir; 

                //BeforeExpand에 대한 데이터를 요청하고 받아온다. 
                RequestBeforeExpand(path);

                this.networkStream.Read(readBuffer, 0, bufferSize);
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                if ((int)packet.Type == (int)PacketType.beforeExpand)
                {
                    BeforeExpand beforeExpand = (BeforeExpand)Packet.Desserialize(this.readBuffer);
                    int index = beforeExpand.size;

                    //현재 폴더의 하위 디렉토리 수만큼 반복한다. 
                    for(int i=0; i<index;i++)
                    {
                        //하위 디렉토리의 정보를 요청하고, 그 데이터를 node에 추가한다. 
                        RequestDirInfo(i, path);
                        this.networkStream.Read(readBuffer, 0, bufferSize);
                        packet = (Packet)Packet.Desserialize(this.readBuffer);

                        if ((int)packet.Type == (int)PacketType.directoryInfo)
                        {
                            DirInfo dirInfo = (DirInfo)Packet.Desserialize(this.readBuffer);
                            dir = dirInfo.di;
                            node = e.Node.Nodes.Add(dir.Name);

                            SetPlus(node);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"\r\n연결을 종료함");
                Disconnect();
            }
        }

        public void SetPlus(TreeNode node)
        {
            string path;
            try
            {
                path = node.FullPath;

                //하위 디렉토리의 수를 요청하고 수신한다. 
                RequestSetPlus(path);
                this.networkStream.Read(readBuffer, 0, bufferSize);
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                if ((int)packet.Type == (int)PacketType.setPlus)
                {
                    SetPlus sp = (SetPlus)Packet.Desserialize(this.readBuffer);
                    //하위 디렉토리가 있으면 +설정
                    if (sp.size > 0)
                        node.Nodes.Add("");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Disconnect();
            }
        }
        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            ListViewItem item;
            lvwFiles.Items.Clear();

            try
            {
                //하위 디렉토리와 하위 파일의 수를 요청하고 수신함
                requestBeforeSelected(e.Node.FullPath);

                this.networkStream.Read(readBuffer, 0, bufferSize);
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                
                if ((int)packet.Type == (int)PacketType.beforeSelect)
                {
                    BeforeSelect bs = (BeforeSelect)Packet.Desserialize(this.readBuffer);
                    //하위 디렉토리의 수만큼 반복함
                    for(int i =0; i < bs.dSize; i++)
                    {
                        RequestDirInfo(i, e.Node.FullPath);
                        this.networkStream.Read(readBuffer, 0, bufferSize);
                        packet = (Packet)Packet.Desserialize(this.readBuffer);

                        //하위 디렉토리를 listView에 추가함
                        if ((int)packet.Type == (int)PacketType.directoryInfo)
                        {
                            DirInfo dirInfo = (DirInfo)Packet.Desserialize(this.readBuffer);
                            DirectoryInfo dir = dirInfo.di;
                            item = lvwFiles.Items.Add(dir.Name); 
                            item.ImageIndex = 0;
                            item.SubItems.Add("");
                            item.SubItems.Add(dir.LastWriteTime.ToString());
                            item.Tag = "D";
                            item.Name = dir.FullName;
                        }
                    }

                    //하위 파일 수만큼 반복
                    for (int i = 0; i < bs.fSize; i++)
                    {
                        RequestFileInfo(i, e.Node.FullPath);
                        this.networkStream.Read(readBuffer, 0, bufferSize);
                        packet = (Packet)Packet.Desserialize(this.readBuffer);
                        
                        //폴더의 파일을 종류에 따라 listView에 추가
                        if ((int)packet.Type == (int)PacketType.fileInfo)
                        {
                            FInfo fileInfo = (FInfo)Packet.Desserialize(this.readBuffer);
                            FileInfo fis = fileInfo.fi;
                            item = lvwFiles.Items.Add(fis.Name);
                            item.SubItems.Add(fis.Length.ToString());//크기
                            item.SubItems.Add(fis.LastWriteTime.ToString()); // 수정한 날짜
                            item.Name = fis.FullName; //파일의 경로
                            item.Tag = "F";

                            //이미지 파일 
                            if (fis.Extension.Equals(".jpg") || fis.Extension.Equals(".jpeg") 
                                || fis.Extension.Equals(".png") || fis.Extension.Equals(".gif") 
                                || fis.Extension.Equals(".bmp"))
                                item.ImageIndex = 1;
                            
                            //음악 파일 
                            else if (fis.Extension.Equals(".mp3") || fis.Extension.Equals(".wav") 
                                || fis.Extension.Equals(".flac") || fis.Extension.Equals(".aac"))
                                item.ImageIndex = 2;

                            //텍스트 파일 
                            else if (fis.Extension.Equals(".txt"))
                                item.ImageIndex = 3;

                            //비디오 파일 
                            else if (fis.Extension.Equals(".mvk") || fis.Extension.Equals(".wmv") 
                                || fis.Extension.Equals(".mp4") || fis.Extension.Equals(".m4p") 
                                || fis.Extension.Equals(".mpg") || fis.Extension.Equals(".mpeg"))
                                item.ImageIndex = 4;

                            //기타 파일 
                            else
                                item.ImageIndex = 5;
                        }
                    }
                    lvwFiles.EndUpdate();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n연결을 종료함");
                Disconnect();
            }
        }

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;

            foreach (ListViewItem item in siList)
                OpenItem(item);
        }

        public void OpenItem(ListViewItem item)
        {
            TreeNode node;
            TreeNode child;
            
            //폴더면 폴더의 파일들을 listView에 표시
            if (item.Tag.ToString() == "D")
            {
                node = trvDir.SelectedNode;
                node.Expand();

                child = node.FirstNode;

                while (child != null)
                {
                    if (child.Text == item.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            //파일이면 상세정보 표시
            else Details();
        }

        //상세정보 
        public void Details()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;

            foreach (ListViewItem item in siList)
            {
                Dictionary<string, string> Info = new Dictionary<string, string>();
                //파일 이름, 경로, 이미지 설정 
                Info.Add("Name",item.Text);
                Info.Add("Path",item.Name);
                int index = item.ImageIndex;

                //파일인 경우 
                if (!item.Tag.ToString().Equals("D"))
                {
                    //파일의 상세 정보를 서버에서 받아온다. 
                    RequestFileDetail(item.Name);
                    this.networkStream.Read(readBuffer, 0, bufferSize);
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                    if ((int)packet.Type == (int)PacketType.fileDetail)
                    {
                        FileDetail fileDetail = (FileDetail)Packet.Desserialize(this.readBuffer);
                        FileInfo fi = fileDetail.fi;
                        Info.Add("Format",fi.Extension.Replace(".", ""));
                        Info.Add("Size",fi.Length + " 바이트");
                        Info.Add("cDate",fi.CreationTime.ToString());
                        Info.Add("mDate",fi.LastWriteTime.ToString());
                        Info.Add("aDate", fi.LastAccessTime.ToString());
                    }
                }
                else
                {
                    //폴더인 경우 
                    MessageBox.Show("폴더는 상세보기를 지원하지 않습니다",
                                    "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //상세정보 폼을 생성한다. 
                Client2 detailView = new Client2(Info, index);
                detailView.Owner = this;
                detailView.Show();
            }
        }
        //파일 다운로드 함수 
        public void Download()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = lvwFiles.SelectedItems;

            foreach (ListViewItem item in siList)
            {
                string path = item.Name;

                //폴더인 경우 
                if (item.Tag.ToString().Equals("D"))
                {
                    MessageBox.Show("폴더는 다운로드를 지원하지 않습니다", 
                                    "Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //파일인 경우 
                else
                {
                    string Fullpath = Path.Combine(txtPath.Text, item.Text);
                    long fileSize = 0;
                        
                    //다운로드할 파일을 서버에 알려줌 
                    RequestDownload(path);
                        
                    //다운로드할 파일의 크기를 받아옴
                    this.networkStream.Read(readBuffer, 0, bufferSize);
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                        
                    if ((int)packet.Type == (int)PacketType.download)
                    {
                        Download download = (Download)Packet.Desserialize(this.readBuffer);
                        fileSize = download.size; 
                    }

                    //경로에 파일 생성 
                    FileStream fs = new FileStream(Fullpath, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);
                    byte[] bytes = new byte[1024];
                        
                    //파일 쓰기 시작
                    long cnt = (long)(fileSize / 1024);
                    for(long i = 0; i < cnt; i++)
                    {
                        RequestDonwloadData(i, 1024);
                        this.networkStream.Read(readBuffer, 0, bufferSize);
                        packet = (Packet)Packet.Desserialize(this.readBuffer);

                        if ((int)packet.Type == (int)PacketType.downloadData)
                        {
                            DownloadData download = (DownloadData)Packet.Desserialize(this.readBuffer);
                            Array.Copy(download.buffer, bytes, download.buffer.Length);
                            bw.Write(bytes, 0, bytes.Length);
                        }

                    }

                    //마지막 버퍼 
                    int lastBufferSize= (int)(fileSize - (cnt * 1024));
                    byte[] lastBuffer = new byte[lastBufferSize];

                    RequestDonwloadData(cnt, lastBufferSize);
                    this.networkStream.Read(readBuffer, 0, bufferSize);
                    packet = (Packet)Packet.Desserialize(this.readBuffer);

                    if ((int)packet.Type == (int)PacketType.downloadData)
                    {
                        DownloadData download = (DownloadData)Packet.Desserialize(this.readBuffer);
                        Array.Copy(download.buffer, lastBuffer, download.buffer.Length);
                        bw.Write(lastBuffer, 0, lastBufferSize);
                    }

                    bw.Close();
                    fs.Close();
                }
            }
        }

        //데이터 요청 함수 

        //초기화 데이터 요청 
        void RequestInitialData()
        {
            Init init = new Init();
            Packet.Serialize(init).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //beforeExpand 데이터 요청 
        //하위 디렉토리 수 요청 
        private void RequestBeforeExpand(string path)
        {
            BeforeExpand be = new BeforeExpand(path);
            Packet.Serialize(be).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //BeforeSelected 데이터 요청 
        //하위 디렉토리와 파일 수 요청 
        private void requestBeforeSelected(string path)
        {
            BeforeSelect bs = new BeforeSelect(path);
            Packet.Serialize(bs).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //파일의 상세정보 요청 
        public void RequestFileDetail(string path)
        {
            FileDetail detail = new FileDetail(path);
            Packet.Serialize(detail).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //파일 다운로드 요청 
        public void RequestDownload(string path)
        {
            Download download = new Download(path);
            Packet.Serialize(download).CopyTo(this.sendBuffer, 0);
            Send();
        }
        //파일의 index번째 데이터를 bufferSize만큼 읽을 것을 요청
        public void RequestDonwloadData(long index, int bufferSize)
        {
            DownloadData downloadData = new DownloadData(index, bufferSize);
            Packet.Serialize(downloadData).CopyTo(this.sendBuffer, 0);
            Send();
        }
        //setPlus 데이터 요청 
        //하위 디렉토리 수 요청 
        private void RequestSetPlus(string path)
        {
            SetPlus se = new SetPlus(path);
            Packet.Serialize(se).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //경로의 i번째 하위 디렉토리 정보를 요청 
        private void RequestDirInfo(int index, string path)
        {
            DirInfo dirInfo = new DirInfo(path, index);
            Packet.Serialize(dirInfo).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //경로의 i번째 파일 정보 요청 
        private void RequestFileInfo(int index, string path)
        {
            FInfo fileInfo = new FInfo(path, index);
            Packet.Serialize(fileInfo).CopyTo(this.sendBuffer, 0);
            Send();
        }
        //서버에 접속종료 알림  
        void SendExit()
        {
            Exit exit = new Exit();
            Packet.Serialize(exit).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //stream에 쓰고 초기화하는 함수 
        void Send()
        {
            this.networkStream?.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.networkStream?.Flush();
            for (int i = 0; i < bufferSize; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIP.Text) || String.IsNullOrEmpty(txtPort.Text))
            {
                MessageBox.Show("IP와 PORT번호를 모두 입력하세요", "IP, PORT 입력 오류", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (String.IsNullOrEmpty(txtPath.Text))
            {
                MessageBox.Show("경로를 선택해주세요", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IP = IPAddress.Parse(txtIP.Text);
            PORT = int.Parse(txtPort.Text);

            if (btnConnect.Text == "서버연결")
            {
                Connect();
                if (connect)
                {
                    btnConnect.Text = "서버끊기";
                    btnConnect.ForeColor = Color.Red;
                }
            }
            else Disconnect();
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }

        private void 상세정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {  Details(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n연결을 종료함");
                Disconnect();
            }
        }

        private void 다운로드ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { Download(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n연결을 종료함");
                Disconnect();
            }
        }
        private void mnuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            자세히ToolStripMenuItem.Checked = false;
            간단히ToolStripMenuItem.Checked = false;
            작은아이콘ToolStripMenuItem.Checked = false;
            큰아이콘ToolStripMenuItem.Checked = false;

            switch (item.Text)
            {
                case "자세히":
                    자세히ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.Details;
                    break;

                case "간단히":
                    간단히ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.List;
                    break;

                case "작은아이콘":
                    작은아이콘ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;

                case "큰아이콘":
                    큰아이콘ToolStripMenuItem.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
            }
        }

        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void Client_Load(object sender, EventArgs e)
        {
        }
    }

}
