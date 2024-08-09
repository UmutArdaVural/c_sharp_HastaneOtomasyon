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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Hastane_Yönetim_Ve_Randevu_Sistemi
{
    public partial class HastaBilgiGüncelle : Form
    {
        public HastaBilgiGüncelle()
        {
            InitializeComponent();
        }

        private void HastaBilgiGüncelle_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }

        int x,y;
        public string tcno;
        Sqlaglantı Sqlaglantı = new Sqlaglantı();
        private void HastaBilgiGüncelle_Load(object sender, EventArgs e)
        {   


            SqlCommand sqlCommand1   = new SqlCommand("select HastaAd,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet from Tbl_Hastalar where HastaTc=@p1", Sqlaglantı.Baglantı());
            sqlCommand1.Parameters.AddWithValue("@p1", tcno);
            SqlDataReader sqlDataReader3 = sqlCommand1.ExecuteReader();
            string cinsiyet;
            while (sqlDataReader3.Read())
            {
               txtad.Text= sqlDataReader3[0].ToString();
                txtsoyad.Text = sqlDataReader3[1].ToString();
                txtmsktc.Text = sqlDataReader3[2].ToString();
                txtmaskettel.Text = sqlDataReader3[3].ToString();
                txtsifre.Text = sqlDataReader3[4].ToString();
                cinsiyet = sqlDataReader3[5].ToString();
                if (cinsiyet == "Erkek")
                {
                    cmbcinsiyet.SelectedIndex = 0;
                }
                else
                {
                    cmbcinsiyet.SelectedIndex = 1;

                }

            }
            txtmsktc.Enabled = false;
            Sqlaglantı.Baglantı().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             HastaRandevu hastaRandevu = new HastaRandevu();
            hastaRandevu.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();  
            form1.Show();
            this.Hide();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            if (txtad.Text != "" && txtmaskettel.Text != "" && txtmsktc.Text != "" && txtsifre.Text != "" && txtsoyad.Text != "" && cmbcinsiyet.SelectedIndex != -1)
            {
                SqlCommand sqlCommand1 = new SqlCommand("update Tbl_Hastalar set  HastaAd=@p1,HastaSoyad=@p2,HastaTc=@p3,HastaTelefon=@p4,HastaSifre=@p5, HastaCinsiyet=@p6 where HastaTc=@tc", Sqlaglantı.Baglantı());
                sqlCommand1.Parameters.AddWithValue("@tc", tcno);
                sqlCommand1.Parameters.AddWithValue("@p1", txtad.Text);
                sqlCommand1.Parameters.AddWithValue("@p2", txtsoyad.Text);
                sqlCommand1.Parameters.AddWithValue("@p3", txtmsktc.Text);
                sqlCommand1.Parameters.AddWithValue("@p4", txtmaskettel.Text);
                sqlCommand1.Parameters.AddWithValue("@p5", txtsifre.Text);
                sqlCommand1.Parameters.AddWithValue("@p6", cmbcinsiyet.SelectedItem);
                sqlCommand1.ExecuteNonQuery();
                Sqlaglantı.Baglantı().Close();
                MessageBox.Show("Güncelleme Başarılı ");
                this.Hide();
            }
        }

        private void HastaBilgiGüncelle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
