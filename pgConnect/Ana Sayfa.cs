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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form goster = new form();
            goster.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            sipariş goster = new sipariş();
            goster.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            urunekle goster = new urunekle();
            goster.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kategori goster = new Kategori();
            goster.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Kullanıcılar goster = new Kullanıcılar();
            goster.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Yetkiler goster = new Yetkiler();
            goster.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Kullanıcıgrup goster = new Kullanıcıgrup();
            goster.ShowDialog();
        }
    }
              
    }
