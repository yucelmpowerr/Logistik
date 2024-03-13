using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojistik.Class
{
    public class ConfirmedOrders
    {
        CustomerOperations customerOperations = new CustomerOperations();
        DbConfig db = new DbConfig();
        string tableName = "Gonderi";
        string tableName2 = "Siparis";

        public DataTable GetAllConfirmedOrders()
        {
            return db.GetTableData(tableName);
        }
         
        public void AddConfirmedOrders(int orderID, string customerName, int vehicleID)
        {
            int customerID = customerOperations.GetCustomerID(customerName);
            string[] columns = { "Siparis_ID", "Musteri_ID","Arac_ID","Durum"};
            object[] values = { orderID, customerID, vehicleID, "Beklemede" };
            db.InsertData(tableName,columns,values);

            string[] updateColums = {"Durum"};
            object[] updateValues = { "Onaylandı" };

            db.UpdateTable(tableName2, updateColums,updateValues, "Siparis_ID",orderID);
        }
    }
}