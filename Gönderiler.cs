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
    public partial class Gönderiler : Form
    {
        CustomerOperations customerOperations = new CustomerOperations();
        ConfirmedOrders confirmedOrders = new ConfirmedOrders();
        VehicleOperations vehicleOperations = new VehicleOperations();
        DeliveryStatusOperations deliveryStatusOperations = new DeliveryStatusOperations();
        DeliveryOperations deliveryOperations = new DeliveryOperations();

        DataTable deliveryTable, vehicleTable, deliveryStatusTable;

        public Gönderiler()
        {
            InitializeComponent();
        }

        private void Gönderiler_Load(object sender, EventArgs e)
        {
            SetListView();
            SetListView2();
            SetCombobox();
            SetCombobox2();
        }
        private void SetCombobox2()
        {
            vehicleTable = vehicleOperations.GetAllTruck();
            comboBox2.Items.Clear();

            foreach (DataRow row in vehicleTable.Rows)
            {
                string status = row["Teslimat_Durumu"].ToString();
                if (status == "Yolda")
                {
                    comboBox2.Items.Add(row["Adı"].ToString());
                }
            }
        }
        private void SetCombobox()
        {
            vehicleTable = vehicleOperations.GetAllTruck();
            comboBox1.Items.Clear();

            foreach (DataRow row in vehicleTable.Rows)
            {
                comboBox1.Items.Add(row["Adı"].ToString());
            }
        }
        private void SetListView()
        {
            if (comboBox1.SelectedItem != null)
            {
                string truckName = comboBox1.SelectedItem.ToString();
                int truckID = vehicleOperations.GetTruckID(truckName);

                deliveryTable = deliveryOperations.GetDelivery(truckID);
                listView1.Items.Clear();
                foreach (DataRow row in deliveryTable.Rows)
                {
                    string status = row["Durum"].ToString();
                    if (status == "Beklemede")
                    {
                        ListViewItem item = new ListViewItem(row[0].ToString());
                        item.SubItems.Add(row["Durum"].ToString());
                        item.SubItems.Add(row["Siparis_ID"].ToString());
                        item.SubItems.Add(row["Musteri_ID"].ToString());

                        int customerID = Convert.ToInt32(row["Musteri_ID"]);
                        string customerName = customerOperations.GetCustomerName(customerID);
                        item.SubItems.Add(customerName);

                        listView1.Items.Add(item);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
            }
        }

        private void SetListView2()
        {
            if (comboBox2.SelectedItem != null)
            {
                deliveryStatusTable = deliveryStatusOperations.GetDeliveryStatus();
                string truckName = comboBox2.SelectedItem.ToString();
                int truckID = vehicleOperations.GetTruckID(truckName);

                listView2.Items.Clear();

                foreach (DataRow row in deliveryStatusTable.Rows)
                {

                    int deliveryID = Convert.ToInt32(row["Gonderi_ID"]);

                    DataTable dataTable = deliveryOperations.GetDeliveryForID(deliveryID);

                    if (dataTable != null)
                    {
                        foreach (DataRow deliveryRow in dataTable.Rows)
                        {
                            int deliveryTruckID = Convert.ToInt32(deliveryRow["Arac_ID"]);
                            string status = deliveryRow["Durum"].ToString();

                            if (truckID == deliveryTruckID && status == "Yolda")
                            {
                                ListViewItem item = new ListViewItem(row[0].ToString());

                                item.SubItems.Add(deliveryRow["Durum"].ToString());
                                item.SubItems.Add(deliveryRow["Gonderi_ID"].ToString());
                                item.SubItems.Add(deliveryRow["Musteri_ID"].ToString());
                                item.SubItems.Add(deliveryRow["Arac_ID"].ToString());

                                listView2.Items.Add(item);
                            }
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetListView();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetListView2();
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            //Teslim Et

            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Seçili Araç Yok");
                return;
            }

            string truckName = comboBox2.SelectedItem.ToString();
            int truckID = vehicleOperations.GetTruckID(truckName);
            
            foreach (ListViewItem item in listView2.Items)
            {
                int shipmentID = Convert.ToInt32(item.SubItems[2].Text);
                deliveryOperations.SetDeliveryStatus(shipmentID, "Teslim Edildi");
                vehicleOperations.SetTruckStatus(truckID, "Boşta");
            }
            listView2.Items.Clear();
            SetCombobox2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //teslimat başlat

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Seçili Araç Yok");
                return;
            }

            string truckName = comboBox1.SelectedItem.ToString();
            int truckID = vehicleOperations.GetTruckID(truckName);
            string truckStatus = vehicleOperations.GetTruckStatus(truckID);

            if (truckStatus == "Yolda")
            {
                MessageBox.Show("Araç Zaten Yolda");
                return;
            }
            if (listView1.Items.Count < 1)
            {
                MessageBox.Show("Sipariş Yok");
                return;
            }

            foreach (ListViewItem item in listView1.Items)
            {
                int shipmentID = Convert.ToInt32(item.SubItems[0].Text);
                deliveryStatusOperations.AddDeliveryStatus(shipmentID);

                deliveryOperations.SetDeliveryStatus(shipmentID, "Yolda");
                vehicleOperations.SetTruckStatus(truckID, "Yolda");
            }
            SetListView();
            SetListView2();
            SetCombobox2();
        }
    }
}
