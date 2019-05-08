using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TrakyaDental.Stok
{
    public partial class StokHareket : UserControl
    {
        public string ID
        {
            set { tbUrunID.Text = value; }
        }
        public StokHareket()
        {
            InitializeComponent();
        }
        public ComboBox personelCB
        {
            set {
                foreach(string item in value.Items)
                {
                    comboboxPersonel.Items.Add(item);
                }
            }
        }
        private void closeIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0){
                // Girdi olacağı için öncelikle stoklardaki verilerini 
                // güncelleyip ardından islemler tablosuna girdi şeklinde 
                // belirteceğiz.
                try
                {
                    string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123;";
                    int mevcutMiktar = 0;
                    SqlConnection con = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand mevcutMiktarGetir = new SqlCommand("Select * from Stok where UrunID="+ Convert.ToInt32(tbUrunID.Text), con); // Mevcut miktarı getiriyoruz.
                    SqlDataReader miktarReader = mevcutMiktarGetir.ExecuteReader();
                    while (miktarReader.Read())
                    {
                        mevcutMiktar = miktarReader.GetInt32(miktarReader.GetOrdinal("Miktar"));
                    }
                    miktarReader.Close();
                    SqlCommand cmdStokGuncelle = new SqlCommand("UPDATE Stok SET Miktar=" // Stok miktarını güncelliyoruz.
                        + (mevcutMiktar + Convert.ToInt32(tbMiktar.Text))
                        + " where UrunID = " 
                        + Convert.ToInt32(tbUrunID.Text), con);
                    SqlCommand girdiIslemEkle = new SqlCommand("Insert into Islem(PersonelID,IslemTipiID) values(@PersonelID,@IslemTipiID)",con); // Yeni bir işlem olarak kaydediyoruz.
                    girdiIslemEkle.Parameters.AddWithValue("@PersonelID", comboboxPersonel.SelectedItem.ToString()[0]);
                    girdiIslemEkle.Parameters.AddWithValue("@IslemTipiID", (comboBox1.SelectedIndex + 1));

                    SqlCommand insertIntoIslemler = new SqlCommand("Insert into Islem(IslemTipiID,PersonelID,Bakiye) Values(@IslemTipiID,@PersonelID,@Bakiye)",con);
                    insertIntoIslemler.Parameters.AddWithValue("@IslemTipiID", comboBox1.SelectedIndex + 1);
                    insertIntoIslemler.Parameters.AddWithValue("@PersonelID",comboboxPersonel.SelectedItem.ToString()[0]);
                    insertIntoIslemler.Parameters.AddWithValue("Bakiye", (Convert.ToInt32(tbMiktar.Text) * Convert.ToInt32(tbUcret.Text)));

                    insertIntoIslemler.ExecuteNonQuery();
                    cmdStokGuncelle.ExecuteNonQuery();
                    girdiIslemEkle.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            }
            else{
                // Çıktı olacağı için öncelikle stoklardaki verilerini 
                // güncelleyip ardından islemler tablosuna çıktı şeklinde 
                // belirteceğiz
                try
                {
                    string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=rootroot;";
                    int mevcutMiktar = 0;
                    SqlConnection con = new SqlConnection(connStr);
                    con.Open();
                    SqlCommand mevcutMiktarGetir = new SqlCommand("Select * from Stok where UrunID=" + Convert.ToInt32(tbUrunID.Text), con); // Mevcut miktarı getiriyoruz.
                    SqlDataReader miktarReader = mevcutMiktarGetir.ExecuteReader();
                    while (miktarReader.Read())
                    {
                        mevcutMiktar = miktarReader.GetInt32(miktarReader.GetOrdinal("Miktar")); // Mevcut miktarın okunması için gerekli sütündan verilerimizi çekiyoruz.
                    }
                    miktarReader.Close();
                    SqlCommand cmdStokGuncelle = new SqlCommand("UPDATE Stok SET Miktar=" // Stok miktarını güncelliyoruz.
                        + (mevcutMiktar - Convert.ToInt32(tbMiktar.Text))
                        + " where UrunID = "
                        + Convert.ToInt32(tbUrunID.Text), con);
                    SqlCommand girdiIslemEkle = new SqlCommand("Insert into Islem(PersonelID,IslemTipiID) values(@PersonelID,@IslemTipiID)", con); // Yeni bir işlem olarak kaydediyoruz.
                    girdiIslemEkle.Parameters.AddWithValue("@PersonelID", comboboxPersonel.SelectedItem.ToString()[0]);
                    girdiIslemEkle.Parameters.AddWithValue("@IslemTipiID", (comboBox1.SelectedIndex + 1));

                    SqlCommand insertIntoIslemler = new SqlCommand("Insert into Islem(IslemTipiID,PersonelID,Bakiye) Values(@IslemTipiID,@PersonelID,@Bakiye)", con);
                    insertIntoIslemler.Parameters.AddWithValue("@IslemTipiID", comboBox1.SelectedIndex + 1);
                    insertIntoIslemler.Parameters.AddWithValue("@PersonelID", comboboxPersonel.SelectedItem.ToString()[0]);
                    insertIntoIslemler.Parameters.AddWithValue("Bakiye", (Convert.ToInt32(tbMiktar.Text) * Convert.ToInt32(tbUcret.Text)));

                    insertIntoIslemler.ExecuteNonQuery();
                    cmdStokGuncelle.ExecuteNonQuery();
                    girdiIslemEkle.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }

            }
        }
    }
}
