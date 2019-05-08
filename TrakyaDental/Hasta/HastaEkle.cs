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

namespace TrakyaDental.Hasta
{
    public partial class HastaEkle : UserControl
    {
        public HastaEkle()
        {
            InitializeComponent();
        }

        private void closeIcon_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addIcon_Click(object sender, EventArgs e)
        {
            int persId =1;
            string ad = (tbAd.Text).ToString();
            string soyad = (tbSoyad.Text).ToString();
            string tc = (tbTCKimlikNo.Text).ToString();
            DateTime dt = dateTimePicker1.Value;
            string cinsiyet = "1";
            string doktoru = doctorsList.SelectedItem.ToString();
            string[] adSoyad = doktoru.Split(' ');
            string conStr1 = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(conStr1))
            {

                string str = "Select PersonelID from Personel  where PersonelAd=@PersonelAd and PersonelSoyad=@PersonelSoyad";
                //  + doktoru.Split(' ')[0]+",PersonelSoyad="+doktoru.Split(' ')[1]

                SqlCommand cmd1 = new SqlCommand(str, con);
                cmd1.Parameters.AddWithValue("@PersonelAd", doktoru.Split(' ')[0].ToString());
                cmd1.Parameters.AddWithValue("@PersonelSoyad", doktoru.Split(' ')[1].ToString());
                SqlDataReader dr;
                con.Open();

                dr = cmd1.ExecuteReader();
                while (dr.Read())
                {
                   persId = dr.GetInt32(dr.GetOrdinal("PersonelID"));
                }
            };

            
            string dosyaNo = (tbDosyaNo.Text).ToString();
           string gsm = (tbGSM.Text).ToString();
           string evTel = (tbEvTel.Text).ToString();
            string mail = (tbEmailAdres.Text).ToString();
           string adres = (textBox1.Text).ToString();
       
          
            
            

            RadioButton radioBtn = this.Controls.OfType<RadioButton>()
                                       .Where(x => x.Checked).FirstOrDefault();
            if (radioBtn != null)
            {
                
                switch (radioBtn.Name)
                {
                     case"rbKadin":
                        cinsiyet = "Kadın";
                        break;
                     case"rbErkek": cinsiyet = "Erkek";
                        break;
                     case"rbDiger": cinsiyet = "Diğer";
                        break;

                }
            }


            string conStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = "Insert into Hasta (PersonelID,HastaAd,HastaSoyad,TCKimlikNo,Dog_Tar,Cinsiyet,GSM,Ev_Tel,Email,Adres) values(@persID,@ad,@soyad,@tc,@dt,@cinsiyet,@gsm,@evtel,@mail,@adres)";
                con.Open();
                
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@persID", persId);
                    cmd.Parameters.AddWithValue("@ad", ad);
                    cmd.Parameters.AddWithValue("@soyad", soyad);
                    cmd.Parameters.AddWithValue("@tc", tc);
                    cmd.Parameters.AddWithValue("@dt", dt);
                    cmd.Parameters.AddWithValue("@cinsiyet",cinsiyet);
                    cmd.Parameters.AddWithValue("@gsm", gsm);
                    cmd.Parameters.AddWithValue("@evtel", evTel);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@adres", adres);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hasta kaydedildi <3 ");
                    con.Close();
                }

            }
        }

        private void HastaEkle_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=.;Initial Catalog=TrakyaDental;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string sql = "Select PersonelAd+' '+PersonelSoyad as Doktoru from Personel";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr;

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                doctorsList.Items.Add(dr["Doktoru"]);
                
            }
            
        }
    }
          
    
}
