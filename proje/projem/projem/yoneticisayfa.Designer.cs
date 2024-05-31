namespace projem
{
    partial class yoneticisayfa
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaEkranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.müşteriKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaDurumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervasyonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.RosyBrown;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaEkranToolStripMenuItem,
            this.müşteriKayıtToolStripMenuItem,
            this.odaDurumToolStripMenuItem,
            this.rezervasyonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaEkranToolStripMenuItem
            // 
            this.anaEkranToolStripMenuItem.Name = "anaEkranToolStripMenuItem";
            this.anaEkranToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.anaEkranToolStripMenuItem.Text = "Ana Ekran";
            this.anaEkranToolStripMenuItem.Click += new System.EventHandler(this.anaEkranToolStripMenuItem_Click);
            // 
            // müşteriKayıtToolStripMenuItem
            // 
            this.müşteriKayıtToolStripMenuItem.Name = "müşteriKayıtToolStripMenuItem";
            this.müşteriKayıtToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.müşteriKayıtToolStripMenuItem.Text = "Yeni Müşteri Kayıt";
            this.müşteriKayıtToolStripMenuItem.Click += new System.EventHandler(this.müşteriKayıtToolStripMenuItem_Click);
            // 
            // odaDurumToolStripMenuItem
            // 
            this.odaDurumToolStripMenuItem.Name = "odaDurumToolStripMenuItem";
            this.odaDurumToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.odaDurumToolStripMenuItem.Text = "Oda Durum";
            this.odaDurumToolStripMenuItem.Click += new System.EventHandler(this.odaDurumToolStripMenuItem_Click);
            // 
            // rezervasyonToolStripMenuItem
            // 
            this.rezervasyonToolStripMenuItem.Name = "rezervasyonToolStripMenuItem";
            this.rezervasyonToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.rezervasyonToolStripMenuItem.Text = "Rezervasyon";
            this.rezervasyonToolStripMenuItem.Click += new System.EventHandler(this.rezervasyonToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 756);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // yoneticisayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 774);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "yoneticisayfa";
            this.Text = "yoneticisayfa";
            this.Load += new System.EventHandler(this.yoneticisayfa_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriKayıtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaDurumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervasyonToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem anaEkranToolStripMenuItem;
    }
}