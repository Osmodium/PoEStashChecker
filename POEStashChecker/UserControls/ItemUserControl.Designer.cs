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
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblChaos = new System.Windows.Forms.Label();
            this.lblExalted = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(48, 38);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbIcon);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(51, 38);
            this.panel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.SystemColors.Control;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(51, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(449, 38);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Item Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.MouseEnter += new System.EventHandler(this.ItemMouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.ItemMouseLeave);
            // 
            // lblChaos
            // 
            this.lblChaos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChaos.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblChaos.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaos.Location = new System.Drawing.Point(426, 0);
            this.lblChaos.Name = "lblChaos";
            this.lblChaos.Size = new System.Drawing.Size(74, 38);
            this.lblChaos.TabIndex = 7;
            this.lblChaos.Text = "0";
            this.lblChaos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExalted
            // 
            this.lblExalted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExalted.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExalted.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExalted.Location = new System.Drawing.Point(352, 0);
            this.lblExalted.Name = "lblExalted";
            this.lblExalted.Size = new System.Drawing.Size(74, 38);
            this.lblExalted.TabIndex = 6;
            this.lblExalted.Text = "0";
            this.lblExalted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblExalted);
            this.Controls.Add(this.lblChaos);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panel1);
            this.Name = "ItemUserControl";
            this.Size = new System.Drawing.Size(500, 38);
            this.MouseEnter += new System.EventHandler(this.ItemMouseEnter);
            this.MouseLeave += new System.EventHandler(this.ItemMouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblChaos;
        private System.Windows.Forms.Label lblExalted;
    }
}
