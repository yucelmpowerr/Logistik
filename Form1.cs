using Lojistik.Class;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personeller form2 = new Personeller();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Araclar araclar = new Araclar();
            araclar.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Depo depo = new Depo();
            depo.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NakliyeFirması nakliyeFirması = new NakliyeFirması();
            nakliyeFirması.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Gönderiler gönderiler = new Gönderiler();
            gönderiler.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Siparişler siparişler = new Siparişler();
            siparişler.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Musteriler musteriler = new Musteriler();
            musteriler.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RaporlamaIslemleri raporlamaIslemleri = new RaporlamaIslemleri();
            raporlamaIslemleri.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Show();
            System.Threading.Thread.Sleep(2000); 
            splash.Close();
        }
    }
}