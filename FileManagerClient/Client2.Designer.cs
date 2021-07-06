
namespace FileManagerClient
{
    partial class Client2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client2));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.divider1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.picFIle = new System.Windows.Forms.PictureBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblModify = new System.Windows.Forms.Label();
            this.lblAccess = new System.Windows.Forms.Label();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picFIle)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 726);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 45);
            this.button1.TabIndex = 11;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(29, 463);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(734, 2);
            this.label1.TabIndex = 9;
            // 
            // divider1
            // 
            this.divider1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.divider1.Location = new System.Drawing.Point(29, 215);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(734, 2);
            this.divider1.TabIndex = 8;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(278, 87);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(507, 28);
            this.txtFileName.TabIndex = 7;
            // 
            // picFIle
            // 
            this.picFIle.Location = new System.Drawing.Point(29, 12);
            this.picFIle.Name = "picFIle";
            this.picFIle.Size = new System.Drawing.Size(169, 187);
            this.picFIle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFIle.TabIndex = 6;
            this.picFIle.TabStop = false;
            // 
            // lblPath
            // 
            this.lblPath.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPath.Location = new System.Drawing.Point(274, 301);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(511, 87);
            this.lblPath.TabIndex = 12;
            this.lblPath.Text = "label2";
            // 
            // lblSize
            // 
            this.lblSize.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSize.Location = new System.Drawing.Point(274, 396);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(511, 63);
            this.lblSize.TabIndex = 12;
            this.lblSize.Text = "label2";
            // 
            // lblCreate
            // 
            this.lblCreate.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCreate.Location = new System.Drawing.Point(274, 490);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(511, 62);
            this.lblCreate.TabIndex = 12;
            this.lblCreate.Text = "label2";
            // 
            // lblModify
            // 
            this.lblModify.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblModify.Location = new System.Drawing.Point(274, 565);
            this.lblModify.Name = "lblModify";
            this.lblModify.Size = new System.Drawing.Size(511, 58);
            this.lblModify.TabIndex = 12;
            this.lblModify.Text = "label2";
            // 
            // lblAccess
            // 
            this.lblAccess.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAccess.Location = new System.Drawing.Point(274, 639);
            this.lblAccess.Name = "lblAccess";
            this.lblAccess.Size = new System.Drawing.Size(511, 61);
            this.lblAccess.TabIndex = 12;
            this.lblAccess.Text = "label2";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(28, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 13;
            this.label2.Text = "파일 형식: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(28, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "위치: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(29, 396);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "크기:  ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(28, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "만든 날짜: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(29, 565);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 22);
            this.label7.TabIndex = 13;
            this.label7.Text = "수정한 날짜: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(29, 639);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 22);
            this.label8.TabIndex = 13;
            this.label8.Text = "엑세스한 날짜: ";
            // 
            // lblFormat
            // 
            this.lblFormat.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFormat.Location = new System.Drawing.Point(274, 233);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(511, 57);
            this.lblFormat.TabIndex = 12;
            this.lblFormat.Text = "label2";
            // 
            // Client2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 790);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAccess);
            this.Controls.Add(this.lblModify);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.picFIle);
            this.Name = "Client2";
            this.Text = "상세보기";
            this.Load += new System.EventHandler(this.Client2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFIle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label divider1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.PictureBox picFIle;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblModify;
        private System.Windows.Forms.Label lblAccess;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblFormat;
    }
}