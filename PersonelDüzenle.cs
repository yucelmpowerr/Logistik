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
using System.Xml.Linq;

namespace Lojistik
{
    public partial class PersonelDüzenle : Form
    {
        StorageOperations storageOperations = new StorageOperations();
        PersonnelOperations personnelOperations = new PersonnelOperations();
        DbConfig db = new DbConfig();

        private string selected_Personel_ID, selected_Ad, selected_Soyad, selected_Görev, selected_Depo_ID;
        DataTable storageTable;

        public PersonelDüzenle(string selected_Personel_ID, string selected_Ad, string selected_Soyad, string selected_Görev, string selected_Depo_ID)
        {
            InitializeComponent();
            this.selected_Personel_ID = selected_Personel_ID;
            this.selected_Ad = selected_Ad;
            this.selected_Soyad = selected_Soyad;
            this.selected_Görev = selected_Görev;
            this.selected_Depo_ID = selected_Depo_ID;
        }
        private void PersonelDüzenle_Load(object sender, EventArgs e)
        {
            storageTable = storageOperations.GetStorageTable();

            foreach (DataRow row in storageTable.Rows)
            {
                comboBox1.Items.Add(row["Ad"].ToString());
            }

            textBox1.Text = selected_Ad;
            textBox2.Text = selected_Soyad;
            textBox3.Text = selected_Görev;
            comboBox1.SelectedItem = selected_Depo_ID;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string surname = textBox2.Text.Trim();
            string duty = textBox3.Text.Trim();

            if (name == "" || surname == "" || duty == "")
            {
                MessageBox.Show("Lütfen boş alanları doldurunuz");
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen görevlendireceğiniz depoyu seçiniz");
                return;
            }

            string storageName = comboBox1.SelectedItem.ToString();
            int storageID = storageOperations.ConvertNameToID(storageName);
            int Personnel_ID = Convert.ToInt32(selected_Personel_ID);

            personnelOperations.UpdatePersonnel(name,surname,duty,storageID,Personnel_ID);
            this.Hide();
        }
    }
}
