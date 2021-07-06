using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManagerClient
{
         
    public partial class Client2 : Form
    {
        //형식 위치 크기 만든날짜 수정한 날짜 엑세스한 날짜
        public string fileName;
        public string format;
        public string path;
        public string size;

        public string createdDate;
        public string modifyDate;
        public string accessDate;
        public int index;
        public Client2(Dictionary<string,string> Info, int index)
        {
            fileName = Info["Name"]; path = Info["Path"]; format = Info["Format"]; size = Info["Size"];
            createdDate = Info["cDate"]; modifyDate = Info["mDate"]; accessDate = Info["aDate"];
            this.index = index;

            InitializeComponent();
        }
        public Client2()
        {
            InitializeComponent();
        }

        private void Client2_Load(object sender, EventArgs e)
        {
            txtFileName.Text = fileName;
            lblFormat.Text = format;
            lblPath.Text = path;
            lblSize.Text = size;

            lblCreate.Text = createdDate;
            lblModify.Text = modifyDate;
            lblAccess.Text = accessDate;
            picFIle.Image = (Image)imgList.Images[index];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
