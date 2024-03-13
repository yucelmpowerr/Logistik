using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojistik.Class
{
    public class DeliveryStatusOperations
    {
        DbConfig db = new DbConfig();
        string tableName = "TeslimatDurumu";
        

        public void RemoveDeliveryStatus(int deliveryID)
        {
            db.DeleteFromTable(tableName, "Gonderi_ID", deliveryID);
        }

        public DataTable GetDeliveryStatus()
        {
            return db.GetTableData(tableName);
        }

        public void AddDeliveryStatus(int shipmentID)
        {
            string[] columns = {"Gonderi_ID"};
            object[] values = {shipmentID};
            db.InsertData(tableName, columns,values);
        }
    }
}
