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
    public partial class AracEkle : Form
    {
        VehicleOperations vehicleOperations = new VehicleOperations();
        CompanyOperations companyOperations = new CompanyOperations();

        DataTable companyTable;

        public AracEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text.Trim();
            string truckCapacity = textBox1.Text.Trim();
            string licensePlate = textBox2.Text.Trim();

            if (name == "" || truckCapacity == "" || licensePlate == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
                return;
            }

            vehicleOperations.AddTruck(name, truckCapacity, licensePlate);

            this.Hide();
        }

        private void AracEkle_Load(object sender, EventArgs e)
        {
         
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
