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
    public partial class Duyurular : Form
    {
        public Duyurular()
        {
            InitializeComponent();
        }
        int x, y;

        private void Duyurular_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left )
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorBilgiFormu aaaaa = new DoktorBilgiFormu();
            aaaaa.Show();
            this.Hide();
        }
        Sqlaglantı Sqlaglantı = new Sqlaglantı();
        private void Duyurular_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Duyurular ", Sqlaglantı.Baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Duyurular_MouseDown(object sender, MouseEventArgs e)
        {
            x=e.X; y=e.Y;   

        }
    }
}
