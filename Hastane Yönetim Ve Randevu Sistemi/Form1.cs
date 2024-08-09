using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Hastane_Yönetim_Ve_Randevu_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string url = "https://x.com/UmutArdaVural";
            OpenUrl(url);
        }
        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("URL açılamadı: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/umut-arda-vural-6b2248219/";
            OpenUrl(url);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int x, y;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y;

        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            this.Left += e.X - x;
            this.Top += e.Y - y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaGiriş aç = new HastaGiriş();

            aç.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoktorGiriş aaaa = new DoktorGiriş();
            aaaa.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SekreterGiriş aösek= new SekreterGiriş();
            aösek.Show(); this.Hide();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x=e.X; y=e.Y;

        }
    }
}
