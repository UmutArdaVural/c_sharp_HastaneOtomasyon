using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Hastane_Yönetim_Ve_Randevu_Sistemi
{
    internal class Sqlaglantı
    {
        public SqlConnection Baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=UMUTARDAVURAL\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True; TrustServerCertificate=True");
            baglan.Open();
            return baglan;
        }
    }
}
