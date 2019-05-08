using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrakyaDental
{
    public partial class HastaIslemleri : Form
    {

        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        Point lastLocation;
        public HastaIslemleri()
        {
            InitializeComponent();
        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ActiveForm.Dispose();
        }
        
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X -lastLocation.X;
                mouseY = MousePosition.Y - lastLocation.Y;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void formLoad(object sender, EventArgs e)
        {
            hastaEkle1.Hide();
            hastaTedavileri1.Hide();
            pbBackToMainScreen.BringToFront();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var anasayfa = new Form1();
            anasayfa.ShowDialog();
            this.Dispose();
        }

        private void pbHastaEkle_Click(object sender, EventArgs e)
        {
            hastaEkle1.Show();
        }

        private void pbHastaDuzelt_Click(object sender, EventArgs e)
        {
            //tbDosyaNo.Enabled = true;
            tbHastaAdi.Enabled = true;
            tbHastaCinsiyet.Enabled = true;
            tbHastaDogTar.Enabled = true;
           // tbHastaDoktor.Enabled = true;
            tbHastaSoyad.Enabled = true;
            tbHastaTCNO.Enabled = true;
            tbGSM.Enabled = true;
            tbEvTel.Enabled = true;
            tbEmail.Enabled = true;
            tbAdres.Enabled = true;
            btnBitir.Visible = true;
            //DataGriedviewda seçilmiş satır olursa
            if (dataGridView1.SelectedRows.Count!=0)
            {
                string hastaID;
                hastaID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                string conStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                string sql = "Select * from Hasta where HastaID=" + hastaID;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {//Veritabanından seçilen satırdaki verinin hastaId'sini esas alarak textboxlara verinin yazılması sağlanır.
                    tbHastaAdi.Text = dr["HastaAd"].ToString();
                    tbHastaSoyad.Text = dr["HastaSoyad"].ToString();
                    tbHastaTCNO.Text = dr["TCKimlikNo"].ToString();
                    tbHastaDogTar.Text = dr["Dog_Tar"].ToString();
                    tbHastaCinsiyet.Text = dr["Cinsiyet"].ToString();
                    tbGSM.Text = dr["GSM"].ToString();
                    tbEvTel.Text = dr["Ev_Tel"].ToString();
                    tbEmail.Text = dr["Email"].ToString();
                    tbAdres.Text = dr["Adres"].ToString();


                }
            }
            
            
        }

        private void btnBitir_Click(object sender, EventArgs e)
        {
            //tbDosyaNo.Enabled = false;
            tbHastaAdi.Enabled = false;
            tbHastaCinsiyet.Enabled = false;
            tbHastaDogTar.Enabled = false;
           // tbHastaDoktor.Enabled = false;
            tbHastaSoyad.Enabled = false;
            tbHastaTCNO.Enabled = false;
            tbGSM.Enabled = false;
            tbEvTel.Enabled = false;
            tbEmail.Enabled = false;
            tbAdres.Enabled = false;
            btnBitir.Visible = false;

            string conStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string hastaID;
                hastaID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //hastaIdsi seçilen satırdaki hastaId ile aynı olan verinin güncellenmesi sağlanır.
                string sql = "Update Hasta set HastaAd=@ad,HastaSoyad=@soyad,TCKimlikNo=@tc,Dog_Tar=@dt,Cinsiyet=@cinsiyet,GSM=@gsm,Ev_Tel=@evtel,Email=@mail,Adres=@adres where HastaID="+hastaID;
                con.Open();

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    
                    cmd.Parameters.AddWithValue("@ad", tbHastaAdi.Text);
                    cmd.Parameters.AddWithValue("@soyad", tbHastaSoyad.Text);
                    cmd.Parameters.AddWithValue("@tc", tbHastaTCNO.Text);
                    cmd.Parameters.AddWithValue("@dt", tbHastaDogTar.Text);
                    cmd.Parameters.AddWithValue("@cinsiyet", tbHastaCinsiyet.Text);
                    cmd.Parameters.AddWithValue("@gsm", tbGSM.Text);
                    cmd.Parameters.AddWithValue("@evtel", tbEvTel.Text);
                    cmd.Parameters.AddWithValue("@mail", tbEmail.Text);
                    cmd.Parameters.AddWithValue("@adres", tbAdres.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hasta Güncellendi <3 ");
                    con.Close();
                }

            }

        }

        private void pbTedavi_Click(object sender, EventArgs e)
        {
            hastaTedavileri1.Show();
        }

        private void HastaIslemler_Load(object sender, EventArgs e)
        {
            hastaEkle1.Hide();
            hastaTedavileri1.Hide();
            string constr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            SqlConnection con = new SqlConnection(constr);
            con.Open();


            SqlDataAdapter da = new SqlDataAdapter("Select HastaID,HastaAd,HastaSoyad,Cinsiyet,PersonelAd+''+PersonelSoyad as Doktoru from Hasta Inner Join Personel on(Personel.PersonelID=Hasta.PersonelID)", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            //Select RandevuID,HastaAd,HastaSoyad,Tarih,Aciklama from Randevu Inner Join Hasta on(Randevu.HastaID=Hasta.HastaID)"
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            var receteForm = new RecetelerFORM();
            receteForm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var randevuForm = new RandevularFORM();
            randevuForm.ShowDialog();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {  
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
    }
}
