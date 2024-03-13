using Lojistik.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Depo : Form
    {
        StorageOperations storageOperations = new StorageOperations();
        DataTable storageTable;
        public Depo()
        {
            InitializeComponent();
        }

        private void Depo_Load(object sender, EventArgs e)
        {
            SetListView();
            SetCenterList();
            SetBranchList();
        }

        private void SetCenterList()
        {
            DataTable centers = storageOperations.GetAllLogisticsCenter();
            listBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox2.Items.Clear();
            foreach (DataRow row in centers.Rows)
            {
                listBox1.Items.Add(row["Ad"].ToString());
                comboBox3.Items.Add(row["Ad"].ToString());
                comboBox2.Items.Add(row["Ad"].ToString());
            }
        }

        private void SetBranchList()
        {
            DataTable centers = storageOperations.GetAllBranch();
            listBox2.Items.Clear();
            foreach (DataRow row in centers.Rows)
            {
                listBox2.Items.Add(row["Ad"].ToString());
            }
        }

        private void SetListView()
        {
            storageTable = storageOperations.GetStorageAndBranchAndLogisticsCenter();
            listView1.Items.Clear();
            foreach (DataRow row in storageTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row["DepoName"].ToString());
                item.SubItems.Add(row["DepoLok"].ToString());

                item.SubItems.Add(row["MerkezName"].ToString());
                item.SubItems.Add(row["MerkezLok"].ToString()); 

                item.SubItems.Add(row["SubeName"].ToString());
                item.SubItems.Add(row["ŞubeLok"].ToString());

                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string logisticsCenteName = textBox4.Text.Trim();
            string location = textBox3.Text.Trim();

            if (logisticsCenteName == "" || location == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
                return;
            }

            storageOperations.AddLogisticsCenter(logisticsCenteName,location);

            SetCenterList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string branchName = textBox1.Text.Trim();
            string location = textBox2.Text.Trim();
            string logisticsCenteName = comboBox3.SelectedItem.ToString();

            if (branchName == "" || location == "" || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
                return;
            }

            int id = storageOperations.GetLogisticsCenterID(logisticsCenteName);
      
            if (id == -1)
            {
                return;
            }

            storageOperations.AddBranch(id,branchName,location);
            SetBranchList();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string logisticsCenteName = comboBox2.SelectedItem.ToString();
            int id = storageOperations.GetLogisticsCenterID(logisticsCenteName);

            DataTable dataTable = storageOperations.GetTheBranchBelongingToTheCenter(id);
            comboBox1.Items.Clear();

            foreach (DataRow row in dataTable.Rows)
            {
                comboBox1.Items.Add(row["Ad"].ToString());
            }
            comboBox1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string storageName = textBox6.Text.Trim();
            string location = textBox5.Text.Trim();

            if (comboBox1.SelectedItem == null|| storageName == "" ||location == "")
            {
                MessageBox.Show("Boş Alanları Doldurunuz");
                return;
            }
            string branchName = comboBox1.SelectedItem.ToString();

            int id = storageOperations.GetBranchID(branchName);

            if (id == -1)
            {
                return;
            }

            storageOperations.AddStorage(storageName, location, id);

            SetListView();
            comboBox1.SelectedItem = null;
            comboBox1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                string centerName = listBox1.SelectedItem.ToString();
                int id = storageOperations.GetLogisticsCenterID(centerName);
                storageOperations.RemoveLogisticsCenter(id);
                SetCenterList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);

                storageOperations.RemoveStorage(id);

                SetListView();
            }
            else
            {
                MessageBox.Show("Seçili Depo Yok");
            }
        }

       
    }
}
