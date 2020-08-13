using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace pgConnect
{
    public partial class ürün_sil : Form
    {
        public ürün_sil()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");
        DataTable tablo = new DataTable();
        NpgsqlDataAdapter adtr = new NpgsqlDataAdapter();
        NpgsqlCommand komut = new NpgsqlCommand();
         void listele(string query)
        {
           
            try
            {

                //Eğer bağlantı yoksa bağlantıyı aç

                if (baglanti.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Açık");

                }
                else
                {
                    //MessageBox.Show("Kapalı");
                    //baglanti.Open();
                }
                tablo.Clear();
                baglanti.Open();
                /// MessageBox.Show("Bağlantı Başarılı");
            NpgsqlDataAdapter adtr = new NpgsqlDataAdapter("select *from urunler",baglanti);
           
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
                adtr.Dispose();
                baglanti.Close();


        }

            catch (Exception Hata)
            {
                MessageBox.Show("Hata: " + Hata.Message);
            }


        }//Listele Bitiş

        private void ürün_sil_Load(object sender, EventArgs e)
        {
            listele("select * from urunler");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Silmek işlemi için Ürün adını girin");
            baglanti.Open();
            NpgsqlCommand komut =new NpgsqlCommand ("delete from urunler where urun_adi=@urun_adi",baglanti);
            komut.Parameters.AddWithValue("@urun_adi", textBox1.Text);
            komut.ExecuteNonQuery();
            
            baglanti.Close();
            listele("select *from urunler where urun_adi");
            textBox1.Clear();
        }
    }
}
