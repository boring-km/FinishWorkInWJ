using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Interop.mshtml;
using SHDocVw;

namespace FinishWorkInWJ
{
    public partial class Form1 : Form
    {
        string id = "";
        string pw = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@"c:/attend_auto/idpw.txt", System.Text.Encoding.GetEncoding("utf-8"), true);
                id = reader.ReadLine();
                pw = reader.ReadLine();
                textBox1.Text = id;
                textBox2.Text = pw;
                button2.PerformClick();
            }
            catch
            {
                label1.Text = "저장된 아이디 비밀번호 없음";
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputId = textBox1.Text;
            string inputPw = textBox2.Text;

            string folderPath = "C:/attend_auto";
            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (di.Exists == false)
            {
                di.Create();
            }
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(@"c:/attend_auto/idpw.txt", true, System.Text.Encoding.GetEncoding("utf-8"));
                writer.WriteLine(inputId);
                writer.WriteLine(inputPw);
                label2.Text = "C:/attend_auto/idpw.txt 에 저장됨";
                id = inputId;
                pw = inputPw;
            }
            catch
            {
                label1.Text = "파일 저장 에러";
            }
            finally
            {
                writer.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id == "" || pw == "")
            {
                return;
            }
            label1.Text = "인터넷 여는 중...";

            var ie = new InternetExplorer();
            var webBrowser = (IWebBrowserApp)ie;
            webBrowser.Visible = true;
            webBrowser.Navigate("http://portal.wjtb.net/");
            this.Close();
            Thread.Sleep(3000);
            webBrowser.Quit();
        }

        // 창 닫기
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
