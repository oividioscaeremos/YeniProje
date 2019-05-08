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
    public partial class LaboratuvarOdemeleriYeni : UserControl
    {

        public LaboratuvarOdemeleriYeni()
        {
            InitializeComponent();
        }
        

        private void closeIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123";
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
                SqlCommand komut = new SqlCommand("INSERT INTO ISLEM(IslemTipiID,Bakiye) Values(" + result[0][0].ToString() + "," + tbUcret.Text +")" , sqlCon);

                komut.ExecuteNonQuery();
            }
            MessageBox.Show("Başarıyla yeni ödeme eklendi.");
            this.Hide();
            
        }


        private void DoktorOdemeleriYeni_Load(object sender, EventArgs e)
        {

        }
    }
}

