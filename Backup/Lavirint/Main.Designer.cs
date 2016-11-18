namespace Lavirint
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnPrviUDubinu = new System.Windows.Forms.Button();
            this.btnResenje = new System.Windows.Forms.Button();
            this.btnPrviUSirinu = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.displayPanel1 = new Lavirint.DisplayPanel();
            this.btnBidirekciona = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(2, 312);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 19);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(62, 312);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(56, 19);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Open";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnPrviUDubinu
            // 
            this.btnPrviUDubinu.Location = new System.Drawing.Point(122, 312);
            this.btnPrviUDubinu.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrviUDubinu.Name = "btnPrviUDubinu";
            this.btnPrviUDubinu.Size = new System.Drawing.Size(115, 19);
            this.btnPrviUDubinu.TabIndex = 3;
            this.btnPrviUDubinu.Text = "Prvi u dubinu";
            this.btnPrviUDubinu.UseVisualStyleBackColor = true;
            this.btnPrviUDubinu.Click += new System.EventHandler(this.btnPrviUDubinu_Click);
            // 
            // btnResenje
            // 
            this.btnResenje.Location = new System.Drawing.Point(537, 315);
            this.btnResenje.Margin = new System.Windows.Forms.Padding(2);
            this.btnResenje.Name = "btnResenje";
            this.btnResenje.Size = new System.Drawing.Size(77, 19);
            this.btnResenje.TabIndex = 5;
            this.btnResenje.Text = "Rešenje";
            this.btnResenje.UseVisualStyleBackColor = true;
            this.btnResenje.Click += new System.EventHandler(this.btnResenje_Click);
            // 
            // btnPrviUSirinu
            // 
            this.btnPrviUSirinu.Location = new System.Drawing.Point(241, 312);
            this.btnPrviUSirinu.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrviUSirinu.Name = "btnPrviUSirinu";
            this.btnPrviUSirinu.Size = new System.Drawing.Size(115, 19);
            this.btnPrviUSirinu.TabIndex = 6;
            this.btnPrviUSirinu.Text = "Prvi u širinu";
            this.btnPrviUSirinu.UseVisualStyleBackColor = true;
            this.btnPrviUSirinu.Click += new System.EventHandler(this.btnPrviUSirinu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(620, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 17);
            this.lblStatus.Text = "---------------";
            // 
            // displayPanel1
            // 
            this.displayPanel1.Location = new System.Drawing.Point(2, 1);
            this.displayPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.displayPanel1.Name = "displayPanel1";
            this.displayPanel1.Size = new System.Drawing.Size(612, 310);
            this.displayPanel1.TabIndex = 0;
            // 
            // btnBidirekciona
            // 
            this.btnBidirekciona.Location = new System.Drawing.Point(381, 312);
            this.btnBidirekciona.Margin = new System.Windows.Forms.Padding(2);
            this.btnBidirekciona.Name = "btnBidirekciona";
            this.btnBidirekciona.Size = new System.Drawing.Size(115, 19);
            this.btnBidirekciona.TabIndex = 8;
            this.btnBidirekciona.Text = "Bidirekciona";
            this.btnBidirekciona.UseVisualStyleBackColor = true;
            this.btnBidirekciona.Click += new System.EventHandler(this.btnBidirekciona_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 361);
            this.Controls.Add(this.btnBidirekciona);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPrviUSirinu);
            this.Controls.Add(this.btnResenje);
            this.Controls.Add(this.btnPrviUDubinu);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.displayPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "PRETRAGE Lavirint - Primer za vežbe iz predmeta ORI";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DisplayPanel displayPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnPrviUDubinu;
        private System.Windows.Forms.Button btnResenje;
        private System.Windows.Forms.Button btnPrviUSirinu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnBidirekciona;
    }
}

