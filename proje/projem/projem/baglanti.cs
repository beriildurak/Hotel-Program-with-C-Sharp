using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projem
{

    public static class baglanti
    {
            public static SQLiteConnection bag()
            {
                try
                {
                    string baglantiyolu = "C:\\Users\\beril\\Desktop\\sondatabase.db";
                    SQLiteConnection sqliteConnection = new SQLiteConnection($"Data Source={baglantiyolu};Version=3;");
                    return sqliteConnection;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu: " + ex.Message);
                    return null;
                }
            }
        }
    }

