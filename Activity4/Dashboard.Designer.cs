namespace Activity4
{
    partial class Dashboard
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
            this.Logout = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_display = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTheProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.developersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_settings = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.DataGridView();
            this.Table2 = new System.Windows.Forms.DataGridView();
            this.btn_export2 = new System.Windows.Forms.Button();
            this.btn_display2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table2)).BeginInit();
            this.SuspendLayout();
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.DarkRed;
            this.Logout.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout.ForeColor = System.Drawing.Color.Transparent;
            this.Logout.Location = new System.Drawing.Point(40, 470);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(102, 36);
            this.Logout.TabIndex = 1;
            this.Logout.Text = "Log Out";
            this.Logout.UseVisualStyleBackColor = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(838, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ordered Products";
            // 
            // btn_display
            // 
            this.btn_display.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_display.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_display.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_display.Location = new System.Drawing.Point(782, 455);
            this.btn_display.Name = "btn_display";
            this.btn_display.Size = new System.Drawing.Size(98, 67);
            this.btn_display.TabIndex = 4;
            this.btn_display.Text = "Display Orders";
            this.btn_display.UseVisualStyleBackColor = false;
            this.btn_display.Click += new System.EventHandler(this.btn_display_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_export.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_export.Location = new System.Drawing.Point(1008, 455);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(94, 67);
            this.btn_export.TabIndex = 6;
            this.btn_export.Text = "Export to Excel";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(37, 521);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(113, 16);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Report a Problem";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.whatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1190, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTheProgramToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeTheProgramToolStripMenuItem
            // 
            this.closeTheProgramToolStripMenuItem.Name = "closeTheProgramToolStripMenuItem";
            this.closeTheProgramToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.closeTheProgramToolStripMenuItem.Text = "Close the Program";
            this.closeTheProgramToolStripMenuItem.Click += new System.EventHandler(this.closeTheProgramToolStripMenuItem_Click);
            // 
            // whatToolStripMenuItem
            // 
            this.whatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.developersToolStripMenuItem});
            this.whatToolStripMenuItem.Name = "whatToolStripMenuItem";
            this.whatToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.whatToolStripMenuItem.Text = "What";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // developersToolStripMenuItem
            // 
            this.developersToolStripMenuItem.Name = "developersToolStripMenuItem";
            this.developersToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.developersToolStripMenuItem.Text = "Developers";
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btn_settings.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_settings.Location = new System.Drawing.Point(40, 49);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(94, 53);
            this.btn_settings.TabIndex = 11;
            this.btn_settings.Text = "Manage Accounts";
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // Table
            // 
            this.Table.BackgroundColor = System.Drawing.Color.White;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.GridColor = System.Drawing.SystemColors.Control;
            this.Table.Location = new System.Drawing.Point(673, 100);
            this.Table.Name = "Table";
            this.Table.RowHeadersWidth = 51;
            this.Table.RowTemplate.Height = 24;
            this.Table.Size = new System.Drawing.Size(501, 310);
            this.Table.TabIndex = 12;
            // 
            // Table2
            // 
            this.Table2.BackgroundColor = System.Drawing.Color.White;
            this.Table2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table2.GridColor = System.Drawing.SystemColors.Control;
            this.Table2.Location = new System.Drawing.Point(174, 100);
            this.Table2.Name = "Table2";
            this.Table2.RowHeadersWidth = 51;
            this.Table2.RowTemplate.Height = 24;
            this.Table2.Size = new System.Drawing.Size(473, 310);
            this.Table2.TabIndex = 16;
            // 
            // btn_export2
            // 
            this.btn_export2.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_export2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export2.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_export2.Location = new System.Drawing.Point(501, 455);
            this.btn_export2.Name = "btn_export2";
            this.btn_export2.Size = new System.Drawing.Size(94, 67);
            this.btn_export2.TabIndex = 15;
            this.btn_export2.Text = "Export to Excel";
            this.btn_export2.UseVisualStyleBackColor = false;
            this.btn_export2.Click += new System.EventHandler(this.btn_export2_Click);
            // 
            // btn_display2
            // 
            this.btn_display2.BackColor = System.Drawing.Color.PeachPuff;
            this.btn_display2.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_display2.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_display2.Location = new System.Drawing.Point(275, 455);
            this.btn_display2.Name = "btn_display2";
            this.btn_display2.Size = new System.Drawing.Size(98, 67);
            this.btn_display2.TabIndex = 14;
            this.btn_display2.Text = "Display Products";
            this.btn_display2.UseVisualStyleBackColor = false;
            this.btn_display2.Click += new System.EventHandler(this.btn_display2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(318, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Product Categories";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1190, 578);
            this.Controls.Add(this.Table2);
            this.Controls.Add(this.btn_export2);
            this.Controls.Add(this.btn_display2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Logout);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logout;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_display;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTheProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem developersToolStripMenuItem;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.DataGridView Table;
        private System.Windows.Forms.DataGridView Table2;
        private System.Windows.Forms.Button btn_export2;
        private System.Windows.Forms.Button btn_display2;
        private System.Windows.Forms.Label label2;
    }
}