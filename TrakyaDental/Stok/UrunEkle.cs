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
    public partial class UrunEkle : UserControl
    {
        string connStr = "Data Source=.;Initial Catalog=TrakyaDental;User ID=sa; Password=2362123;";
        string[] sonuc = new string[20];
        int mouseX = 0, mouseY = 0;
        bool mouseDown = false;
        Point lastLocation;
        public ComboBox urunGrupCB
        {
            set {
                foreach (string item in value.Items)
                {
                    comboboxUrunGrup.Items.Add(item);
                }
            }
        }

        public ComboBox markalarCB
        {
            set {
                foreach (string item in value.Items)
                {
                    comboboxUrunMarka.Items.Add(item);
                }
            }
        }

        public UrunEkle()
        {
            InitializeComponent();
        }

        private void closeIcon_Click(object sender, EventArgs e)
        {
            /*
                Tablodaki verileri temizliyor, bir sonraki kayıt için daha düzenli bir ortam bırakıyor. 
            */
            tbBarkod.Clear();
            tbBirim.Clear();
            tbBirimFiyat.Clear();
            tbGirisMiktar.Clear();
            tbUrunAd.Clear();
            dateSKT.Value = DateTime.Today;
            this.Hide();
        }


        private void pbUrunEkle_Click(object sender, EventArgs e)
        {
            /*
                Yeni ürün eklemek için yeni bir sqlconnection oluştur
                SqlCommand ile oluşturulan sqlConnection'u kullanarak yeni bir komut oluştur.
            */
            try
            {
                SqlConnection con = new SqlConnection(connStr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Stok(Marka,Urun_Grubu,Urun_Ad,Miktar,Birim,BirimFiyat,SKT,Barkod)" + " values(@UrunMarka,@UrunGrup,@Ad,@Miktar,@Birim,@BirimFiyat,@SKT,@Barkod)", con);
                cmd.Parameters.AddWithValue("@UrunMarka", comboboxUrunMarka.SelectedItem.ToString()[0]);
                cmd.Parameters.AddWithValue("@UrunGrup", comboboxUrunGrup.SelectedItem.ToString()[0]);
                cmd.Parameters.AddWithValue("@Ad", tbUrunAd.Text);
                cmd.Parameters.AddWithValue("@Miktar", tbGirisMiktar.Text);
                cmd.Parameters.AddWithValue("@Birim", tbBirim.Text);
                cmd.Parameters.AddWithValue("@BirimFiyat", tbBirimFiyat.Text);
                cmd.Parameters.AddWithValue("@SKT", dateSKT.Value);
                cmd.Parameters.AddWithValue("@Barkod", tbBarkod.Text);
                SqlCommand insertIntoIslemler = new SqlCommand("Insert into Islem(IslemTipiID,Bakiye) Values(@IslemTipiID,@Bakiye)",con);
                insertIntoIslemler.Parameters.AddWithValue("@IslemTipiID",2);
                insertIntoIslemler.Parameters.AddWithValue("Bakiye",(Convert.ToInt32(tbGirisMiktar.Text)*Convert.ToInt32(tbBirimFiyat.Text)));

                insertIntoIslemler.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                MessageBox.Show("Ürün başarıyla eklendi.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbBarkod.Clear();
                tbBirim.Clear();
                tbBirimFiyat.Clear();
                tbGirisMiktar.Clear();
                tbUrunAd.Clear();
                dateSKT.Value = DateTime.Today;
                this.Hide();
            }
        }

        

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - lastLocation.X;
                mouseY = MousePosition.Y - lastLocation.Y;
                this.SetDisplayRectLocation(mouseX, mouseY);
                //this.SetDesktopLocation(mouseX, mouseY);
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

        private void dateSKT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UrunEkle_Load(object sender, EventArgs e)
        {
            
        }
    }
}
