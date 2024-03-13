using Lojistik.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lojistik
{
    public partial class PersonelEkle : Form
    {
        PersonnelOperations personnelOperations = new PersonnelOperations();
        StorageOperations storageOperations = new StorageOperations();
        DataTable storageTable;

        public PersonelEkle()
        {
            InitializeComponent();
        }

        private void PersonelEkle_Load(object sender, EventArgs e)
        {
            storageTable = storageOperations.GetStorageTable();

            foreach (DataRow row in storageTable.Rows)
            {
                comboBox1.Items.Add(row["Ad"].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextControl();
        }

        private void TextControl()
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
            personnelOperations.AddPersonnel(name, surname, duty, storageID);

            this.Hide();
        }
    }
}