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
    public partial class PersonelBilgileri : UserControl
    {
        public PersonelBilgileri()
        {
            InitializeComponent();
        }
        

        private void PersonelBilgileri_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
           
            
            SqlDataAdapter da = new SqlDataAdapter("Select PersonelID,PersonelAd,PersonelSoyad,Unvan,Maas from Personel", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
