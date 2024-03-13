using Lojistik.Class;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Musteriler : Form
    {
        CustomerOperations customerOperations = new CustomerOperations();
        OrderOperations orderOperations = new OrderOperations();
        ProductOperations productOperations = new ProductOperations();
        DataTable customerTable, categoriesTable;
         
        public Musteriler()
        {
            InitializeComponent();
        }
        private void Musteriler_Load(object sender, EventArgs e)
        {
            SetListView();
            SetComboboxCustomer();
        }

        private void SetComboboxCustomer()
        {
            customerTable = customerOperations.GetCustomers();
            comboBox1.Items.Clear();
            foreach (DataRow row in customerTable.Rows)
            {
                comboBox1.Items.Add(row["Ad"].ToString());
            }
        }
        private void SetComboboxCategories()
        {
            categoriesTable = productOperations.GetAllCategories();
            comboBox2.Items.Clear();
            foreach (DataRow row in categoriesTable.Rows)
            {
                comboBox2.Items.Add(row["Ad"].ToString());
            }
        }
       
        private void SetListView()
        {
            customerTable = customerOperations.GetCustomers();
            listView1.Items.Clear();
            foreach (DataRow row in customerTable.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                item.SubItems.Add(row["Ad"].ToString());
                item.SubItems.Add(row["Soyad"].ToString());
                item.SubItems.Add(row["Eposta"].ToString());
                item.SubItems.Add(row["Telefon"].ToString());
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            string surname = textBox2.Text.Trim();
            string mail = textBox4.Text.Trim();
            string phoneNumber = textBox3.Text.Trim();

            if (name == "" || surname == "" || mail == "" || phoneNumber == "")
            {
                MessageBox.Show("Lütfen Boş Alanları Doldurup Tekrar Deneyiniz ");
                return;
            }
            customerOperations.AddCustomer(name, surname, mail, phoneNumber);
            SetListView();
            SetComboboxCustomer();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null|| comboBox3.SelectedItem == null)
            {
                return;
            }

            DateTime today = DateTime.Today;
            string date = today.ToString("dd/MM/yyyy");

            int customerID = customerOperations.GetCustomerID(comboBox1.SelectedItem.ToString());
            int productID = productOperations.GetProductID(comboBox3.SelectedItem.ToString());
 
            if (productID == -1 || customerID == -1)
            {
                return;
            }

            orderOperations.AddOrder(date,customerID, productID);
            MessageBox.Show("Sipariş Verildi");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            SetComboboxCategories();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = true;
            string categoriName = comboBox2.SelectedItem.ToString(); 
            DataTable dataTable = productOperations.GetProductToID(categoriName);

            comboBox3.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                comboBox3.Items.Add(row["Ad"].ToString());
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = Convert.ToInt32(listView1.SelectedItems[0].Text);
                customerOperations.RemoveCustomer(id);
                SetListView();
            }
            else
            {
                MessageBox.Show("Seçili Müşteri Yok");
            }
        }
    }
}