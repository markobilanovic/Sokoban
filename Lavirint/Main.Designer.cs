namespace Sokoban
{
    partial class Main
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretrageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prviUDubinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prviUŠirinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomoćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAutoruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rešenjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayPanel1 = new Sokoban.DisplayPanel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(563, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 17);
            this.lblStatus.Text = "---------------";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pretrageToolStripMenuItem,
            this.pomoćToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(563, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Table";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Učitaj";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Sačuvaj";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pretrageToolStripMenuItem
            // 
            this.pretrageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prviUDubinuToolStripMenuItem,
            this.prviUŠirinuToolStripMenuItem,
            this.toolStripSeparator1,
            this.rešenjeToolStripMenuItem});
            this.pretrageToolStripMenuItem.Name = "pretrageToolStripMenuItem";
            this.pretrageToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.pretrageToolStripMenuItem.Text = "Pretrage";
            // 
            // prviUDubinuToolStripMenuItem
            // 
            this.prviUDubinuToolStripMenuItem.Name = "prviUDubinuToolStripMenuItem";
            this.prviUDubinuToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.prviUDubinuToolStripMenuItem.Text = "Prvi u dubinu";
            this.prviUDubinuToolStripMenuItem.Click += new System.EventHandler(this.btnPrviUDubinu_Click);
            // 
            // prviUŠirinuToolStripMenuItem
            // 
            this.prviUŠirinuToolStripMenuItem.Name = "prviUŠirinuToolStripMenuItem";
            this.prviUŠirinuToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.prviUŠirinuToolStripMenuItem.Text = "Prvi u širinu";
            this.prviUŠirinuToolStripMenuItem.Click += new System.EventHandler(this.btnPrviUSirinu_Click);
            // 
            // pomoćToolStripMenuItem
            // 
            this.pomoćToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oAutoruToolStripMenuItem});
            this.pomoćToolStripMenuItem.Name = "pomoćToolStripMenuItem";
            this.pomoćToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomoćToolStripMenuItem.Text = "Pomoć";
            // 
            // oAutoruToolStripMenuItem
            // 
            this.oAutoruToolStripMenuItem.Name = "oAutoruToolStripMenuItem";
            this.oAutoruToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.oAutoruToolStripMenuItem.Text = "O programu";
            this.oAutoruToolStripMenuItem.Click += new System.EventHandler(this.oAutoruToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // rešenjeToolStripMenuItem
            // 
            this.rešenjeToolStripMenuItem.Name = "rešenjeToolStripMenuItem";
            this.rešenjeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.rešenjeToolStripMenuItem.Text = "Rešenje";
            this.rešenjeToolStripMenuItem.Click += new System.EventHandler(this.btnResenje_Click);
            // 
            // displayPanel1
            // 
            this.displayPanel1.Location = new System.Drawing.Point(0, 26);
            this.displayPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.displayPanel1.Name = "displayPanel1";
            this.displayPanel1.Size = new System.Drawing.Size(557, 360);
            this.displayPanel1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 412);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.displayPanel1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sokoban";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DisplayPanel displayPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretrageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prviUDubinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prviUŠirinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomoćToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAutoruToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem rešenjeToolStripMenuItem;
    }
}

