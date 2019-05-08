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
    public partial class PersonelOdemeleri : UserControl
    {
        public PersonelOdemeleri()
        {
            InitializeComponent();
        }
        private DataTable PersonelOdemeleriGetir()
        {
            DataTable odemeBilgileri = new DataTable();
            string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Islem" , con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    odemeBilgileri.Load(reader);
                }
            }
            return odemeBilgileri;
        }

        private void PersonelOdemeleri_Load(object sender, EventArgs e)
        {         
            dataGridView1.DataSource = PersonelOdemeleriGetir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = PersonelOdemeleriGetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
