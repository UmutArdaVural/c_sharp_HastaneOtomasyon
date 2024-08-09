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
    public partial class DoktorGiriş : Form
    {
        public DoktorGiriş()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show(); this.Hide();
        }
        int x ,y ;

        private void DoktorGiriş_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }

        private void DoktorGiriş_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show(); this.Hide();
        }
        Sqlaglantı Sqlaglantı = new Sqlaglantı();

        private void btngiris_Click(object sender, EventArgs e)
        {
            try {

                SqlCommand sqlCommand = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTc=@p1 and DoktorSifre=@p2 ", Sqlaglantı.Baglantı());
                sqlCommand.Parameters.AddWithValue("@p1",txtmsktc.Text);
                sqlCommand.Parameters.AddWithValue("@p2", txtsifre.Text);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read()) { DoktorBilgiFormu aç = new DoktorBilgiFormu(); aç.tc = txtmsktc.Text;
                    aç.Show(); this.Hide();
                }
                else { MessageBox.Show("Hatalı Bilgiler  "); }
                Sqlaglantı.Baglantı().Close();
            }
            
           catch { MessageBox.Show("Hata "); }
        }

        private void DoktorGiriş_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }
    }
}
