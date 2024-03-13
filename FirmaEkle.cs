using Lojistik.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class FirmaEkle : Form
    {
        CompanyOperations companyOperations = new CompanyOperations();

        public FirmaEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string address = textBox2.Text.Trim();
            string phoneNumber = textBox3.Text.Trim();


            if (name == "" || address == "" ||phoneNumber == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
                return;
            }
            companyOperations.AddCompany(name, address, phoneNumber);
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
