using Lojistik.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Siparişler : Form
    {
        OrderOperations orderOperations = new OrderOperations();
        ProductOperations productOperations = new ProductOperations();
        CustomerOperations customerOperations = new CustomerOperations();
        ConfirmedOrders confirmedOrders = new ConfirmedOrders();

        VehicleOperations vehicleOperations = new VehicleOperations();

        DataTable orderTable, vehicleTable;

        public Siparişler()
        {
            InitializeComponent();
        }

        private void Siparişler_Load(object sender, EventArgs e)
        {
            SetListView();
            SetCombobox();
        }
        private void SetListView()
        {
            orderTable = orderOperations.GetAllOrder();
            listView1.Items.Clear();
            foreach (DataRow row in orderTable.Rows)
            {
                if (row["Durum"].ToString() == "")
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    item.SubItems.Add(row["Tarih"].ToString());

                    int customerID = Convert.ToInt32(row["Musteri_ID"]);
                    string customerName = customerOperations.GetCustomerName(customerID);

                    if (customerName != "")
                        item.SubItems.Add(customerName);

                    int producktID = Convert.ToInt32(row["Urun_ID"]);
                    string producktName = productOperations.GetProdactName(producktID);

                    if (producktName != "")
                        item.SubItems.Add(producktName);

                    listView1.Items.Add(item);
                }
            }
        }

        private void SetCombobox()
        {
            vehicleTable = vehicleOperations.GetAllTruck();
            comboBox1.Items.Clear();

            foreach (DataRow row in vehicleTable.Rows)
            {
                if (row["Teslimat_Durumu"].ToString() != "Yolda")
                {
                    comboBox1.Items.Add(row["Adı"].ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Boşta Olan Bir Araç Seçiniz");
                    return;
                }

                ListViewItem selectedRow = listView1.SelectedItems[0];

                int orderID = Convert.ToInt32(selectedRow.SubItems[0].Text);
                string[] customerName = selectedRow.SubItems[2].Text.Split(' ');
                string truckName = comboBox1.SelectedItem.ToString();

                int truckID = vehicleOperations.GetTruckID(truckName);
                confirmedOrders.AddConfirmedOrders(orderID, customerName[0],truckID);
                vehicleOperations.TruckStateChance(truckName);
                SetListView();
                SetCombobox();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int orderID = Convert.ToInt32(listView1.SelectedItems[0].Text);
                orderOperations.RemoveOrder(orderID);
                SetListView();
            }
            else
            {
                MessageBox.Show("Seçili Sipariş Yok");
            }
        }
    }
}
