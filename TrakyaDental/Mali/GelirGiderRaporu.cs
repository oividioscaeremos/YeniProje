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
    public partial class GelirGiderRaporu : UserControl
    {
        string connectionString = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123";
        public GelirGiderRaporu()
        {
            InitializeComponent();
        }

        private void GelirGiderRaporu_Load(object sender, EventArgs e)
        {
            /*
             * Yeni bir SQL bağlantısı oluştur.
             * Kullanacağın tablonun ismini  tanımla.
             * Yeni bir SQL Adapter oluşturarak hangi veriyi çekeceğini SQL sorgusu yazarak bul.
             * Veritabanını ve içindeki tablolarıyla birlikte uygulamana bağla.
             * DataGridView e aktarıp çıktılarını uygulamana yansıt.*/
            using (SqlConnection sqlCon = new SqlConnection(connectionString)) { 
                sqlCon.Open();
            
            DataTable Islemler = new DataTable();
            SqlDataAdapter islemAdapter = new SqlDataAdapter("SELECT * FROM Islem ", sqlCon);
            islemAdapter.Fill(Islemler);

            dataGridView1.DataSource = Islemler;
        }
    }


}
}
