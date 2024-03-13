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
    public partial class RaporlamaIslemleri : Form
    {
        ReportingOperations reportingOperations = new ReportingOperations();

        public RaporlamaIslemleri()
        {
            InitializeComponent();
        }

        private void RaporlamaIslemleri_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = reportingOperations.GetOrdersDelivered();
            int count = reportingOperations.GetOrdersDeliveredCount();
            Rapor rapor = new Rapor(dataTable,count);
            rapor.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = reportingOperations.GetHighestCapacityVehicle();

            foreach (DataRow row in dataTable.Rows)
            {
                string name = row[0].ToString();
                string capacity = row[1].ToString();

                MessageBox.Show("Araç Adı : " + name + "\n" + "Kapasite : " + capacity);
            }
        }
    }
}
