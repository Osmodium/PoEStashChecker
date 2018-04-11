using System;
using System.ComponentModel;
using System.Dynamic;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace POEStashChecker
{
    public partial class frmStashInfo : Form
    {
        private const string ENDPOINT = "https://pathofexile.com/character-window/get-stash-items?league={0}&tabs={1}&tabIndex={2}&accountName={3}";

        private string m_Account;
        private string m_League;
        private int m_TabIndex;
        private string m_POESESSID;

        private string m_RawJson = null;
        private dynamic m_StashData = null;
        private Exception m_LoadException = null;

        private string MergedEndPoint
        {
            get
            {
                return string.Format(ENDPOINT, m_League, 1, m_TabIndex, m_Account);
            }
        }

        private frmStashInfo()
        {
            InitializeComponent();
        }

        public frmStashInfo(string account, string league, int tabIndex, string poeSessId)
        {
            m_Account = account;
            m_League = league;
            m_TabIndex = tabIndex;
            m_POESESSID = poeSessId;
            InitializeComponent();
            Text = $"Stash Info - {m_Account} / {m_League}";
        }

        private void frmStashInfo_Load(object sender, EventArgs e)
        {
            GetStash();
        }

        private void GetStash()
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += (sender, args) =>
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Add(HttpRequestHeader.Referer, "https://www.pathofexile.com");
                        wc.Headers.Add(HttpRequestHeader.Cookie, $"POESESSID={m_POESESSID}");
                        m_RawJson = wc.DownloadString(MergedEndPoint);
                    }
                }
                catch (Exception ex)
                {
                    bg.ReportProgress(0, ex);
                }
            };
            bg.ProgressChanged += (sender, args) =>
            {
                m_LoadException = (Exception) args.UserState;
            };
            bg.RunWorkerCompleted += OnRunWorkerCompleted;
            bg.WorkerReportsProgress = true;
            bg.RunWorkerAsync();
        }

        private void OnRunWorkerCompleted(object o, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            pbLoader.Visible = false;
            if (string.IsNullOrEmpty(m_RawJson))
            {
                toolStripStatusLabel.Text = "Failed getting data!" + m_LoadException.Message;
                return;

            }
#if DEBUG
            Console.WriteLine(m_RawJson);
#endif
            m_StashData = JsonConvert.DeserializeObject<ExpandoObject>(m_RawJson);

            lbStash.Items.Clear();
            lbStash.Visible = true;

            foreach (dynamic tab in m_StashData.tabs)
            {
                if (tab.i == m_TabIndex)
                {
                    Text += $" / {tab.n}";
                }
            }

            foreach (dynamic item in m_StashData.items)
            {
                ProcessItemLine(item);
            }
        }

        private void ProcessItemLine(dynamic jsonItem)
        {
            Item item = new Item(jsonItem, m_League);
            lbStash.Items.Add(item);
        }
        
    }
}
