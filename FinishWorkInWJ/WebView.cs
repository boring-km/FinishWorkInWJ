using System;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace FinishWorkInWJ
{
    public partial class WebView : Form
    {
        private ChromiumWebBrowser chrome;


        public WebView()
        {
            InitializeComponent();
            InitializeChromeBrowser();
        }

        private void WebView_Load(object sender, EventArgs e)
        {

        }

        private void InitializeChromeBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            chrome = new ChromiumWebBrowser("https://portal.wjtb.net/loginForm.do");
            chrome.Dock = DockStyle.Fill;
            this.Controls.Add(chrome);
        }

        public void inputValue(string id, string pw)
        {
            chrome.ExecuteScriptAsyncWhenPageLoaded("$('input[name=j_username]').focusin();");
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('j_username').value = '" + id + "';");
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('password').value = '" + pw + "';");
        }

        public void login()
        {
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('btnSubmit').click();");
        }

        public void clickFinishWork()
        {
            chrome.Load("https://portal.wjtb.net/portal/popup/P0009/p0009.do?popupFormId=p0009f23&condition=Y^1&targetType=N");
        }

        public void clickYes()
        {
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementsByTagName('a')[0].click();");
        }

        public void setTomorrowStartTime(string time)
        {
            string hour = time.Substring(0, 2);
            string minute = time.Substring(2, 2);
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('input2').value='" + hour + "';");
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('input3').value='" + minute + "';");
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementsByName('check2')[1].checked = true;");
        }

        public void clickSaveButton()
        {
            // TODO 저장버튼 클릭
        }

    }
}
