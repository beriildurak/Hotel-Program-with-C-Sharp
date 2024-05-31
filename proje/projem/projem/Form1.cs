using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.Size = new Size(1109, 1000);            
            InitializeComponent();
        }

        AnaSayfa ana = new AnaSayfa();
        yonetici yt = new yonetici();
        hakkimizda hk = new hakkimizda();


        private void Form1_Load(object sender, EventArgs e)
        {
            ana.TopLevel = false;
            ana.Dock = DockStyle.Fill; //formun içindeki tüm boş alanı kaplaması için kullandım
            panel1.Controls.Add(ana);   //formu panelin içerisine ekledim
            ana.Show();
        }

     

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hk.Visible=false;
            yt.Visible=false;
            ana.TopLevel = false;
            ana.Dock = DockStyle.Fill;
            panel1.Controls.Add(ana);
            ana.Show();
        }
     

        private void yöneticiGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hk.Visible = false;
            ana.Visible = false;
            yt.TopLevel = false;
            yt.Dock = DockStyle.Fill;
            panel1.Controls.Add(yt);
            yt.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yt.Visible = false;
            ana.Visible = false;
            hk.TopLevel = false;
            hk.Dock = DockStyle.Fill;
            panel1.Controls.Add(hk);
            hk.Show();

        }
    }
}
