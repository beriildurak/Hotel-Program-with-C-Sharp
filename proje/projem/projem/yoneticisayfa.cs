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
    public partial class yoneticisayfa : Form
    {
        public yoneticisayfa()
        {
            this.Size = new Size(1109, 1000);
            InitializeComponent();
        }

        musterikayit mü = new musterikayit();
        rezervasyon rez = new rezervasyon();
        odadurum odadurum = new odadurum();
        yoneticigirisekran ye = new yoneticigirisekran();
        private void müşteriKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ye.Visible = false;
            odadurum.Visible = false;
            rez.Visible = false;
            mü.TopLevel = false;
            mü.Dock = DockStyle.Fill;
            panel1.Controls.Add(mü);
            mü.Show();
        }

        private void yoneticisayfa_Load(object sender, EventArgs e)
        {
            ye.TopLevel = false;
            ye.Dock = DockStyle.Fill;
            panel1.Controls.Add(ye);
            ye.Show();
        }

        private void odaDurumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ye.Visible = false;
            rez.Visible = false;
            mü.Visible = false;
            odadurum.TopLevel = false;
            odadurum.Dock = DockStyle.Fill;
            panel1.Controls.Add(odadurum);
            odadurum.Show();
        }

        private void rezervasyonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ye.Visible = false;
            odadurum.Visible = false;
            mü.Visible = false;
            rez.TopLevel = false;
            rez.Dock = DockStyle.Fill;
            panel1.Controls.Add(rez);
            rez.Show();
        }


        private void anaEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            odadurum.Visible=false;
            mü.Visible=false;
            rez.Visible=false;
            ye.TopLevel = false;
            ye.Dock = DockStyle.Fill;
            panel1.Controls.Add(ye);
            ye.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
