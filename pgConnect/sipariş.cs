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
    public partial class sipariş : Form
    {
        public sipariş()
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


       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int siparis_id;
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into siparisler (musteri_id, aciklama) values(@musteri_id, @aciklama) returning siparis_id", baglanti);


            //int sayi = Convert.ToInt32(rakam);
            //komut.Parameters.AddWithValue("@no", r);

            
            if (textBox1.Text == "") {
                MessageBox.Show("Müşteri Seçin");
                return;
            }

            komut.Parameters.AddWithValue("@musteri_id", int.Parse(textBox1.Text));
            komut.Parameters.AddWithValue("@aciklama", richTextBox1.Text);
              siparis_id =  (int) komut.ExecuteScalar();

            urunekle.Enabled = true;
            urunsil.Enabled = true;
            urunguncelle.Enabled = true;







        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            urunekle goster = new urunekle();
            goster.ShowDialog();
            NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");

            baglanti.Open();


            listele("select * from urunler order by urun_adi desc limit 10");
            using (urunsec urunsec = new urunsec()){
                if (urunsec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Seçilen ürünü ekleteceğiz
                 //   MessageBox.Show(urunsec.SecilenData.ToString());
                }
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (musterisec musterisec =  new musterisec())
            {
                int musteri_id;
                if(musterisec.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    musteri_id = musterisec.SecilenMusteri;
                    textBox1.Text = musteri_id.ToString();                   

                }
            }
        }

        private void sipariş_Activated(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

               
            
        }

        private void sipariş_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }

        private void sipariş_Load(object sender, EventArgs e)
        {

        }

        private void sipariş_Load_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void urunsil_Click(object sender, EventArgs e)
        {
            ürün_sil goster = new ürün_sil();
            goster.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            ürüngüncelle goster = new ürüngüncelle();
            goster.ShowDialog();
        }
    }
}
