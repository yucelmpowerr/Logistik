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
    public partial class NakliyeFirması : Form
    {
        CompanyOperations companyOperations = new CompanyOperations();

        DataTable companyTable;

        public NakliyeFirması()
        {
            InitializeComponent();
        }

        private void NakliyeFirması_Load(object sender, EventArgs e)
        {
            SetListView();
        }

        private void SetListView()
        {
            companyTable = companyOperations.GetAllCompany();
            listView1.Items.Clear();
            foreach (DataRow row in companyTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row["Ad"].ToString());
                item.SubItems.Add(row["Adres"].ToString());
                item.SubItems.Add(row["Telefon"].ToString());
                listView1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FirmaEkle firmaEkle = new FirmaEkle();
            firmaEkle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetListView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);

                companyOperations.RemoveCompany(id);

                SetListView();
            }
            else
            {
                MessageBox.Show("Seçili Firma Yok");
            }
          
        }
    }
}
