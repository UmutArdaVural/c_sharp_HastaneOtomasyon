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

namespace Hastane_Yönetim_Ve_Randevu_Sistemi
{
    public partial class HastaGiriş : Form
    {
        public HastaGiriş()
        {
            InitializeComponent();
        }
        int x, y;

        private void HastaGiriş_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaÜyeOl aç = new HastaÜyeOl();

            aç.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaÜyeOl aç = new HastaÜyeOl();

            aç.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        Sqlaglantı sqlaglantı = new Sqlaglantı();

        private void btngiris_Click(object sender, EventArgs e)
        {
            SqlCommand komutumuz = new SqlCommand("SELECT * FROM Tbl_Hastalar WHERE HastaTc = @tc and HastaSifre =@sifre", sqlaglantı.Baglantı());
            komutumuz.Parameters.AddWithValue("@tc",txtmsktc.Text);
            komutumuz.Parameters.AddWithValue("@sifre", txtsifre.Text);
            
            SqlDataReader dr = komutumuz.ExecuteReader();   
            if (dr.Read())
            {   
                
                HastaRandevu hastaRandevu = new HastaRandevu();
                hastaRandevu.tc = txtmsktc.Text;
                hastaRandevu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgiler ");
            }
            sqlaglantı.Baglantı().Close();
           
        }

        private void HastaGiriş_Load(object sender, EventArgs e)
        {

        }

        private void HastaGiriş_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
