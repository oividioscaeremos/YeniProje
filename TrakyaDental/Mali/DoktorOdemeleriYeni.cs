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
    public partial class DoktorOdemeleriYeni : UserControl
    {

        public DoktorOdemeleriYeni()
        {
            InitializeComponent();
        }
        public ComboBox personelCB
        {
            set
            {
                foreach (string item in value.Items)
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
            string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123;";
            SqlConnection con = new SqlConnection(connStr);
            con.Open();

            string[] doktorID = comboboxPersonel.SelectedItem.ToString().Split('-');
            SqlCommand insertIslem = new SqlCommand("Insert into Islem(PersonelID,IslemTipiID,Bakiye) values(" + Convert.ToInt32(doktorID[0])
                + "," +
                2 
                + "," +
                Convert.ToInt32(tbUcret.Text) +")", con);
            try
            {
                insertIslem.ExecuteNonQuery();
            }
            catch (Exception doktorEklemeHatasi)
            {
                MessageBox.Show(doktorEklemeHatasi.Message, "Doktor Ödemesi Eklenemedi.");
            }
            finally
            {
                MessageBox.Show("Ödeme Başarıyla Gerçekleştirildi.");
                this.Hide();
                
            }
        }


        private void DoktorOdemeleriYeni_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123;";
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand doktorlarCek = new SqlCommand("Select * from Personel where Unvan=@Unvan", con);
                doktorlarCek.Parameters.AddWithValue("@Unvan", "Doktor");
                SqlDataReader doktorOkuyucu = doktorlarCek.ExecuteReader();
                while (doktorOkuyucu.Read())
                {
                    comboboxPersonel.Items.Add(doktorOkuyucu[doktorOkuyucu.GetOrdinal("PersonelID")] + " - " + doktorOkuyucu[doktorOkuyucu.GetOrdinal("PersonelAd")]);
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}

