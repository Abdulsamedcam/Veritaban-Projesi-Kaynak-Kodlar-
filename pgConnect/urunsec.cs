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


    public partial class urunsec : Form
    {
        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");


        public String SecilenData { get; set; }

        public urunsec()
        {
            InitializeComponent();
        }
        public void listele(string query)
        {

            try
            {

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
            SecilenData = "seçilen ürün";
        }


        private void urunsec_Load(object sender, EventArgs e)
        {

            baglanti.Open();


            listele("select * from urunler order by urun_adi desc limit 10");

        }

        private void urunsec_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Arama alanını boş bırakmayın");
                return;
            }

            String ara = textBox1.Text;

            listele("select * from urunler  where urun_adi  ilike  '%" + ara + "%' ");
        }


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            String secilen = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            /*
            if (secilen != "" || secilen != null)
            {
                SecilenMusteri = int.Parse(secilen);
            }
            */


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}

       
    

