using Lojistik.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Personeller : Form
    {
        private DataTable personnelTable;
        PersonnelOperations personnelOperations = new PersonnelOperations();
        StorageOperations storageOperations = new StorageOperations();

        private string selected_Personel_ID, selected_Ad, selected_Soyad, selected_Görev, selected_Depo_ID;

        public Personeller()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SetListView();
        }

        private void SetListView()
        {
            personnelTable = personnelOperations.GetPersonelDataTable();
            listView1.Items.Clear();
            foreach (DataRow row in personnelTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row["Ad"].ToString());
                item.SubItems.Add(row["Soyad"].ToString());
                item.SubItems.Add(row["Görev"].ToString());

                int storageID = (int)row["Depo_ID"];
                string storageName = storageOperations.ConvertIDToName(storageID);
                item.SubItems.Add(storageName);
               
                listView1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int personnelID = Convert.ToInt32(selected_Personel_ID);
                personnelOperations.DeletePersonel(personnelID);
                SetListView();
            }
            else
            {
                MessageBox.Show("Seçili Personel Yok");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelEkle personelEkle = new PersonelEkle();
            personelEkle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                PersonelDüzenle personelDüzenle = new PersonelDüzenle(selected_Personel_ID, selected_Ad, selected_Soyad, selected_Görev, selected_Depo_ID);
                personelDüzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seçili Personel Yok");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selected = listView1.SelectedItems[0];

                selected_Personel_ID = selected.SubItems[0].Text;
                selected_Ad = selected.SubItems[1].Text;
                selected_Soyad = selected.SubItems[2].Text;
                selected_Görev = selected.SubItems[3].Text;
                selected_Depo_ID = selected.SubItems[4].Text;
            }
        }
    }
}