using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Data.Common;
using System.Xml.Linq;

namespace Lojistik.Class
{
    public class VehicleOperations
    {
        DbConfig db = new DbConfig();
        string tableName = "Tasima_Araclari";



        public string GetTrackName(int truckID)
        {
            string status = "";

            DataTable truckTable = db.GetParamData(tableName, "Arac_ID", truckID);

            foreach (DataRow row in truckTable.Rows)
            {
                status = row["Adı"].ToString();
            }
            return status;
        }


        public string GetTruckStatus(int truckID)
        {
            string status = "";

            DataTable truckTable = db.GetParamData(tableName, "Arac_ID",truckID);

            foreach (DataRow row in truckTable.Rows)
            {
                status = row["Teslimat_Durumu"].ToString();
            }
            return status;
        }

        public void SetTruckStatus(int truckID , string status)
        {
            string[] columns = {"Teslimat_Durumu"};
            object[] values = {status};

            db.UpdateTable(tableName, columns, values, "Arac_ID", truckID);
        }

        public DataTable GetTruck(int truckID)
        {
            return db.GetParamData(tableName,"Arac_ID",truckID);
        }

        public int GetTruckID(string truckName)
        {
            int id = -1;
            DataTable dataTable = db.GetParamData(tableName, "Adı", truckName);

            foreach (DataRow row in dataTable.Rows)
            {
                id = Convert.ToInt32(row["Arac_ID"]);
            }
            return id;
        }

        public void TruckStateChance(string truckName)
        {
            string[] columns = { "Teslimat_Durumu" };
            object[] values = { "Boşta" };
            db.UpdateTable(tableName,columns,values,"Adı",truckName);
        }

        public DataTable GetAllTruck()
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("TumAraclar", connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    connection.Close();
                    return resultTable;
                }
            }
        }

        public void AddTruck(string name ,string truckCapacity, string licensePlate)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand command = new SqlCommand("AracEkle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Adı", name);
                    command.Parameters.AddWithValue("@Kapasite", truckCapacity);
                    command.Parameters.AddWithValue("@PlakaNo", licensePlate);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                    connection.Close();
                }
            }
        }

        public void RemoveTrack(int id)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand command = new SqlCommand("AracKaldır", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Arac_ID", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                    connection.Close();
                }
            }
        }

        public void UpdateTruck(int id, string name,string truckCapacity, string licensePlate)
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                using (SqlCommand command = new SqlCommand("AracGuncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Arac_ID", id);
                    command.Parameters.AddWithValue("@Adı", name);
                    command.Parameters.AddWithValue("@Kapasite", truckCapacity);
                    command.Parameters.AddWithValue("@PlakaNo", licensePlate);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                    connection.Close();
                }
            }
        }
    }
}
