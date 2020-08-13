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
    public partial class form : Form
    {

        public form()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Asmd8221;Database=TestDB;");
        

        int kisi_id;
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

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele("select * from kisiler");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Tc alanı zorunludur");
                    return;
                }


                //baglanti.Open();
                //,
                //'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "'
                //   int tcno =  >  0 ? Convert.ToInt32(textBox2.Text) :  null; 

                //'" + tcno + "','" + textBox3.Text + "', '" + textBox4.Text + "',musteri_telefon,musteri_mail,musteri_adres
                //, @musteri_telefon, @musteri_mail, @musteri_adres
                //  NpgsqlCommand komut = new NpgsqlCommand("insert into kisiler(kisi_adi,kisi_soyadi) values (@kisi_adi, @kisi_soyadi) returning kisi_id", baglanti);

                //komut.Parameters.AddWithValue("@kisi_adi", textBox2.Text);
                //komut.Parameters.AddWithValue("@kisi_soyadi", textBox3.Text);
                //int kisi_id = (int)komut.ExecuteScalar();
                NpgsqlCommand Kisikomut = new NpgsqlCommand("insert into kisiler (kisi_tc_no,kisi_adi,kisi_soyadi,kisi_cinsiyet, kisi_telefon, kisi_mail,kisi_adres,kisi_il, kisi_ulke, kisi_ilce , kisi_vergi_dairesi,kisi_vergi_no  ) values (@kisi_tc_no,@kisi_adi,@kisi_soyadi,@kisi_cinsiyet, @kisi_telefon, @kisi_mail,@kisi_adres,@kisi_il, @kisi_ulke,@kisi_ilce ,@kisi_vergi_dairesi,@kisi_vergi_no  ) returning kisi_id", baglanti);


                //int sayi = Convert.ToInt32(rakam);
                //komut.Parameters.AddWithValue("@no", r);

                Kisikomut.Parameters.AddWithValue("@kisi_tc_no", int.Parse(textBox2.Text));
                Kisikomut.Parameters.AddWithValue("@kisi_adi", textBox3.Text);
                Kisikomut.Parameters.AddWithValue("@kisi_soyadi", textBox4.Text);


                if (textBox6.Text != "")
                {
                    Kisikomut.Parameters.AddWithValue("@kisi_telefon", int.Parse(textBox6.Text));

                }

                else
                {
                    Kisikomut.Parameters.AddWithValue("@kisi_telefon", DBNull.Value);
                }

                //Cinsiyet
                if (radioButton1.Checked == true)
                {
                    Kisikomut.Parameters.AddWithValue("@kisi_cinsiyet", "E");
                }
                else if (radioButton2.Checked == true)
                {
                    Kisikomut.Parameters.AddWithValue("@kisi_cinsiyet", "K");
                }
                else
                {
                    Kisikomut.Parameters.AddWithValue("@kisi_cinsiyet", DBNull.Value);
                }

                Kisikomut.Parameters.AddWithValue("@kisi_mail", textBox7.Text);
                Kisikomut.Parameters.AddWithValue("@kisi_adres", textBox8.Text);



                Kisikomut.Parameters.AddWithValue("@kisi_il", comboBox2.Text);
                Kisikomut.Parameters.AddWithValue("@kisi_ulke", comboBox1.Text);
                Kisikomut.Parameters.AddWithValue("@kisi_ilce", comboBox3.Text);

                Kisikomut.Parameters.AddWithValue("@kisi_vergi_dairesi", textBox1.Text);

                if (textBox5.Text != "")
                {
                    Kisikomut.Parameters.AddWithValue("@kisi_vergi_no", int.Parse(textBox5.Text));
                }
                else
                {

                    Kisikomut.Parameters.AddWithValue("@kisi_vergi_no", DBNull.Value);
                }




                // komut.Parameters.AddWithValue("@sehiri", textBox9.Text);
                int kisi_id = (int)Kisikomut.ExecuteScalar();

                NpgsqlCommand Musterikomut = new NpgsqlCommand("insert into musteri (kisi_id) values (" + kisi_id + ")", baglanti);
                Musterikomut.ExecuteNonQuery();


                listele("select * from musteri inner join kisiler on kisiler.kisi_id = musteri.kisi_id");
                //Artık database tarafında ğarılık verelim öntarafı yavaş yavaş yaparız

                ResetAllControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

      
        private void form_Load(object sender, EventArgs e)
        {
            baglanti.Open();
        }

        private void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            baglanti.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listele("select * from kisiler order by kisi_id desc limit 10");
        }

        
        


        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {

            try
            {
               Object  kisi_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
 
                string cinsiyet = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                if (cinsiyet.Equals('E'))
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;

                }

                //...
                textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                


            }
            catch (Exception ex) {
                 MessageBox.Show(ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

           
            NpgsqlCommand komut = new NpgsqlCommand("UPDATE  kisiler set  kisi_tc_no=@kisi_tc_no,kisi_adi=@kisi_adi, kisi_soyadi=@kisi_soyadi, kisi_cinsiyet=@kisi_cinsiyet, kisi_telefon=@kisi_telefon,  kisi_mail=@kisi_mail,  kisi_adres=@kisi_adres,   kisi_vergi_dairesi=@kisi_vergi_dairesi, kisi_vergi_no=@kisi_vergi_no where kisi_id=@kisi_id ", baglanti);



            komut.Parameters.AddWithValue("@kisi_tc_no", int.Parse(textBox2.Text));
            komut.Parameters.AddWithValue("@kisi_adi", textBox3.Text);
            komut.Parameters.AddWithValue("@kisi_soyadi", textBox4.Text);
            komut.Parameters.AddWithValue("@kisi_id", kisi_id);
          

            string cinsiyet = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            if (radioButton1.Checked == true)
            {
                
                komut.Parameters.AddWithValue("@kisi_cinsiyet", "E");
                
            }
            else
            {
                komut.Parameters.AddWithValue("@kisi_cinsiyet", "K");

            }
            komut.Parameters.AddWithValue("@kisi_telefon", int.Parse(textBox6.Text));
            komut.Parameters.AddWithValue("@kisi_mail", textBox7.Text);
            komut.Parameters.AddWithValue("@kisi_adres", textBox8.Text);
            komut.Parameters.AddWithValue("@kisi_vergi_dairesi", textBox1.Text);

            if (textBox5.Text != "")
            {
                komut.Parameters.AddWithValue("@kisi_vergi_no", int.Parse(textBox5.Text));
            }
            else
            {

                komut.Parameters.AddWithValue("@kisi_vergi_no", DBNull.Value);
            }



            komut.ExecuteNonQuery();
            listele("select* from kisiler");

            MessageBox.Show("başarılı");

            ResetAllControls();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {


            try
            {
                kisi_id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            NpgsqlCommand komut = new NpgsqlCommand("delete from kisiler where kisi_adi=@kisi_adi", baglanti);
            komut.Parameters.AddWithValue("@kisi_adi", textBox3.Text);
            komut.ExecuteNonQuery();


            listele("select * from kisiler");
            textBox3.Clear();
            MessageBox.Show("Silme Başarılı");
        }

        private void button5_Click(object sender, EventArgs e)
        {
          

            if (textBox3.Text == "")
            {
                MessageBox.Show("Arama alanını boş bırakmayın müşteri adı ile arama yapınız");
                return;
            }

            String ara = textBox3.Text;

            listele("select * from kisiler where kisi_id  ilike  '%" + ara + "%' ");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
           
        }

        
    }
    }


