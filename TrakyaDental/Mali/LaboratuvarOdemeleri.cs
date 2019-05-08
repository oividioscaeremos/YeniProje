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

namespace TrakyaDental
{
    public partial class LaboratuvarOdemeleri : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123";

        public LaboratuvarOdemeleri()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void LaboratuvarOdemeleri_Load(object sender, EventArgs e)
        {

            /* İlk başta SQL komutlarını kullanacağın için en üstte SQL kütüphanesini entegre et
             * Daha sonra yeni bir SQL bağlantısı oluştur.
             * Kullanacağın tabloların isimlerini tanımla.
             * Yeni bir SQL Adapter oluşturarak hangi veriyi çekeceğini SQL sorgusu yazarak bul.,
             * Bulduğun veriyi açıklama bölümüne ekle.
             * Veritabanını ve içindeki tablolarıyla birlikte uygulamana bağla.
             * DataGridView e aktarıp çıktılarını uygulamana yansıt.*/




            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                DataTable tipID = new DataTable();
                DataTable Islemler = new DataTable();
                SqlDataAdapter tipIdAdapter = new SqlDataAdapter("SELECT TipID FROM IslemTipi where Tip_Aciklama = @aciklama ", sqlCon);
                tipIdAdapter.SelectCommand.Parameters.AddWithValue("@aciklama", "LABORATUVAR ÖDEMELERİ");
                tipIdAdapter.Fill(tipID);

                DataRowCollection result = tipID.Rows;

                SqlDataAdapter islemAdapter = new SqlDataAdapter("SELECT * FROM Islem where IslemTipiID = " + Int32.Parse(result[0][0].ToString()), sqlCon);
                islemAdapter.Fill(Islemler);

                dataGridView2.DataSource = Islemler;



                laboratuvarOdemeleriYeni1.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            laboratuvarOdemeleriYeni1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                /*
             * Yeni bir SQL bağlantısı oluştur.
             * Kullanacağın tabloların isimlerini tanımla.
             * Yeni bir SQL Adapter oluşturarak hangi veriyi çekeceğini SQL sorgusu yazarak bul.,
             * Bulduğun veriyi açıklama bölümüne ekle.
             * Veritabanını ve içindeki tablolarıyla birlikte uygulamana bağla.
             * DataGridView e aktarıp çıktılarını uygulamana yansıt.*/
                sqlCon.Open();
                DataTable tipID = new DataTable();
                DataTable Islemler = new DataTable();
                SqlDataAdapter tipIdAdapter = new SqlDataAdapter("SELECT TipID FROM IslemTipi where Tip_Aciklama = @aciklama ", sqlCon);
                tipIdAdapter.SelectCommand.Parameters.AddWithValue("@aciklama", "LABORATUVAR ÖDEMELERİ");
                tipIdAdapter.Fill(tipID);

                DataRowCollection result = tipID.Rows;

                SqlDataAdapter islemAdapter = new SqlDataAdapter("SELECT * FROM Islem where IslemTipiID = " + Int32.Parse(result[0][0].ToString()), sqlCon);
                islemAdapter.Fill(Islemler);

                dataGridView2.DataSource = Islemler;
            }
        }

        
    }
}
            
           

        













    