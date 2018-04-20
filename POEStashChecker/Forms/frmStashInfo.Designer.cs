namespace POEStashChecker.Forms
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.flpItems = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlSpacer = new System.Windows.Forms.Panel();
            this.lblExalted = new System.Windows.Forms.Label();
            this.lblChaos = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 479);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(524, 22);
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
            this.pbLoader.Size = new System.Drawing.Size(524, 479);
            this.pbLoader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoader.TabIndex = 1;
            this.pbLoader.TabStop = false;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblExalted);
            this.pnlTop.Controls.Add(this.lblChaos);
            this.pnlTop.Controls.Add(this.pnlSpacer);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(524, 25);
            this.pnlTop.TabIndex = 3;
            // 
            // flpItems
            // 
            this.flpItems.AutoScroll = true;
            this.flpItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpItems.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpItems.Location = new System.Drawing.Point(0, 25);
            this.flpItems.Name = "flpItems";
            this.flpItems.Size = new System.Drawing.Size(524, 454);
            this.flpItems.TabIndex = 4;
            this.flpItems.Visible = false;
            this.flpItems.WrapContents = false;
            // 
            // pnlSpacer
            // 
            this.pnlSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSpacer.Location = new System.Drawing.Point(504, 0);
            this.pnlSpacer.Name = "pnlSpacer";
            this.pnlSpacer.Size = new System.Drawing.Size(20, 25);
            this.pnlSpacer.TabIndex = 0;
            // 
            // lblExalted
            // 
            this.lblExalted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExalted.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExalted.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExalted.Location = new System.Drawing.Point(356, 0);
            this.lblExalted.Name = "lblExalted";
            this.lblExalted.Size = new System.Drawing.Size(74, 25);
            this.lblExalted.TabIndex = 16;
            this.lblExalted.Text = "Exalted";
            this.lblExalted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChaos
            // 
            this.lblChaos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChaos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblChaos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaos.Location = new System.Drawing.Point(430, 0);
            this.lblChaos.Name = "lblChaos";
            this.lblChaos.Size = new System.Drawing.Size(74, 25);
            this.lblChaos.TabIndex = 15;
            this.lblChaos.Text = "Chaos";
            this.lblChaos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmStashInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 501);
            this.Controls.Add(this.flpItems);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pbLoader);
            this.Controls.Add(this.statusStrip);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 10000);
            this.MinimumSize = new System.Drawing.Size(520, 39);
            this.Name = "frmStashInfo";
            this.Text = "Stash Info";
            this.Load += new System.EventHandler(this.frmStashInfo_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoader)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.PictureBox pbLoader;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.FlowLayoutPanel flpItems;
        private System.Windows.Forms.Label lblExalted;
        private System.Windows.Forms.Label lblChaos;
        private System.Windows.Forms.Panel pnlSpacer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}