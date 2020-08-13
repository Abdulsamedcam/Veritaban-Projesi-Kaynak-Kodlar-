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
    public partial class ürüngüncelle : Form
    {
        public ürüngüncelle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");


        public void listele(string query)
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

                
                /// MessageBox.Show("Bağlantı Başarılı");
                NpgsqlDataAdapter add = new NpgsqlDataAdapter(query, baglanti);
                DataSet data = new DataSet();
                add.Fill(data);
                dataGridView1.DataSource = data.Tables[0];

            }
            catch (Exception Hata)
            {
                MessageBox.Show("Hata: " + Hata.Message);
            }


        }//Listele Bitiş

      
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komut = new NpgsqlCommand("UPDATE  urunler set  urun_fiyati=@urun_fiyati, kdv=@kdv, fiyat2=@fiyat2, fiyat3=@fiyat3, fiyat4=@fiyat4, urun_aciklama=@urun_aciklama where urun_adi=@urun_adi ", baglanti);
           
             komut.Parameters.AddWithValue("@urun_adi", textBox1.Text);
            if (textBox2.Text != "")
            {
                komut.Parameters.AddWithValue("@urun_fiyati",int.Parse(textBox2.Text));
            }
            else
            {
                komut.Parameters.AddWithValue("@urun_fiyati", DBNull.Value);
            }
            if (textBox3.Text != "")
            {
                komut.Parameters.AddWithValue("@kdv", int.Parse(textBox3.Text));

            }
            else
            {
                komut.Parameters.AddWithValue("@kdv", DBNull.Value);
            }


            if (textBox4.Text != "")
            {
                komut.Parameters.AddWithValue("@fiyat2", int.Parse(textBox4.Text));

            }
            else
            {
                komut.Parameters.AddWithValue("@fiyat2", DBNull.Value);
            }


            if (textBox5.Text != "")
            {
                komut.Parameters.AddWithValue("@fiyat3", int.Parse(textBox5.Text));
            }
            else
            {
                komut.Parameters.AddWithValue("@fiyat3", DBNull.Value);
            }


            if (textBox6.Text != "")
            {
                komut.Parameters.AddWithValue("@fiyat4", int.Parse(textBox6.Text));
            }
            else
            {
                komut.Parameters.AddWithValue("@fiyat4", DBNull.Value);
            }


            komut.Parameters.AddWithValue("@urun_aciklama", textBox7.Text);
            // komut.Parameters.AddWithValue("@sehiri", textBox9.Text);


            komut.ExecuteNonQuery();


            baglanti.Close();
            listele("select * from urunler");
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus(); //imkeç konumlama
        }

        private void ürüngüncelle_Load(object sender, EventArgs e)
        {
            
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili = dataGridView1.SelectedCells[0].RowIndex;

           
            string urun_adi = dataGridView1.Rows[secili].Cells[1].Value.ToString();
            string urun_fiyati = dataGridView1.Rows[secili].Cells[2].Value.ToString();
            string kdv = dataGridView1.Rows[secili].Cells[3].Value.ToString();
            string fiyat2= dataGridView1.Rows[secili].Cells[4].Value.ToString();
            string fiyat3 = dataGridView1.Rows[secili].Cells[5].Value.ToString();
            string fiyat4= dataGridView1.Rows[secili].Cells[6].Value.ToString();
            string urun_aciklama = dataGridView1.Rows[secili].Cells[7].Value.ToString();

            textBox1.Text = urun_adi;
            textBox2.Text = urun_fiyati;
            textBox3.Text =kdv;
            textBox4.Text =fiyat2;
            textBox5.Text = fiyat3;
            textBox6.Text = fiyat4;
            textBox7.Text = urun_aciklama;


        }

        private void ürüngüncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
