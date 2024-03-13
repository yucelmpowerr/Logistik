using Lojistik.Class;
using System;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class AracDüzenle : Form
    {
        VehicleOperations vehicleOperations = new VehicleOperations();

        string selectedArac_ID, selectedAdı, selectedKapasite, selectedPlaka_No;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public AracDüzenle(string selectedArac_ID, string selectedAdı, string selectedKapasite, string selectedPlaka_No)
        {
            InitializeComponent();
            this.selectedArac_ID = selectedArac_ID;
            this.selectedAdı = selectedAdı;
            this.selectedKapasite = selectedKapasite;
            this.selectedPlaka_No = selectedPlaka_No;
        }

        private void AracDüzenle_Load(object sender, EventArgs e)
        {
            textBox3.Text = selectedAdı;
            textBox1.Text = selectedKapasite;
            textBox2.Text = selectedPlaka_No;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            selectedAdı = textBox3.Text.Trim();
            selectedKapasite = textBox1.Text.Trim();
            selectedPlaka_No = textBox2.Text.Trim();

            if (selectedAdı == "" || selectedKapasite == "" || selectedPlaka_No == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
                return;
            }

            int id = Convert.ToInt32(selectedArac_ID);
            vehicleOperations.UpdateTruck(id,selectedAdı,selectedKapasite,selectedPlaka_No);
            this.Hide();
        }
    }
}
