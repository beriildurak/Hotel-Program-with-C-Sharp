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
    public partial class odadurum : Form
    {
        public odadurum()
        {
            this.Size = new Size(1109, 1000);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            InitializeComponent();
        }

        private void odadurumyukle(object sender, EventArgs e)
        {
            musteriekleme();
            try
            {
                using (SQLiteConnection sqliteConnection = baglanti.bag())
                {
                    sqliteConnection.Open();
                    string query = "SELECT oda_id FROM odalar";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, sqliteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["oda_id"].ToString());
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
        public void musteriekleme()
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    if (connection != null)
                    {
                        string query = "SELECT * FROM musterioda";
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
        private void datagridiguncelle(int odaID)
        {
            try
            {
                using (SQLiteConnection connection = baglanti.bag())
                {
                    connection.Open();
                    if (connection != null)
                    {
                        //textboxa girilen ODA ID ye göre datagridviewdan ve databaseden sorguluyo datagridviewdan o veriyi getiriyor
                        string query = "SELECT * FROM musterioda WHERE oda_id = @oda_id";
                        using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@oda_id", odaID);
                            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                adapter.Fill(dataTable);

                                // DataGridView'ı güncelle
                                dataGridView1.DataSource = dataTable;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("veritabanına bağlantı başarısız");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("veri getirilirken hata oluştu: " + ex.Message);
            }
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                int selectedOdaID = int.Parse(comboBox1.SelectedItem.ToString());
                datagridiguncelle(selectedOdaID);
            }
        }
    }
}
