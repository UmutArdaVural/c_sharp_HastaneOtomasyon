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
    public partial class SekreterGiriş : Form
    {
        public SekreterGiriş()
        {
            InitializeComponent();
        }

        private void SekreterGiriş_MouseDown(object sender, MouseEventArgs e)
        {
            x=e.X; y=e.Y;
        }
        int x, y;

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

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
            SqlCommand sqlCommand = new SqlCommand("Select * From Tbl_Sekreter where SekreterTc=@p1 and SekreterSifre=@p2 ",sqlaglantı.Baglantı());

            sqlCommand.Parameters.AddWithValue("@p1", txtmsktc.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtsifre.Text);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {               
                Sekreterİşlemler Sekreter = new Sekreterİşlemler();
                Sekreter.tc = Convert.ToString(txtmsktc.Text);;
                Sekreter.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş ");
            }
            sqlaglantı.Baglantı().Close();

        }

        private void SekreterGiriş_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return; 
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
