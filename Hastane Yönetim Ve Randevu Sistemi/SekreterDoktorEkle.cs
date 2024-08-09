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

namespace Hastane_Yönetim_Ve_Randevu_Sistemi
{
    public partial class SekreterDoktorEkle : Form
    {
        public SekreterDoktorEkle()
        {
            InitializeComponent();
        }

        private void SekreterDoktorEkle_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }

        int x,y;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

                }

        private void button1_Click(object sender, EventArgs e)
        {
            Sekreterİşlemler aq = new Sekreterİşlemler();
            aq.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        Sqlaglantı Sqlaglantı = new Sqlaglantı();
        private void SekreterDoktorEkle_Load(object sender, EventArgs e)
        {
            // doktorları tabloya koyma 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", Sqlaglantı.Baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // bransları tabloya koyma 

            SqlCommand cmd = new SqlCommand("Select * From Tbl_Branslar", Sqlaglantı.Baglantı());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[1]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5) ", Sqlaglantı.Baglantı());
                cmd.Parameters.AddWithValue("@p1", txtad.Text);
                cmd.Parameters.AddWithValue("@p2", txtsoyad.Text);
                cmd.Parameters.AddWithValue("@p3", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@p4", txtmsktc.Text);
                cmd.Parameters.AddWithValue("@p5", txtsifre.Text);
                cmd.ExecuteNonQuery();
                Sqlaglantı.Baglantı().Close();
                MessageBox.Show("Doktor Başarı ile kaydedildi   ");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", Sqlaglantı.Baglantı());
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch {

                MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin ");

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtmsktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Delete from Tbl_Doktorlar where DoktorTc=@p1 ", Sqlaglantı.Baglantı());
                if (txtmsktc.Text !="") {
                    cmd.Parameters.AddWithValue("@p1", txtmsktc.Text);
                    cmd.ExecuteNonQuery();
                    Sqlaglantı.Baglantı().Close();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", Sqlaglantı.Baglantı());
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Doktor Başarı ile silindi   ");
                }

            }
            catch {
                MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin ");

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Update Tbl_Doktorlar set  DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5", Sqlaglantı.Baglantı());
                cmd.Parameters.AddWithValue("@p1", txtad.Text);
                cmd.Parameters.AddWithValue("@p2", txtsoyad.Text);
                cmd.Parameters.AddWithValue("@p3", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@p4", txtsifre.Text);
                cmd.Parameters.AddWithValue("@p5", txtmsktc.Text);

                cmd.ExecuteNonQuery();
                Sqlaglantı.Baglantı().Close();
                MessageBox.Show(txtmsktc.Text + " Tcli Doktor Başarı ile güncellendi   ");
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", Sqlaglantı.Baglantı());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch {
                MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin ");

            }
        }

        private void SekreterDoktorEkle_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;
        }
    }
}
