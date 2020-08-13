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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");

        int kategori_id;
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

        private void button4_Click(object sender, EventArgs e)
        {
            listele("select * from kategori ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand komut = new NpgsqlCommand("insert into kategori(kategori_adi,alt_kategori) values (@kategori_adi,@alt_kategori)", baglanti);

            komut.Parameters.AddWithValue("@kategori_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@alt_kategori",int.Parse(textBox2.Text));
            


            komut.ExecuteNonQuery();
            listele("select * from kategori order by kategori_adi desc limit 10");

            MessageBox.Show("başarılı");

        }


        private void Kategori_Load(object sender, EventArgs e)
        {

            baglanti.Open();
        }
        private void Kategori_FormClosed(object sender, FormClosedEventArgs e)
        {

            baglanti.Close();


        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            listele("select * from kategori order by kategori_id desc limit 10");
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


            try
            {
                kategori_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();








            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            NpgsqlCommand komut = new NpgsqlCommand("UPDATE kategori set  kategori_adi=@kategori_adi,alt_kategori=@alt_kategori where kategori_id=@kategori_id ", baglanti);


            komut.Parameters.AddWithValue("@kategori_adi", textBox1.Text);
            komut.Parameters.AddWithValue("@alt_kategori",int.Parse( textBox2.Text));
            komut.Parameters.AddWithValue("@kategori_id", kategori_id);



            komut.ExecuteNonQuery();
            listele("select* from kategori");
            MessageBox.Show("başarılı");


        }
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                kategori_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            NpgsqlCommand komut = new NpgsqlCommand("delete from kategori where Kategori_adi=@Kategori_adi", baglanti);
            komut.Parameters.AddWithValue("@Kategori_adi", textBox1.Text);
            

            komut.ExecuteNonQuery();


            listele("select * from kategori");
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

            listele("select * from kategori  where kategori_adi  ilike  '%" + ara + "%' ");
        }

       
    }
    }

