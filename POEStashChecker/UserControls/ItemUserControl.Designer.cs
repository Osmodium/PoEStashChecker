namespace POEStashChecker.UserControls
{
    partial class ItemUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.lblChaos = new System.Windows.Forms.Label();
            this.lblExalted = new System.Windows.Forms.Label();
            this.pbExalted = new System.Windows.Forms.PictureBox();
            this.pbChaos = new System.Windows.Forms.PictureBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbExalted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChaos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(47, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(263, 47);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Item Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChaos
            // 
            this.lblChaos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblChaos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaos.Location = new System.Drawing.Point(357, 0);
            this.lblChaos.Name = "lblChaos";
            this.lblChaos.Size = new System.Drawing.Size(47, 47);
            this.lblChaos.TabIndex = 3;
            this.lblChaos.Text = "0";
            this.lblChaos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExalted
            // 
            this.lblExalted.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExalted.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExalted.Location = new System.Drawing.Point(451, 0);
            this.lblExalted.Name = "lblExalted";
            this.lblExalted.Size = new System.Drawing.Size(47, 47);
            this.lblExalted.TabIndex = 5;
            this.lblExalted.Text = "0";
            this.lblExalted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbExalted
            // 
            this.pbExalted.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbExalted.Image = global::POEStashChecker.Properties.Resources.ExaltedOrb;
            this.pbExalted.Location = new System.Drawing.Point(404, 0);
            this.pbExalted.Name = "pbExalted";
            this.pbExalted.Size = new System.Drawing.Size(47, 47);
            this.pbExalted.TabIndex = 4;
            this.pbExalted.TabStop = false;
            // 
            // pbChaos
            // 
            this.pbChaos.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbChaos.Image = global::POEStashChecker.Properties.Resources.ChaosOrb;
            this.pbChaos.Location = new System.Drawing.Point(310, 0);
            this.pbChaos.Name = "pbChaos";
            this.pbChaos.Size = new System.Drawing.Size(47, 47);
            this.pbChaos.TabIndex = 2;
            this.pbChaos.TabStop = false;
            // 
            // pbIcon
            // 
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(47, 47);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // ItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblExalted);
            this.Controls.Add(this.pbExalted);
            this.Controls.Add(this.lblChaos);
            this.Controls.Add(this.pbChaos);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pbIcon);
            this.Name = "ItemUserControl";
            this.Size = new System.Drawing.Size(500, 47);
            ((System.ComponentModel.ISupportInitialize)(this.pbExalted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChaos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbChaos;
        private System.Windows.Forms.Label lblChaos;
        private System.Windows.Forms.PictureBox pbExalted;
        private System.Windows.Forms.Label lblExalted;
    }
}
