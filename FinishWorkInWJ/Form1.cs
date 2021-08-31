using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SHDocVw;

namespace FinishWorkInWJ
{
    public partial class Form1 : Form
    {
        string id = "";
        string pw = "";
        string time = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(@"c:/attend_auto/data.txt", System.Text.Encoding.GetEncoding("utf-8"), true);
                id = reader.ReadLine();
                pw = reader.ReadLine();
                time = reader.ReadLine();
                textBox1.Text = id;
                textBox2.Text = pw;
                textBox3.Text = time;
                // button2.PerformClick();
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
            string inputTime = textBox3.Text;

            string folderPath = "C:/attend_auto";
            DirectoryInfo di = new DirectoryInfo(folderPath);
            if (di.Exists == false)
            {
                di.Create();
            }
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(@"c:/attend_auto/data.txt", true, System.Text.Encoding.GetEncoding("utf-8"));
                writer.Flush();
                writer.WriteLine(inputId);
                writer.WriteLine(inputPw);
                writer.WriteLine(inputTime);
                label2.Text = "C:/attend_auto/data.txt 에 저장됨(시간수정도 가능)";
                id = inputId;
                pw = inputPw;
                time = inputTime;
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
            WebView web = new WebView();
            web.Show();
            web.inputValue(id, pw);
            web.login();
            Delayed(2000, () => web.clickFinishWork());

        }

        public void Delayed(int delay, Action action)
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = delay;
            timer.Tick += (s, e) => {
                action();
                timer.Stop();
            };
            timer.Start();
        }

        // 창 닫기
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
