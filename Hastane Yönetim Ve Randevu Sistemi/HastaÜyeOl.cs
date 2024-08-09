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
    public partial class HastaÜyeOl : Form
    {
        public HastaÜyeOl()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }
        int x,y;

        private void HastaÜyeOl_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }

        private void HastaÜyeOl_MouseMove(object sender, MouseEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            HastaGiriş aça = new HastaGiriş();
            aça.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();  
            form1.Show();   
            this.Hide();
        }

        private void HastaÜyeOl_Load(object sender, EventArgs e)
        {

        }
        Sqlaglantı sqlaglantı = new Sqlaglantı();

        private void btngiris_Click(object sender, EventArgs e)
        {    bool tcvarmı = false;

            SqlCommand checkTcCommand = new SqlCommand("SELECT COUNT(*) FROM Tbl_Hastalar WHERE HastaTc = @tc", sqlaglantı.Baglantı());
            checkTcCommand.Parameters.AddWithValue("@tc", txtmsktc.Text);

            int count = (int)checkTcCommand.ExecuteScalar();
            if (count != 0)
            {
                tcvarmı = true;
            }
            sqlaglantı.Baglantı().Close();

            if (tcvarmı == false) {
                if (txtad.Text != "" && txtmaskettel.Text != "" && txtmsktc.Text != "" && txtsifre.Text != "" && txtsoyad.Text != "" && cmbcinsiyet.SelectedIndex != -1)
                {
                    SqlCommand komutumuz = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6) ", sqlaglantı.Baglantı());
                    komutumuz.Parameters.AddWithValue("@p1", txtad.Text);
                    komutumuz.Parameters.AddWithValue("@p2", txtsoyad.Text);
                    komutumuz.Parameters.AddWithValue("@p3", txtmsktc.Text);
                    komutumuz.Parameters.AddWithValue("@p4", txtmaskettel.Text);
                    komutumuz.Parameters.AddWithValue("@p5", txtsifre.Text);
                    komutumuz.Parameters.AddWithValue("@p6", cmbcinsiyet.SelectedItem);
                    komutumuz.ExecuteNonQuery();
                    sqlaglantı.Baglantı().Close();

                    MessageBox.Show("Kaydınız Gerçekleşmişdir Şifreniz :  "+ txtsifre.Text ,"Kayıt Bilgilendirmesi ",MessageBoxButtons.OK,MessageBoxIcon.Information);



                }
            }
            else
            {
                MessageBox.Show("Bu TC numarasına sahip kişi zaten sistemde kayıtlı bulunmaktadır ");
                
            }
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
