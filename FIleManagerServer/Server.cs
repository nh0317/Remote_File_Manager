using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using PacketLibrary;

namespace FileManagerServer
{
    public partial class Server : Form
    {
        public NetworkStream networkStream;
        private int PORT;
        private IPAddress IP;

        public bool stopFlag = false;
        private TcpListener listener;
        private Thread thServer;

        private int bufferSize = 1024 * 4;
        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        FileInfo target;//다운로드할 파일 경로



        public bool connect = false;

        public Server()
        {
            InitializeComponent();
        }
        public void Message(string msg)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                txtLog.AppendText(msg + "\r\n");
                txtLog.Focus();
                txtLog.ScrollToCaret();
            }));
        }

        public void ServerStart()
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                IP = IPAddress.Parse(txtIP.Text);
                PORT = int.Parse(txtPort.Text);
            }));

            try
            {
                listener = new TcpListener(IP, PORT);
                listener.Start();

                stopFlag = true;
                Message("클라이언트 접속 대기중...");

                while (stopFlag)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    if (client.Connected)
                    {
                        connect = true;
                        Message("클라이언트 접속");
                        networkStream = client.GetStream();
                    }
                    while (connect)
                    {
                        try { this.networkStream.Read(readBuffer, 0, bufferSize); }
                        catch { connect = false; networkStream = null; }

                        Receive();
                    }
                }
            }

            //서버 종료
            catch(ThreadAbortException ex) { throw (ex); }
            
            catch (Exception ex)
            {
                MessageBox.Show("예기치 못한 오류 발생\r\n" 
                                + "서버와 클라이언트 접속을 종료합니다.\r\n" 
                                + ex.Message, "예외 오류", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                Message("클라이언트 접속 종료");
                Disconnect();
                ServerStop();
                return;
            }
        }

        public void ServerStop()
        {
            if (!stopFlag)
                return;
            stopFlag = false;
            connect = false;

            listener?.Stop();
            networkStream?.Close();
            thServer?.Abort();

            Message("서비스 종료");
            this.Invoke(new MethodInvoker(delegate ()
            {
                btnServer.Text = "서버켜기";
                btnServer.ForeColor = Color.Black;
            }));
        }
        public void Disconnect()
        {
            if (!connect)
                return;

            connect = false;
            networkStream?.Close();
        }
        private void Receive() {
            try
            {
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                switch ((int)packet.Type) {
                    case (int)PacketType.init:
                        Message("초기화 데이터 요청.."); SendInit(); break;

                    case (int)PacketType.beforeExpand:
                        Message("beforeExpand 데이터 요청.."); SendBeforeExpand(); break;

                    case (int)PacketType.beforeSelect:
                        Message("beforeSelect 데이터 요청.."); SendBeforeSelect(); break;

                    case (int)PacketType.fileDetail:
                        Message("상세정보 데이터 요청.."); SendFileDetails(); break;

                    case (int)PacketType.download: 
                        DownloadDataSize(); break;

                    case (int)PacketType.downloadData:
                        Download(); break;

                    case (int)PacketType.setPlus: 
                        SendSetPlus(); break;

                    case (int)PacketType.directoryInfo:
                        SendDirInfo(); break;

                    case (int)PacketType.fileInfo:
                        SendFileInfo(); break;

                    case (int)PacketType.exit:
                        Message("클라이언트 접속 종료"); Disconnect(); break;

                    default: break;
                }
            }
            catch (ArgumentException ex) {
                MessageBox.Show("전송하려는 데이터의 크기가 너무 큽니다.\r\n"
                                +"서버와 클라이언트 접속을 종료합니다\r\n" + ex.Message, 
                                "전송 데이터 크기 오류", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Message("클라이언트 접속 종료");
                Disconnect();
                ServerStop();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
                Message("클라이언트 접속 종료");
                Disconnect();
                ServerStop();
            }
        }
        void Send()
        {
            this.networkStream?.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.networkStream?.Flush();
            for (int i = 0; i < bufferSize; i++)
                this.sendBuffer[i] = 0;
        }

        //초기화 정보를 보낸다.
        //서버의 경로 전송 
        private void SendInit()
        {
            DirectoryInfo dir = new DirectoryInfo(txtPath.Text);
            int size = dir.GetDirectories().Length;
            
            Init init = new Init(txtPath.Text, size);
            Packet.Serialize(init).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //수신한 경로의 하위 디렉토리 수 전송 
        private void SendBeforeExpand()
        {
            BeforeExpand received = (BeforeExpand)Packet.Desserialize(this.readBuffer);
            DirectoryInfo dir = new DirectoryInfo(received.path);
            int size = dir.GetDirectories().Length;

            BeforeExpand be = new BeforeExpand(size);
            Packet.Serialize(be).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //수신한 경로의 하위 디렉토리 수 전송 
        private void SendSetPlus()
        {
            SetPlus received = (SetPlus)Packet.Desserialize(this.readBuffer);
            DirectoryInfo dir = new DirectoryInfo(received.path);
            int size = dir.GetDirectories().Length;

            SetPlus se = new SetPlus(size);
            Packet.Serialize(se).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //수신한 경로의 index번째 하위 디렉토리 정보 전송 
        private void SendDirInfo()
        {
            DirInfo recieved = (DirInfo)Packet.Desserialize(this.readBuffer);
            DirectoryInfo dir = new DirectoryInfo(recieved.path);
            DirectoryInfo di = dir.GetDirectories()[recieved.index];

            DirInfo dirInfo = new DirInfo(di);
            Packet.Serialize(dirInfo).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //수신한 경로의 index번째 하위 파일 정보 전송
        private void SendFileInfo()
        {
            FInfo recieved = (FInfo)Packet.Desserialize(this.readBuffer);
            DirectoryInfo dir = new DirectoryInfo(recieved.path);
            FileInfo fi = dir.GetFiles()[recieved.index];

            FInfo fileInfo = new FInfo(fi);
            Packet.Serialize(fileInfo).CopyTo(this.sendBuffer, 0);
            Send();
        }

        //수신한 경로의 하위 디렉토리 수와 파일 수를 전송 
        private void SendBeforeSelect()
        {
            BeforeSelect recieced = (BeforeSelect)Packet.Desserialize(this.readBuffer);

            DirectoryInfo dir = new DirectoryInfo(recieced.path);
            int dSize = dir.GetDirectories().Length;
            int fSize = dir.GetFiles().Length;

            BeforeSelect bs = new BeforeSelect(dSize, fSize);
            Packet.Serialize(bs).CopyTo(this.sendBuffer, 0);
            Send();
        }


        //수신한 파일의 상세정보 전송 
        private void SendFileDetails()
        {
            FileDetail recieved = (FileDetail)Packet.Desserialize(this.readBuffer);
            FileInfo fi = new FileInfo(recieved.path);

            FileDetail fileDetail = new FileDetail(fi);
            Packet.Serialize(fileDetail).CopyTo(this.sendBuffer, 0);
            Send();

        }

        //파일의 데이터 전송 
        private void DownloadDataSize()
        {
            Download receivedDo = (Download)Packet.Desserialize(this.readBuffer);

            //다운로드할 파일 
            target = new FileInfo(receivedDo.path);

            //우선 파일의 크기 전송 
            Download download = new Download(target.Length);
            Packet.Serialize(download).CopyTo(this.sendBuffer, 0);
            Send();

        }
        public void Download()
        {
            //파일 데이터 전송 
            FileStream fs = new FileStream(target.FullName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            DownloadData receivedDo = (DownloadData)Packet.Desserialize(this.readBuffer);
            byte[] buffer = new byte[receivedDo.buffer.Length];
            if (receivedDo.index == 0)
                br.Read(buffer, 0, buffer.Length);

            else
            {
                br.BaseStream.Seek((long)1024*(receivedDo.index), SeekOrigin.Begin);
                br.Read(buffer, 0, buffer.Length);
            }
            DownloadData download = new DownloadData(buffer, buffer.Length);
            Packet.Serialize(download).CopyTo(this.sendBuffer, 0);
            Send();

            br.Close();
            fs.Close();

            //마지막 데이터 전송시 로그 출력 
            if((receivedDo.index+1)*1024>=target.Length)
                Message(target.FullName + " 데이터 다운로드 완료...");

        }
        private void btnServer_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIP.Text) || String.IsNullOrEmpty(txtPort.Text)) {
                MessageBox.Show("IP와 PORT번호를 모두 입력하세요", "IP, PORT 입력 오류", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (String.IsNullOrEmpty(txtPath.Text)) {
                MessageBox.Show("경로를 선택해주세요", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnServer.Text == "서버켜기") {
                try {
                    thServer = new Thread(new ThreadStart(ServerStart));
                    thServer.Start();
                }
                catch {
                    MessageBox.Show("서버 연결 오류");
                    return;
                }
                this.Invoke(new MethodInvoker(delegate ()
                {
                    btnServer.Text = "서버끊기";
                    btnServer.ForeColor = Color.Red;
                }));
            }
            else
                ServerStop();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Message(fbd.SelectedPath+"로 경로가 수정되었습니다.");
                this.Invoke(new MethodInvoker(delegate ()
                {
                    txtPath.Text = fbd.SelectedPath;
                }));
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
        }
        private void Server_Load(object sender, EventArgs e)
        {

        }

    }
}
