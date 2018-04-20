using System;
using System.ComponentModel;
using System.Dynamic;
using System.Windows.Forms;
using Newtonsoft.Json;
using POEStashChecker.Data;
using POEStashChecker.Stash;
using POEStashChecker.Utility;

namespace POEStashChecker.Forms
{
    public partial class frmAllItems : Form
    {
        private string m_Account;
        private string m_League;
        private string m_POESESSID;
        private Exception m_LoadException;

        private SortableBindingList<DisplayItem> m_Items = new SortableBindingList<DisplayItem>();

        public frmAllItems()
        {
            InitializeComponent();
        }

        public frmAllItems(string account, string league, string poeSessId)
        {
            m_Account = account;
            m_League = league;
            m_POESESSID = poeSessId;
            InitializeComponent();
            Text = $"Stashes - {m_Account} / {m_League}";
        }

        private void frmAllItems_Load(object sender, EventArgs e)
        {
            ResizeProgressBar();
            GetStashes();
        }

        private void GetStashes()
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += (sender, args) =>
            {
                int progress = 0;
                try
                {
                    string rawData = StashService.GetStashData(m_Account, m_League, 0, m_POESESSID);

                    if (string.IsNullOrEmpty(rawData))
                        throw new Exception("Failed getting initial data!");
#if DEBUG
                    Console.WriteLine(rawData);
#endif
                    dynamic stashData = JsonConvert.DeserializeObject<ExpandoObject>(rawData);
                    TabInfo firstTabInfo = StashService.GetTabInfo(stashData, 0);

                    AddTabItems(stashData, firstTabInfo.Name);
                    progress = (int)Math.Ceiling((1 / (float)firstTabInfo.NumTabs) * 100);
                    bg.ReportProgress(progress);

                    for (int i = 1; i < firstTabInfo.NumTabs; ++i)
                    {
                        progress = GetTabItems(i);
                        bg.ReportProgress(progress);
                    }
                }
                catch (Exception ex)
                {
                    bg.ReportProgress(progress, ex);
                }
            };
            bg.ProgressChanged += (sender, args) =>
            {
                tsProgressBar.ProgressBar.Value = args.ProgressPercentage;
                m_LoadException = (Exception)args.UserState;
            };
            bg.RunWorkerCompleted += OnRunWorkerCompleted;
            bg.WorkerReportsProgress = true;
            bg.RunWorkerAsync();
        }

        private void OnRunWorkerCompleted(object o, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            if (m_LoadException != null)
            {
                MessageBox.Show(m_LoadException.Message + m_LoadException.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            tsProgressBar.Visible = false;
            tsStatusLabel.Text = "Done!";
            BindingSource source = new BindingSource(m_Items, null);
            dgvItems.DataSource = source;
        }

        private int GetTabItems(int i)
        {
            string rawTabData = StashService.GetStashData(m_Account, m_League, i, m_POESESSID);

            if (string.IsNullOrEmpty(rawTabData))
                throw new Exception($"Failed getting tab data with id {i}!");
#if DEBUG
            Console.WriteLine(rawTabData);
#endif
            dynamic tabData = JsonConvert.DeserializeObject<ExpandoObject>(rawTabData);
            TabInfo tabInfo = StashService.GetTabInfo(tabData, i);
            AddTabItems(tabData, tabInfo.Name);
            return (int)Math.Ceiling(i / (float)tabInfo.NumTabs * 100);
        }

        private void AddTabItems(dynamic stashData, string tabName)
        {
            foreach (dynamic jsonItem in stashData.items)
            {
                DisplayItem item = new DisplayItem();
                item.SetData(jsonItem, tabName, m_League);
                m_Items.Add(item);
            }
        }
        
        private void frmAllItems_Resize(object sender, EventArgs e)
        {
            ResizeProgressBar();
        }

        private void ResizeProgressBar()
        {
            if (tsProgressBar.Visible)
                tsProgressBar.Size = new System.Drawing.Size(statusStrip.Width - tsStatusLabel.Width - statusStrip.ImageScalingSize.Width, tsProgressBar.Height);
        }
    }
}
