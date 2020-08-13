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
using System.Data.SqlClient;
using NpgsqlTypes;
namespace pgConnect
{
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");
        int urun_id;
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

        private void button2_Click(object sender, EventArgs e)
        {
            listele("select * from urunler ");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("insert into urunler(urun_adi,urun_fiyati, kdv, fiyat2, fiyat3, fiyat4, urun_aciklama) values (@urun_adi,@urun_fiyati, @kdv, @fiyat2, @fiyat3, @fiyat4, @urun_aciklama)", baglanti);

            komut.Parameters.AddWithValue("@urun_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@urun_fiyati", int.Parse(textBox2.Text));
            komut.Parameters.AddWithValue("@kdv", int.Parse(textBox3.Text));
            komut.Parameters.AddWithValue("@fiyat2", int.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@fiyat3", int.Parse(textBox5.Text));
            komut.Parameters.AddWithValue("@fiyat4", int.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@urun_aciklama", textBox7.Text);



            komut.ExecuteNonQuery();
            listele("select * from urunler order by urun_adi desc limit 10");

            MessageBox.Show("başarılı");



        }

        private void urunekle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
        }

        private void urunekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            listele("select * from musteri order by musteri_no desc limit 10");
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                urun_id= int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

                

              
               


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {


            NpgsqlCommand komut = new NpgsqlCommand("UPDATE urunler set  urun_adi=@urun_adi,urun_fiyati=@urun_fiyati, kdv=@kdv, fiyat2=@fiyat2, fiyat3=@fiyat3, fiyat4=@fiyat4, urun_aciklama=@urun_aciklama where urun_id=@urun_id ", baglanti);


            komut.Parameters.AddWithValue("@urun_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@urun_fiyati", Double.Parse(textBox2.Text));
            komut.Parameters.AddWithValue("@kdv", Double.Parse(textBox3.Text));
            komut.Parameters.AddWithValue("@fiyat2", Double.Parse(textBox4.Text));
            komut.Parameters.AddWithValue("@fiyat3", Double.Parse(textBox5.Text));
            komut.Parameters.AddWithValue("@fiyat4", Double.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@urun_aciklama", textBox7.Text);
            komut.Parameters.AddWithValue("@urun_id", urun_id);



            komut.ExecuteNonQuery();
            listele("select* from urunler");
            MessageBox.Show("başarılı");




        }

        private void button4_Click(object sender, EventArgs e)
        {

           

                try
                {
                    urun_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                  

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            NpgsqlCommand komut = new NpgsqlCommand("delete from urunler where urun_adi=@urun_adi", baglanti);
            komut.Parameters.AddWithValue("@urun_adi", textBox1.Text);
            komut.ExecuteNonQuery();

            
            listele("select * from urunler");
            textBox1.Clear();
            MessageBox.Show("Silme Başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Arama alanını boş bırakmayın");
                return;
            }

            String ara = textBox1.Text;

            listele("select * from urunler  where urun_adi  ilike  '%" + ara + "%' ");
        }
    }
}

    
    

    
    

   
       

   

      

            
