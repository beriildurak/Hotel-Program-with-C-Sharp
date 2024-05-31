using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace projem
{

    public partial class yonetici : Form
    {
        private int deneme = 0; //yönetici giriş ekranında hatalı girişi sayar
        private DateTime kilitli;   //sistemi kilitlemek için kullandıgım datetime nesnesi
        private Timer timergerisayim; //geri sayım için kullanılan timer

        public yonetici()
        {
            this.Size = new Size(1109, 1000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
            gerisayim();  // Geri sayımı başlat
            KontrolDurumunuGuncelle(); // Kilitleme durumuna bağlı olarak kontrollerin durumunu güncelle

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.ToLower();
            string sifre = textBox2.Text;

            if (giriskontrol(kullaniciAdi, sifre))
            {
                MessageBox.Show("giriş başarılı!");
                GeriSayimTimerDurdur();
                yoneticisayfa ys = new yoneticisayfa();
                ys.Show();
            }
            else
            {
                deneme++;
                MessageBox.Show("hatalı kullanıcı adı veya şifre tekrar deneyiniz");
                if (deneme >= 5)
                {
                    kilitli = DateTime.Now.AddMinutes(3); // 3 dakika boyunca kilitli
                    MessageBox.Show("sistem 5 başarısız giriş denemesi nedeniyle 3 dakika kilitlendi.");
                    KontrolDurumunuGuncelle();
                    kilitleme(true);
                    gerisayim();
                    deneme = 0;

                }
            }
        }
        private bool giriskontrol(string kullaniciAdi, string sifre)
        {
            try
            {
                if (DateTime.Now < kilitli) //sistem kilitli mi değil mi onu kontrol eder
                {
                    MessageBox.Show("sistem şu anda kilitli lütfen daha sonra tekrar deneyiniz.");
                    return false;
                }

                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    string query = "SELECT * FROM yonetici WHERE kullaniciadi = @KullaniciAdi AND kullanicisifre = @KullaniciSifre";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                        cmd.Parameters.AddWithValue("@KullaniciSifre", sifre);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            bool dogrulamaSonucu = reader.HasRows;
                            reader.Close();
                            connection.Close();
                            return dogrulamaSonucu;

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("giriş kontrolü yapılırken hata oluştu: " + ex.Message);
                return false;
            }
        }
        private void kilitleme(bool kilitlimi)  
        {
            textBox1.Enabled = !kilitlimi;
            textBox2.Enabled = !kilitlimi;
            button1.Enabled = !kilitlimi;
        }
        private void gerisayim()
        { //Bu metod giriş başarısız olduğunda başlatılan bir geri sayım timerını oluşturur.
            timergerisayim = new Timer();
            timergerisayim.Interval = 1000; 
            timergerisayim.Tick +=timergerisayimtick; //her bir saniyede timergerisayimtick metodunu tetikler
            timergerisayim.Start();
        }
        private void KontrolDurumunuGuncelle()
        {
            textBox1.Enabled = DateTime.Now >= kilitli;
            textBox2.Enabled = DateTime.Now >= kilitli;
            button1.Enabled = DateTime.Now >= kilitli;

            if (DateTime.Now < kilitli)
            {
                TimeSpan kalansure = kilitli - DateTime.Now;
                lblTimer.Text = $"Kalan süre: {kalansure.Minutes} dakika {kalansure.Seconds} saniye";
            }
            else
            {
                lblTimer.Text = string.Empty;
            }
        }
        private void timergerisayimtick(object sender, EventArgs e)
        { //kontrol durumunu günceller ve sistem kilit süresi dolduğunda geri sayım timerını durdurur.
            KontrolDurumunuGuncelle();

            if (DateTime.Now >= kilitli)
            {
                GeriSayimTimerDurdur();
            }
        }
        private void GeriSayimTimerDurdur()
        { //geri sayım timerını durdurur ve bellekten temizler
            timergerisayim.Stop();
            timergerisayim.Dispose();
        }
        private void yonetici_KeyPress(object sender, KeyPressEventArgs e)
        { //enter tuşuna basıldığında giriş butonuna tıklar
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // enter tusunun normal islevini siliyorum
                button1.PerformClick(); 
            }
        }
    }
}
