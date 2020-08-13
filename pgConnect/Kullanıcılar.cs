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
    public partial class Kullanıcılar : Form
    {
        public Kullanıcılar()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");


        int kullanici_id;
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

        public void ResetAllControls()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listele("select * from kullanicilar");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //NpgsqlCommand komut = new NpgsqlCommand("insert into kullanicilar(isim,soyisim, kullanici_adi, sifre, kullanici_group) values (@isim,@soyisim, @kullanici_adi, @sifre, @kullanici_group)", baglanti);
                 NpgsqlCommand komut = new NpgsqlCommand("insert into kisiler(kisi_adi,kisi_soyadi) values (@kisi_adi, @kisi_soyadi) returning kisi_id", baglanti);

            komut.Parameters.AddWithValue("@kisi_adi", textBox2.Text);
            komut.Parameters.AddWithValue("@kisi_soyadi", textBox3.Text);            
            int  kisi_id =  (int)komut.ExecuteScalar();

            NpgsqlCommand kullanicikomut = new NpgsqlCommand("insert into kullanicilar ( kisi_id, kullanici_adi, sifre,kullanici_group) values (@kisi_id,  @kullanici_adi, @sifre,@kullanici_group)", baglanti);
            kullanicikomut.Parameters.AddWithValue("@kisi_id", kisi_id);
            kullanicikomut.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
            kullanicikomut.Parameters.AddWithValue("@sifre", textBox5.Text);
            kullanicikomut.Parameters.AddWithValue("@kullanici_group", int.Parse(textBox1.Text));
            //kullanicikomut.Parameters.AddWithValue("@kullanici_group", int.Parse(textBox1.Text));
            kullanicikomut.ExecuteNonQuery();



            listele("select * from kullanicilar inner join kisiler on kisiler.kisi_id = kullanicilar.kisi_id");

            MessageBox.Show("başarılı");



        }

        private void Kullanıcılar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
        }

        private void Kullanıcılar_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            listele("select * from kullanicilar order by kullanici_adi desc limit 10");
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                kullanici_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            NpgsqlCommand komut = new NpgsqlCommand("UPDATE kullanicilar set  kullanici_adi=@kullanici_adi,sifre=@sifre, kullanici_group=@kullanici_group  where kullanici_id=@kullanici_id ", baglanti);


            komut.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
          
            komut.Parameters.AddWithValue("@sifre",textBox5.Text);
            komut.Parameters.AddWithValue("@kullanici_group", int.Parse(textBox1.Text));

            komut.Parameters.AddWithValue("@kullanici_id", kullanici_id);



            komut.ExecuteNonQuery();
            listele("select* from kullanicilar");
            MessageBox.Show("başarılı");


        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                kullanici_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            NpgsqlCommand komut = new NpgsqlCommand("delete from kullanicilar where kullanici_adi=@kullanici_adi", baglanti);
            komut.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
            komut.ExecuteNonQuery();


            listele("select * from kullanicilar");
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

            String ara = textBox4.Text;

            listele("select * from kullanicilar  where kullanici_adi  ilike  '%" + ara + "%' ");
        }
    }
    }




    
