using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Lojistik.Class
{
    public class DeliveryOperations
    {
        DeliveryStatusOperations statusOperations = new DeliveryStatusOperations();

        DbConfig db = new DbConfig();
        string tableName = "Gonderi";


        public DataTable GetDeliveryForID(int deliveryID)
        {
           return db.GetParamData(tableName, "Gonderi_ID", deliveryID);
        }

        public void SetDeliveryStatus(int shipmentID, string status)
        {
            string[] columns = {"Durum"};
            object[] values = {status};

            db.UpdateTable(tableName,columns,values, "Gonderi_ID", shipmentID);
        }

        public DataTable GetDelivery(int truckID)
        {
            return db.GetParamData(tableName, "Arac_ID", truckID);            
        }
    }
}
