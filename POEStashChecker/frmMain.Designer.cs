namespace POEStashChecker
{
    partial class frmMain
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnCheckTab = new System.Windows.Forms.Button();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.txtTabIndex = new System.Windows.Forms.TextBox();
            this.lblTabs = new System.Windows.Forms.Label();
            this.cbLeague = new System.Windows.Forms.ComboBox();
            this.lblLeague = new System.Windows.Forms.Label();
            this.txtPOESESSID = new System.Windows.Forms.TextBox();
            this.lblPOSESSID = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtPOESESSID);
            this.pnlMain.Controls.Add(this.lblPOSESSID);
            this.pnlMain.Controls.Add(this.btnCheckTab);
            this.pnlMain.Controls.Add(this.txtAccount);
            this.pnlMain.Controls.Add(this.lblAccount);
            this.pnlMain.Controls.Add(this.txtTabIndex);
            this.pnlMain.Controls.Add(this.lblTabs);
            this.pnlMain.Controls.Add(this.cbLeague);
            this.pnlMain.Controls.Add(this.lblLeague);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(384, 113);
            this.pnlMain.TabIndex = 0;
            // 
            // btnCheckTab
            // 
            this.btnCheckTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckTab.Location = new System.Drawing.Point(306, 83);
            this.btnCheckTab.Name = "btnCheckTab";
            this.btnCheckTab.Size = new System.Drawing.Size(75, 23);
            this.btnCheckTab.TabIndex = 4;
            this.btnCheckTab.Text = "Check Tab";
            this.btnCheckTab.UseVisualStyleBackColor = true;
            this.btnCheckTab.Click += new System.EventHandler(this.btnCheckTab_Click);
            // 
            // txtAccount
            // 
            this.txtAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccount.Location = new System.Drawing.Point(77, 6);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(222, 20);
            this.txtAccount.TabIndex = 0;
            this.txtAccount.Text = "Osmodium";
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(24, 9);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(47, 13);
            this.lblAccount.TabIndex = 4;
            this.lblAccount.Text = "Account";
            // 
            // txtTabIndex
            // 
            this.txtTabIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTabIndex.Location = new System.Drawing.Point(77, 59);
            this.txtTabIndex.Name = "txtTabIndex";
            this.txtTabIndex.Size = new System.Drawing.Size(222, 20);
            this.txtTabIndex.TabIndex = 2;
            this.txtTabIndex.Text = "7";
            // 
            // lblTabs
            // 
            this.lblTabs.AutoSize = true;
            this.lblTabs.Location = new System.Drawing.Point(45, 62);
            this.lblTabs.Name = "lblTabs";
            this.lblTabs.Size = new System.Drawing.Size(26, 13);
            this.lblTabs.TabIndex = 2;
            this.lblTabs.Text = "Tab";
            // 
            // cbLeague
            // 
            this.cbLeague.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLeague.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeague.FormattingEnabled = true;
            this.cbLeague.Items.AddRange(new object[] {
            "Bestiary",
            "Bestiary Hardcore",
            "Standard",
            "Standard Hardcore"});
            this.cbLeague.Location = new System.Drawing.Point(77, 32);
            this.cbLeague.Name = "cbLeague";
            this.cbLeague.Size = new System.Drawing.Size(222, 21);
            this.cbLeague.TabIndex = 1;
            // 
            // lblLeague
            // 
            this.lblLeague.AutoSize = true;
            this.lblLeague.Location = new System.Drawing.Point(28, 35);
            this.lblLeague.Name = "lblLeague";
            this.lblLeague.Size = new System.Drawing.Size(43, 13);
            this.lblLeague.TabIndex = 0;
            this.lblLeague.Text = "League";
            // 
            // txtPOESESSID
            // 
            this.txtPOESESSID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPOESESSID.Location = new System.Drawing.Point(77, 85);
            this.txtPOESESSID.Name = "txtPOESESSID";
            this.txtPOESESSID.Size = new System.Drawing.Size(222, 20);
            this.txtPOESESSID.TabIndex = 3;
            this.txtPOESESSID.Text = "24f77c867f75dc031d6d90754ffb38a1";
            // 
            // lblPOSESSID
            // 
            this.lblPOSESSID.AutoSize = true;
            this.lblPOSESSID.Location = new System.Drawing.Point(3, 88);
            this.lblPOSESSID.Name = "lblPOSESSID";
            this.lblPOSESSID.Size = new System.Drawing.Size(68, 13);
            this.lblPOSESSID.TabIndex = 6;
            this.lblPOSESSID.Text = "POESESSID";
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCheckTab;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 113);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 152);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PoE Stash Checker";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ComboBox cbLeague;
        private System.Windows.Forms.Label lblLeague;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.TextBox txtTabIndex;
        private System.Windows.Forms.Label lblTabs;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Button btnCheckTab;
        private System.Windows.Forms.TextBox txtPOESESSID;
        private System.Windows.Forms.Label lblPOSESSID;
    }
}

