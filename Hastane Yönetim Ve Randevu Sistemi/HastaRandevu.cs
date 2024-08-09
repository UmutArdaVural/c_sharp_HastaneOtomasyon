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
    public partial class HastaRandevu : Form
    {
        public HastaRandevu()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaGiriş aç = new HastaGiriş();

            aç.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }
        int x, y;

        private void HastaRandevu_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }

        private void HastaRandevu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
        Sqlaglantı Sqlaglantı = new Sqlaglantı();

        private void HastaRandevu_Load(object sender, EventArgs e)
        { 
            // kullanıcı bilgisi çekme 
            lbltc.Text = tc;
            SqlCommand sqlCommand = new SqlCommand("Select HastaAd,HastaSoyad From Tbl_Hastalar where HastaTc = @p1 " , Sqlaglantı.Baglantı());
            sqlCommand.Parameters.AddWithValue("@p1", tc);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read()) { 
                
                lbladsoyad.Text = reader[0] +" "+ reader[1];
            }

            Sqlaglantı.Baglantı().Close();


            // kullancıı randevu geçmişi 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTc =" +tc, Sqlaglantı.Baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            // BRANŞLARI ÇEKME 
            SqlCommand sqlCommand2 = new SqlCommand("Select BransAd From Tbl_Branslar ", Sqlaglantı.Baglantı());
            SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
            while (sqlDataReader2.Read()) {

                comboBox2.Items.Add(sqlDataReader2[0]);
            }

            // Doktorları Çekme 

        }
        public string adsoyad, tc;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            SqlCommand sqlCommand3 = new SqlCommand("select DoktorAd,DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1",Sqlaglantı.Baglantı());
            sqlCommand3.Parameters.AddWithValue("@p1",comboBox2.Text);
            SqlDataReader sqlDataReader3 = sqlCommand3.ExecuteReader();

            while (sqlDataReader3.Read())
            { 
                comboBox1.Items.Add(sqlDataReader3[0]+" " + sqlDataReader3[1]);
            }
            Sqlaglantı.Baglantı().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuBrans= '"+comboBox2.Text + "'"+" and RandevuDoktor='"+comboBox1.Text+"' and RandevuDurum=0", Sqlaglantı.Baglantı());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            Sqlaglantı.Baglantı().Close();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                SqlCommand cmd = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3", Sqlaglantı.Baglantı());
                cmd.Parameters.AddWithValue("@p1", tc);
                cmd.Parameters.AddWithValue("@p2", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@p3", textBox1.Text);
                cmd.ExecuteNonQuery();
                Sqlaglantı.Baglantı().Close() ;
                MessageBox.Show("Randevu Kaydınız alınmıştır");
                // kullancıı randevu geçmişi 
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Randevular where HastaTc =" + tc, Sqlaglantı.Baglantı());
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter("Select * From Tbl_Randevular where RandevuBrans= '" + comboBox2.Text + "'" + " and RandevuDoktor='" + comboBox1.Text + "' and RandevuDurum=0", Sqlaglantı.Baglantı());
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
                Sqlaglantı.Baglantı().Close();

            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HastaBilgiGüncelle a = new HastaBilgiGüncelle();
            a.tcno = tc;
            a.Show();

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
