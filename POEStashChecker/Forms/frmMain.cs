using System;
using System.Windows.Forms;

namespace POEStashChecker.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            cbLeague.SelectedIndex = 0;
        }

        private void btnCheckTab_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccount.Text) ||
                string.IsNullOrEmpty(txtPOESESSID.Text) ||
                string.IsNullOrEmpty(txtTabIndex.Text) || 
                !int.TryParse(txtTabIndex.Text, out int tabIndex))
            {
                MessageBox.Show("Please provide all neccessary data...", "Insufficient data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmStashInfo stashInfo = new frmStashInfo(txtAccount.Text, (string)cbLeague.SelectedItem, tabIndex, txtPOESESSID.Text);
            stashInfo.Show();
        }

        private void btnCheckAllTabs_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccount.Text) ||
                string.IsNullOrEmpty(txtPOESESSID.Text))
            {
                MessageBox.Show("Please provide all neccessary data...", "Insufficient data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAllItems allItemsInfo = new frmAllItems(txtAccount.Text, (string)cbLeague.SelectedItem, txtPOESESSID.Text);
            allItemsInfo.Show();
        }
    }
}
