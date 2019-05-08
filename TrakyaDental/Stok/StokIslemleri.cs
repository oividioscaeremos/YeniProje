using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TrakyaDental
{

    public partial class StokIslemleri : Form
    {

        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        Point lastLocation;
        public StokIslemleri()
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
                mouseX = MousePosition.X - lastLocation.X;
                mouseY = MousePosition.Y - lastLocation.Y;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private string[] veritabaniDetayCek(string connectionString, string columnName, string from, string whereCol, string whereDat)
        {
            //DataTable stokBilgileri = new DataTable();
            string[] sonuc = new string[20];
            int counter = 0;
            string connStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select " + columnName + " from " + from + " where " + whereCol + "=" + whereDat, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            sonuc[counter] = reader.GetString(counter++);
                        }
                    }
                }
            }
            return sonuc;
        }

        private void pbDetay_Click(object sender, EventArgs e)
        {
            try
            {
                urunDetay1.urunID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                urunDetay1.marka = dataGridView1.SelectedCells[1].Value.ToString();
                urunDetay1.urunGrubu = dataGridView1.SelectedCells[2].Value.ToString();
                int grup = Convert.ToInt32(dataGridView1.SelectedCells[2].Value.ToString());
                urunDetay1.urunAd = dataGridView1.SelectedCells[3].Value.ToString();
                urunDetay1.stokMikter = Convert.ToInt32(dataGridView1.SelectedCells[4].Value.ToString());
                urunDetay1.birim = dataGridView1.SelectedCells[5].Value.ToString();
                urunDetay1.birimFiyat = Convert.ToInt32(dataGridView1.SelectedCells[6].Value.ToString());
                urunDetay1.skt = Convert.ToDateTime(dataGridView1.SelectedCells[7].Value);
                urunDetay1.barkod = dataGridView1.SelectedCells[8].Value.ToString();

                string connStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
                urunDetay1.aciklama = veritabaniDetayCek(connStr, "Grup_Aciklama", "UrunGrup", "GrupID", grup.ToString())[0];
                urunDetay1.Update();
                urunDetay1.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void StokIslemleri_Load(object sender, EventArgs e)
        {
            urunDetay1.Hide();
            stokHareket1.Hide();
            urunEkle1.Hide();
            //Connec
            dataGridView1.DataSource = stokGetir();
        }

        private DataTable stokGetir()
        {
            DataTable stokBilgileri = new DataTable();

            string connStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Stok", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    stokBilgileri.Load(reader);
                }
            }


            return stokBilgileri;
        }

        private void pbStokHareketi_Click(object sender, EventArgs e)
        {
            stokHareket1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var anasayfa = new Form1();
            anasayfa.ShowDialog();
            this.Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            stokHareket1.ID = textBox1.Text;
        }

        private void pbUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                //string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=rootroot;";

                ComboBox urunG = new ComboBox();
                ComboBox markalar = new ComboBox();
                string connStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd = new SqlCommand("Select * from UrunGrup", con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        var number = reader.HasRows;

                        while (reader.Read())
                        {
                            //sonuc[counter] = reader.GetString(counter++);
                            urunG.Items.Add(reader["GrupID"].ToString() + " - " + reader["Grup_Aciklama"]);
                        }
                        con.Close();
                        reader.Close();
                    }
                    using (SqlCommand cmd = new SqlCommand("Select * from Markalar", con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            //sonuc[counter] = reader.GetString(counter++);
                            markalar.Items.Add(reader["MarkaID"].ToString() + " - " + reader["MarkaAd"]);
                        }
                        con.Close();
                        reader.Close();
                    }
                }
                urunEkle1.markalarCB = markalar;
                urunEkle1.urunGrupCB = urunG;
                urunEkle1.Show();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void pbAra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Arama Ekranı Burada Çıkacak.");
        }

        private void urunEkle1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = stokGetir();
        }

        
    }
}
