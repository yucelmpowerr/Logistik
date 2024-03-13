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
    public partial class Rapor : Form
    {
        DataTable dataTable;
        int count;
        public Rapor(DataTable dataTable , int count)
        {
            InitializeComponent();
            this.dataTable = dataTable;
            this.count = count;
        }
        private void SetListView()
        {
            listView1.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row["Musteri_Adi"].ToString());
                item.SubItems.Add(row["Urun_Adi"].ToString());
                item.SubItems.Add(row["Durum"].ToString());
                listView1.Items.Add(item);
            }
            label2.Text = count.ToString();
        }
        private void Rapor_Load(object sender, EventArgs e)
        {
            SetListView();
        }
    }
}
