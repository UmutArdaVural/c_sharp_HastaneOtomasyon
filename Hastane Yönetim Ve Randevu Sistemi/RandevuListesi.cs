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
    public partial class RandevuListesi : Form
    {
        public RandevuListesi()
        {
            InitializeComponent();
        }

        private void RandevuListesi_MouseDown(object sender, MouseEventArgs e)
        {
            x= e.X; y= e.Y;
        }
        int x, y;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sekreterİşlemler si = new Sekreterİşlemler();
            si.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
        Sqlaglantı sqlaglantı = new Sqlaglantı();

        private void RandevuListesi_Load(object sender, EventArgs e)
        {   DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular ", sqlaglantı.Baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void RandevuListesi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                 return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }
    }
}
