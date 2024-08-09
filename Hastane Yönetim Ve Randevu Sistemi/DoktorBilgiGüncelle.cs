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
    public partial class DoktorBilgiGüncelle : Form
    {
        public DoktorBilgiGüncelle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorBilgiFormu a = new DoktorBilgiFormu();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        int x,y;

        private void DoktorBilgiGüncelle_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();  
            form1.Show();
            this.Hide();
        }

        private void btngiris_Click(object sender, EventArgs e)
        {
           /* SqlCommand sqlCommand1 = new SqlCommand("update Tbl_Doktorlar set  HastaAd=@p1,HastaSoyad=@p2,HastaTc=@p3,HastaTelefon=@p4,HastaSifre=@p5, HastaCinsiyet=@p6 where HastaTc=@tc", Sqlaglantı.Baglantı());
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
            this.Hide();*/
        }

        private void DoktorBilgiGüncelle_MouseDown(object sender, MouseEventArgs e)
        {
            x=e.X; y=e.Y;   

        }
    }
}
