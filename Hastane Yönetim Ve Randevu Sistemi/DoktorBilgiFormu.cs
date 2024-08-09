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
    public partial class DoktorBilgiFormu : Form
    {
        public DoktorBilgiFormu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorGiriş a = new DoktorGiriş();
            a.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 aa = new Form1(); 
            aa.Show();
            this.Hide();    
        }

        private void DoktorBilgiFormu_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }
        int x,y;
        public string tc;
        private void DoktorBilgiFormu_Load(object sender, EventArgs e)
        {
               
            lbltc.Text = tc;
           // doktor bilgisi çekme 

                SqlCommand cmd = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTc=@p1", Sqlaglantı.Baglantı());
                  cmd.Parameters.AddWithValue("@p1", tc);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                lbladsoyad.Text = dr[1]+" "+dr[2];
                }
            Sqlaglantı.Baglantı().Close();
                // randevular
                DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Randevuid,RandevuTarih,RandevuSaat,RandevuDoktor,RandevuDurum,HastaSikayet From Tbl_Randevular where RandevuDoktor = @RandevuDoktor", Sqlaglantı.Baglantı());
            da.SelectCommand.Parameters.AddWithValue("@RandevuDoktor", lbladsoyad.Text);

            da.Fill(dt);
            dataGridView1.DataSource = dt;   
        }

        private void button5_Click(object sender, EventArgs e)
        {
           DoktorBilgiGüncelle aç = new DoktorBilgiGüncelle();
            aç.Show();
            this.Hide();
        }
        Sqlaglantı Sqlaglantı = new Sqlaglantı();

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoktorBilgiGüncelle aç = new DoktorBilgiGüncelle();
            aç.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void DoktorBilgiFormu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
