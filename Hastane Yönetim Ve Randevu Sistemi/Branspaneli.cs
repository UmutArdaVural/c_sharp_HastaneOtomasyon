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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hastane_Yönetim_Ve_Randevu_Sistemi
{
    public partial class Branspaneli : Form
    {
        public Branspaneli()
        {
            InitializeComponent();
        }

        private void Branspaneli_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;   
        }
        int x , y ;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sekreterİşlemler sekreterİşlemler = new Sekreterİşlemler();
            sekreterİşlemler.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1   form = new Form1();
            form.Show() ;
            this.Hide() ;
        }
        Sqlaglantı Sqlaglantı   = new Sqlaglantı();
        private void Branspaneli_Load(object sender, EventArgs e)
        {
            verilerigetir();

        }
        void verilerigetir()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", Sqlaglantı.Baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@p1) ", Sqlaglantı.Baglantı());
                cmd.Parameters.AddWithValue("@p1", txtsoyad.Text);
                cmd.ExecuteNonQuery();
                Sqlaglantı.Baglantı().Close();
                MessageBox.Show("Branş Başarı ile kaydedildi   ");
                verilerigetir();

            }
            catch {
                MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin ");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update Tbl_Branslar set  BransAd=@p1 where Bransid=@p2", Sqlaglantı.Baglantı());
                cmd.Parameters.AddWithValue("@p1", txtsoyad.Text);
                cmd.Parameters.AddWithValue("@p2", txtad.Text);
                

                cmd.ExecuteNonQuery();
                Sqlaglantı.Baglantı().Close();
                MessageBox.Show(txtad.Text + " İdli  Branş Başarı ile güncellendi   ");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", Sqlaglantı.Baglantı());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                verilerigetir();

            }
            catch
            {
                MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin ");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Delete from Tbl_Branslar    where Bransid=@p2", Sqlaglantı.Baglantı());
            cmd.Parameters.AddWithValue("@p2", txtad.Text);
            cmd.ExecuteNonQuery();
            Sqlaglantı.Baglantı().Close();
            MessageBox.Show(txtad.Text + " İdli  Branş Başarı ile Silindi ");
            verilerigetir();

        }

        private void Branspaneli_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x; 
            this.Top += e.Y - y;    
        }
    }
}
