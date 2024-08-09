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
    public partial class Sekreterİşlemler : Form
    {
        public Sekreterİşlemler()
        {
            InitializeComponent();
        }

        private void Sekreterİşlemler_MouseDown(object sender, MouseEventArgs e)
        {
             x = e.X;  y = e.Y;   
        }
        int x, y;

        private void button8_Click(object sender, EventArgs e)
        {
            SekreterDoktorEkle a = new SekreterDoktorEkle();
            a.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Branspaneli aöl = new Branspaneli();    
            aöl.Show(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RandevuListesi açç = new RandevuListesi();
            açç.Show(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SekreterGiriş am = new SekreterGiriş();
            am.Show(); this.Hide();
        }
        public string tc;
        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        Sqlaglantı sqlaglantı = new Sqlaglantı();
        private void Sekreterİşlemler_Load(object sender, EventArgs e)
        {

            // SEKRETER BİLGİSİ AKTARMA 
            lbltc.Text =tc.ToString() ;
            
            SqlCommand sqlCommand = new SqlCommand("Select SekreterAdSoyad  From Tbl_Sekreter where SekreterTc = @p1", sqlaglantı.Baglantı());
            sqlCommand.Parameters.AddWithValue("@p1", tc);

            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                lbladsoyad.Text = reader[0].ToString();

            }
            sqlaglantı.Baglantı().Close();


            //BRANŞLARI DATAGRİEWVİEW AKTARMA 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar ", sqlaglantı.Baglantı());
            da.Fill(dt);
            sqlaglantı.Baglantı().Close() ;
            dataGridView1.DataSource = dt;

            //Doktorları DATAGRİEWVİEW AKTARMA 
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' '+DoktorSoyad)as'Doktorlar',DoktorBrans from Tbl_Doktorlar ", sqlaglantı.Baglantı());
            da2.Fill(dt2);
            sqlaglantı.Baglantı().Close();
            dataGridView2.DataSource = dt2;

            // BRANŞLARI ATAMA 
            SqlCommand sqlCommandsave = new SqlCommand("Select * from Tbl_Branslar ", sqlaglantı.Baglantı());
            SqlDataReader sqlDataReader = sqlCommandsave.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox1.Items.Add(sqlDataReader[1].ToString());
            }
            sqlaglantı.Baglantı().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {   bool randevudolumu= false;
            try
            {
                SqlCommand sqlCommandsave = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor,RandevuDurum) values (@r1,@r2,@r3,@r4,@r5) ", sqlaglantı.Baglantı());
                sqlCommandsave.Parameters.AddWithValue("@r1", maskedTextBox1.Text);
                sqlCommandsave.Parameters.AddWithValue("@r2", maskedTextBox2.Text);
                sqlCommandsave.Parameters.AddWithValue("@r3", comboBox1.SelectedItem);
                sqlCommandsave.Parameters.AddWithValue("@r4", comboBox2.SelectedItem);
                sqlCommandsave.Parameters.AddWithValue("@r5", randevudolumu);

                sqlCommandsave.ExecuteNonQuery();
                sqlaglantı.Baglantı().Close();
                MessageBox.Show("Randevu Başarı ile kaydedildi   ");

            }
            catch { MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin "); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string Brans = comboBox1.SelectedItem.ToString();
            SqlCommand bransdoktorgetir = new SqlCommand("Select * from Tbl_Doktorlar where DoktorBrans=@p1 ", sqlaglantı.Baglantı());
            bransdoktorgetir.Parameters.AddWithValue("@p1",Brans);
            SqlDataReader dataReader = bransdoktorgetir.ExecuteReader();
            while (dataReader.Read())
            {
                comboBox2.Items.Add(dataReader[1].ToString()+" "+dataReader[2].ToString());
            }
            sqlaglantı.Baglantı().Close();

        }

        private void btngiris_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand sqlCommand = new SqlCommand("insert into  Tbl_Duyurular (DuyuruIcerigi) values(@p1) ", sqlaglantı.Baglantı());
            sqlCommand.Parameters.AddWithValue("@p1", richTextBox1.Text);
            sqlCommand.ExecuteNonQuery();
            sqlaglantı.Baglantı().Close();
                MessageBox.Show("Duyuru Başarı ile kaydedildi   ");
            }
            catch { MessageBox.Show("Hatayla karşılaşıldı Lütfen  tekrar deneyin "); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            //BRANŞLARI DATAGRİEWVİEW AKTARMA 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar ", sqlaglantı.Baglantı());
            da.Fill(dt);
            sqlaglantı.Baglantı().Close();
            dataGridView1.DataSource = dt;

            //Doktorları DATAGRİEWVİEW AKTARMA 
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' '+DoktorSoyad)as'Doktorlar',DoktorBrans from Tbl_Doktorlar ", sqlaglantı.Baglantı());
            da2.Fill(dt2);
            sqlaglantı.Baglantı().Close();
            dataGridView2.DataSource = dt2;

            // BRANŞLARI ATAMA 
            SqlCommand sqlCommandsave = new SqlCommand("Select * from Tbl_Branslar ", sqlaglantı.Baglantı());
            SqlDataReader sqlDataReader = sqlCommandsave.ExecuteReader();
            while (sqlDataReader.Read())
            {
                comboBox1.Items.Add(sqlDataReader[1].ToString());
            }
            sqlaglantı.Baglantı().Close();
        }

       
        private void Sekreterİşlemler_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
