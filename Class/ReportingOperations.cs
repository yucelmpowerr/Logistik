using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojistik.Class
{
    public class ReportingOperations
    {
        DbConfig db = new DbConfig();
        //reportlara ait işlemlerin hepsini tutuyor.


        public DataTable GetHighestCapacityVehicle()
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                string quary = "SELECT * FROM dbo.EnYuksekKapasiteliArac()";

                connection.Open();
                SqlCommand command = new SqlCommand(quary, connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    connection.Close();
                    return resultTable;
                }
            }
        }

        public int GetOrdersDeliveredCount()
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                SqlCommand command = new SqlCommand("GetTeslimEdilenGonderiSayisi", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                int ordersDeliveredCount = (int)command.ExecuteScalar();
                connection.Close();
                return ordersDeliveredCount;
            }
        }

        public DataTable GetOrdersDelivered()
        {
            string viewQuery = "SELECT * FROM TeslimEdilenSiparisler";

            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(viewQuery, connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    connection.Close();
                    return resultTable;
                }
            }
        }
    }
}
