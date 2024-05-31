using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projem
{
    public partial class rezervasyon : Form
    {

        public rezervasyon()
        {
            this.Size = new Size(1109, 1000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();

        }
        public void musteribilgicek()
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    if (connection != null) //baglantı basarılı ise yapılacak islemler
                    {
                        string query = "SELECT * FROM musterikayit";
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection)) //sql sorgusunu ve bağlantıyı kullanarak veritabanından veri cektim
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable); //veri tabanından çektiğim verileri dataTable a doldurdum

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = dataTable;

                        }
                        string roomQuery = "SELECT * FROM odalar";
                        using (SQLiteDataAdapter roomAdapter = new SQLiteDataAdapter(roomQuery, connection))
                        {
                            DataTable roomDataTable = new DataTable();
                            roomAdapter.Fill(roomDataTable);

                            dataGridView2.DataSource = null;
                            dataGridView2.DataSource = roomDataTable;
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
        private void rezervasyon_Load(object sender, EventArgs e)
        {
            musteribilgicek();
            try
            {
                using (SQLiteConnection sqliteConnection = baglanti.bag())
                {
                    sqliteConnection.Open();
                    string query = "SELECT oda_tipi FROM odatipleri";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            // comboboxa verileri ekleme islemim
                            while (reader.Read())
                            {
                                cmbOdaTipi.Items.Add(reader["oda_tipi"].ToString());
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

            try
            {
                using (SQLiteConnection sqliteConnection = baglanti.bag())
                {
                    sqliteConnection.Open();
                    string query = "SELECT oda_id FROM odalar";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader()) //veri okuyucumu oluşturdum
                        {
                            // reader Read metodu ile bir sonraki satıra geçer eğer bir sonraki satır varsa true döner
                            while (reader.Read())
                            {
                                cmbOdaNo.Items.Add(reader["oda_id"].ToString());
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

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            int odaNo = int.Parse(cmbOdaNo.SelectedItem.ToString());
            int musteriID = int.Parse(txtId.Text);
            rezervasyonguncelle(odaNo);

            if (odadurum(musteriID, odaNo)) //metod çalışırsa işlemi
            {
                MessageBox.Show("Rezervasyon başarıyla eklendi.");
            }
            else
            {
                MessageBox.Show("Rezervasyon eklenirken bir hata oluştu.");
            }
        }
       
        private bool odadurum(int musteriID, int odaNo)
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    if (connection != null)
                    {
                        
                        string insertQuery = "INSERT INTO musterioda (m_id,oda_id) VALUES (@m_id,@oda_id)";
                        using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@m_id", musteriID);
                            cmd.Parameters.AddWithValue("@oda_id", odaNo);
                            cmd.ExecuteNonQuery();
                        }
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Veritabanına bağlantı başarısız!");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Oda durumu eklenirken hata oluştu: " + ex.Message);
                return false;
            }
        }
        private int gunlukucretigetir(string odaTipi)
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    string query = "SELECT gunlukucret FROM odatipleri WHERE oda_tipi = @oda_tipi";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@oda_tipi", odaTipi);
                        object result = cmd.ExecuteScalar();

                        int gunlukUcret;
                        if (result != null && int.TryParse(result.ToString(), out gunlukUcret))
                        {
                            return gunlukUcret;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Günlük ücreti getirirken bir hata oluştu: " + ex.Message);
            }

            return -1;
        }
        private void rezervasyonguncelle(int odaNo)
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    if (connection != null)
                    {
                        // Oda rezervasyon durumunu güncelliyorum
                        string updateQuery = "UPDATE odalar SET rezervemi = 1 WHERE oda_id = @oda_id";
                        using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@oda_id", odaNo);
                            cmd.ExecuteNonQuery();
                        }
                        //datagridviewları güncelle
                        musteribilgicek();

                    }
                    else
                    {
                        MessageBox.Show("Veritabanına bağlantı başarısız!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rezervasyon güncellenirken hata oluştu: " + ex.Message);
            }

        }


        private void txtGun_TextChanged(object sender, EventArgs e)
        {
            string selectedOdaTipi = cmbOdaTipi.SelectedItem?.ToString();

            try
            {
                int gunsayisi = int.Parse(txtGun.Text);

                int gunlukucret = gunlukucretigetir(selectedOdaTipi);

                // Toplam ücreti hesapla ve Label'a yazdır
                int toplamucret = gunlukucret * gunsayisi;
                lblFiyat.Text = toplamucret.ToString("C0"); // para biriminin gözükmesi için C0 kullanıyorum
            }
            catch (FormatException)
            {
            }
        }
    }
}

   

