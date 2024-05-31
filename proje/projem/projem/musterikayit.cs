using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace projem
{
    public partial class musterikayit : Form
    {

        public musterikayit()
        {
            this.Size = new Size(1109, 1000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }

        private void chcGecici_CheckedChanged(object sender, EventArgs e)
        {
            if (chcGecici.Checked)  //tc vatandaşı değilim checkboxı işaretlendiğinde tckimliğe ait label ve textboxı kapatıp gecicikimlikno ya ait label ve textboxı getirir
            {
                txtGecici.Visible = true;
                lblGecici.Visible = true;
                txtTc.Visible = false;
                lblTc.Visible = false;
            }
            else
            {
                txtGecici.Visible = false;
                lblGecici.Visible = false;
                txtTc.Visible = true;
                lblTc.Visible = true;
            }

        }

        private void musterikayit_Load(object sender, EventArgs e)
        {
            musteriekleme();
            // comboboxıma ülkeler tablomdan veri çektiğim kısım
            try
            {
                using(SQLiteConnection sqliteConnection = baglanti.bag()){
                    sqliteConnection.Open();
                    string query = "SELECT value FROM ulkeler";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbUlkeler.Items.Add(reader["value"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    sqliteConnection.Close();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verileri ComboBox'a yüklerken hata oluştu: " + ex.Message);
            }


        }
        public void musteriekleme() //datagridview a musterikayit tablosunu çektigim kısım
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    if (connection != null)
                    {
                        string query = "SELECT * FROM musterikayit";
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veritabanına bağlantı başarısız!");
                    }
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata oluştu: " + ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musteriekleme();
            string ad = txtAdi.Text;
            string soyad = txtSoyadi.Text;
            string telefon = txtTel.Text;
            string email = txtEmail.Text;
            string tc = txtTc.Text;
            string gecici = txtGecici.Text;
            string ulke = cmbUlkeler.SelectedItem?.ToString();

            using (SQLiteConnection sqliteConnection = baglanti.bag())
            {
                sqliteConnection.Open();
                // Müşteri bilgilerini eklemek için sorgu
                string query = "INSERT INTO musterikayit(Adi,Soyadi,GeciciKimlikNo,TcKimlikNo,TelNo,Email,Ulke) VALUES (@Ad,@Soyad,@GeciciKimlikNo,@TcKimlikNo,@TelNo,@Email,@Ulke)";
                try
                {
                    using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@Ad", ad);
                        cmd.Parameters.AddWithValue("@Soyad", soyad);
                        cmd.Parameters.AddWithValue("@TcKimlikNo", tc);
                        cmd.Parameters.AddWithValue("@GeciciKimlikNo", gecici);
                        cmd.Parameters.AddWithValue("@TelNo", telefon);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Ulke", ulke);
                        cmd.ExecuteNonQuery();
                    }
                    sqliteConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            Temizle();
            musteriekleme();

        }
   

        private void Temizle()
        {
            txtAdi.Clear();
            txtSoyadi.Clear();
            txtEmail.Clear();
            txtTc.Clear();
            txtTel.Clear();
            txtGecici.Clear();
            cmbUlkeler.SelectedItem = null;
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            //
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int silinecekID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["m_id"].Value);

                // databaseden datagridviewda seçilen kişiyi silme 
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand("DELETE FROM musterikayit WHERE m_id = @SilinecekID", connection))
                    {
                        command.Parameters.AddWithValue("@SilinecekID", silinecekID);
                        command.ExecuteNonQuery();
                    }
                }

                dataGridView1.Rows.RemoveAt(selectedRowIndex); //datagridviewdan silme 
            }
        }
    }
}
