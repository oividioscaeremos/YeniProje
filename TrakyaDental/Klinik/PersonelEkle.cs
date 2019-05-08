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

namespace TrakyaDental.Klinik
{
    public partial class PersonelEkle : UserControl
    {
        public PersonelEkle()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = (txtAd.Text).ToString();
            string soyad = (txtSoyad.Text).ToString();
            string maas = (txtMaas.Text).ToString();
            string unvan = comboBox1.SelectedItem.ToString();


            string conStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            using (SqlConnection con=new SqlConnection(conStr))
            {
                string sql = "Insert into Personel (PersonelAd,PersonelSoyad,Unvan,Maas) values(@ad,@soyad,@unvan,@maas)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                   
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@maas", maas);
                    cmd.Parameters.AddWithValue("@unvan", unvan);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Personel kaydedildi <3 ");
                    con.Close();
                }

            }
         
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Doktor");
            comboBox1.Items.Add("Hemşire");
            comboBox1.Items.Add("Bilgi İşlem Sorumlusu");
            comboBox1.Items.Add("Temizlik Personeli");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
