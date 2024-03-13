using Lojistik.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Araclar : Form
    {
        CompanyOperations companyOperations = new CompanyOperations();
        VehicleOperations vehicleOperations = new VehicleOperations();
        DeliveryOperations deliveryOperations = new DeliveryOperations();


        DataTable truckTable;
        string selectedArac_ID, selectedAdı, selectedKapasite, selectedPlaka_No;

        public Araclar()
        {
            InitializeComponent();
        }

        private void Araclar_Load(object sender, EventArgs e)
        {
            SetListView();
        }

        private void SetListView()
        {
            truckTable = vehicleOperations.GetAllTruck();
            listView1.Items.Clear();
            foreach (DataRow row in truckTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row["Adı"].ToString());
                item.SubItems.Add(row["Kapasite"].ToString());
                item.SubItems.Add(row["Plaka_No"].ToString());
                item.SubItems.Add(row["Teslimat_Durumu"].ToString());
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AracEkle aracEkle = new AracEkle();
            aracEkle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                AracDüzenle aracDüzenle = new AracDüzenle(selectedArac_ID, selectedAdı, selectedKapasite, selectedPlaka_No);
                aracDüzenle.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seçili Araç Yok");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetListView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(selectedArac_ID);

                DialogResult result = MessageBox.Show("İşleme devam etmek istiyor musunuz? \nİşleme devam ederseniz araca ait GÖNDERİLER AİT ARAÇ BİLGİSİ SİLİNECEKTİR ", "UYARI !", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    vehicleOperations.RemoveTrack(id);
                    SetListView();
                }
                else if (result == DialogResult.No)
                {
                    return;   
                }
            }
            else
            {
                MessageBox.Show("Seçili Araç Yok");
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selected = listView1.SelectedItems[0];

                selectedArac_ID= selected.SubItems[0].Text;
                selectedAdı = selected.SubItems[1].Text;
                selectedKapasite = selected.SubItems[2].Text;
                selectedPlaka_No = selected.SubItems[3].Text;
            }
        }
    }
}
