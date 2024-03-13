using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojistik.Class
{
    public class OrderOperations
    {
        DbConfig db = new DbConfig();
        string tableName = "Siparis";
        
        public DataTable GetAllOrder()
        {
            return db.GetTableData(tableName);
        }

        public void AddOrder(string date, int customerID, int productID)
        {
            string[] columns = {"Tarih", "Musteri_ID", "Urun_ID" };
            object[] values = {date, customerID, productID};

            db.InsertData(tableName,columns,values);
        }

        public void RemoveOrder(int Id)
        {
            db.DeleteFromTable(tableName, "Siparis_ID", Id);
        }


    }
}