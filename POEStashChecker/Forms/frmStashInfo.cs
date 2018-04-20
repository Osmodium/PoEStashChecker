using System;
using System.ComponentModel;
using System.Dynamic;
using System.Net;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using POEStashChecker.Data;
using POEStashChecker.Stash;
using POEStashChecker.UserControls;

namespace POEStashChecker.Forms
{
    public partial class frmStashInfo : Form
    {
        private string m_Account;
        private string m_League;
        private int m_TabIndex;
        private string m_POESESSID;

        private string m_RawJson = null;
        private dynamic m_StashData = null;
        private Exception m_LoadException = null;

        private List<Item> m_Items = new List<Item>();

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
                    m_RawJson = StashService.GetStashData(m_Account, m_League, m_TabIndex, m_POESESSID);
                }
                catch (Exception ex)
                {
                    bg.ReportProgress(0, ex);
                }
            };
            bg.ProgressChanged += (sender, args) =>
            {
                m_LoadException = (Exception)args.UserState;
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

            flpItems.Controls.Clear();
            flpItems.Visible = true;

            TabInfo tabInfo = StashService.GetTabInfo(m_StashData, m_TabIndex);

            Text += $" / {tabInfo.Name}";

            foreach (dynamic item in m_StashData.items)
            {
                ProcessItemLine(item, tabInfo.Name);
            }

            ListItems();
        }

        private void ProcessItemLine(dynamic jsonItem, string tabName)
        {
            Item item = new Item(jsonItem, tabName, m_League);
            m_Items.Add(item);
        }

        private void ListItems()
        {
            foreach (Item item in m_Items.OrderByDescending(i=>i.Value.ChaosOrb))
            {
                flpItems.Controls.Add(new ItemUserControl(item));
            }
        }
    }
}
