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
            // From창에 ChrominumWebCrowser 가득 채우기
            this.Controls.Add(chrome);
        }

        public void inputValue(string id, string pw)
        {
            chrome.ExecuteScriptAsyncWhenPageLoaded("$('input[name=j_username]').focusin();");
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('j_username').value = '" + id + "';");
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('password').value = '" + pw + "';");
        }

        public void execute()
        {
            chrome.ExecuteScriptAsyncWhenPageLoaded("document.getElementById('btnSubmit').click();");
        }

    }
}
