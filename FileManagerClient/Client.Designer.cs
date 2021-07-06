
namespace FileManagerClient
{
    partial class Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.상세정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.다운로드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.자세히ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.간단히ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작은아이콘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.큰아이콘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.trvDir = new System.Windows.Forms.TreeView();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnPath);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-6, -23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 177);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(650, 128);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(136, 34);
            this.btnOpen.TabIndex = 12;
            this.btnOpen.Text = "폴더열기";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(393, 128);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(136, 34);
            this.btnPath.TabIndex = 13;
            this.btnPath.Text = "경로설정";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(131, 128);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(136, 34);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "서버연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(697, 35);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(148, 28);
            this.txtPort.TabIndex = 9;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(170, 79);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(675, 28);
            this.txtPath.TabIndex = 10;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(64, 35);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(528, 28);
            this.txtIP.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "다운로드 경로: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(626, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "PORT: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvwFiles);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.trvDir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 622);
            this.panel2.TabIndex = 16;
            // 
            // lvwFiles
            // 
            this.lvwFiles.ContextMenuStrip = this.cms;
            this.lvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFiles.HideSelection = false;
            this.lvwFiles.LargeImageList = this.imgList;
            this.lvwFiles.Location = new System.Drawing.Point(202, 0);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(676, 622);
            this.lvwFiles.SmallImageList = this.imgList;
            this.lvwFiles.TabIndex = 2;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.DoubleClick += new System.EventHandler(this.lvwFiles_DoubleClick);
            // 
            // cms
            // 
            this.cms.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.상세정보ToolStripMenuItem,
            this.다운로드ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.자세히ToolStripMenuItem,
            this.간단히ToolStripMenuItem,
            this.작은아이콘ToolStripMenuItem,
            this.큰아이콘ToolStripMenuItem});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(175, 202);
            // 
            // 상세정보ToolStripMenuItem
            // 
            this.상세정보ToolStripMenuItem.Name = "상세정보ToolStripMenuItem";
            this.상세정보ToolStripMenuItem.Size = new System.Drawing.Size(174, 32);
            this.상세정보ToolStripMenuItem.Text = "상세정보";
            this.상세정보ToolStripMenuItem.Click += new System.EventHandler(this.상세정보ToolStripMenuItem_Click);
            // 
            // 다운로드ToolStripMenuItem
            // 
            this.다운로드ToolStripMenuItem.Name = "다운로드ToolStripMenuItem";
            this.다운로드ToolStripMenuItem.Size = new System.Drawing.Size(174, 32);
            this.다운로드ToolStripMenuItem.Text = "다운로드";
            this.다운로드ToolStripMenuItem.Click += new System.EventHandler(this.다운로드ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(171, 6);
            // 
            // 자세히ToolStripMenuItem
            // 
            this.자세히ToolStripMenuItem.Name = "자세히ToolStripMenuItem";
            this.자세히ToolStripMenuItem.Size = new System.Drawing.Size(174, 32);
            this.자세히ToolStripMenuItem.Text = "자세히";
            this.자세히ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // 간단히ToolStripMenuItem
            // 
            this.간단히ToolStripMenuItem.Name = "간단히ToolStripMenuItem";
            this.간단히ToolStripMenuItem.Size = new System.Drawing.Size(174, 32);
            this.간단히ToolStripMenuItem.Text = "간단히";
            this.간단히ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // 작은아이콘ToolStripMenuItem
            // 
            this.작은아이콘ToolStripMenuItem.Name = "작은아이콘ToolStripMenuItem";
            this.작은아이콘ToolStripMenuItem.Size = new System.Drawing.Size(174, 32);
            this.작은아이콘ToolStripMenuItem.Text = "작은아이콘";
            this.작은아이콘ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // 큰아이콘ToolStripMenuItem
            // 
            this.큰아이콘ToolStripMenuItem.Name = "큰아이콘ToolStripMenuItem";
            this.큰아이콘ToolStripMenuItem.Size = new System.Drawing.Size(174, 32);
            this.큰아이콘ToolStripMenuItem.Text = "큰아이콘";
            this.큰아이콘ToolStripMenuItem.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "folder.png");
            this.imgList.Images.SetKeyName(1, "image.png");
            this.imgList.Images.SetKeyName(2, "music.png");
            this.imgList.Images.SetKeyName(3, "text.png");
            this.imgList.Images.SetKeyName(4, "avi.png");
            this.imgList.Images.SetKeyName(5, "temp.png");
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(199, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 622);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // trvDir
            // 
            this.trvDir.ContextMenuStrip = this.cms;
            this.trvDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvDir.ImageIndex = 0;
            this.trvDir.ImageList = this.imgList;
            this.trvDir.Location = new System.Drawing.Point(0, 0);
            this.trvDir.Name = "trvDir";
            this.trvDir.SelectedImageIndex = 0;
            this.trvDir.Size = new System.Drawing.Size(199, 622);
            this.trvDir.TabIndex = 0;
            this.trvDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeExpand);
            this.trvDir.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeSelect);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 804);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Name = "Client";
            this.Text = "FIleManager - Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView trvDir;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripMenuItem 상세정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 다운로드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 자세히ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 간단히ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작은아이콘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 큰아이콘ToolStripMenuItem;
    }
}

