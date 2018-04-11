namespace POEStashChecker
{
    partial class frmStashInfo
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbLoader = new System.Windows.Forms.PictureBox();
            this.lbStash = new System.Windows.Forms.ListBox();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(484, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel.Text = "Loading...";
            // 
            // pbLoader
            // 
            this.pbLoader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoader.Image = global::POEStashChecker.Properties.Resources.loader;
            this.pbLoader.Location = new System.Drawing.Point(0, 0);
            this.pbLoader.Name = "pbLoader";
            this.pbLoader.Size = new System.Drawing.Size(484, 439);
            this.pbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoader.TabIndex = 1;
            this.pbLoader.TabStop = false;
            // 
            // lbStash
            // 
            this.lbStash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStash.FormattingEnabled = true;
            this.lbStash.Location = new System.Drawing.Point(0, 0);
            this.lbStash.Name = "lbStash";
            this.lbStash.Size = new System.Drawing.Size(484, 439);
            this.lbStash.TabIndex = 2;
            this.lbStash.Visible = false;
            // 
            // frmStashInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.lbStash);
            this.Controls.Add(this.pbLoader);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "frmStashInfo";
            this.Text = "Stash Info";
            this.Load += new System.EventHandler(this.frmStashInfo_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.PictureBox pbLoader;
        private System.Windows.Forms.ListBox lbStash;
    }
}