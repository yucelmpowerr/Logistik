using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Lojistik.Class
{
    public class StorageOperations
    {
        DbConfig db = new DbConfig();
        DataTable storageTable;
        string tableName = "Depo";

        public void AddStorage(string storageName, string location,int brunchID)
        {
            string[] column = {"Ad", "Lokasyon", "Sube_ID"};
            object[] value = {storageName, location, brunchID};
            db.InsertData(tableName,column,value);
        }

        public DataTable GetAllLogisticsCenter()
        {
            string tableName = "Loj_Merkez";
            return db.GetTableData(tableName);
        }

        public DataTable GetAllBranch()
        {
            string tableName = "Şube";
            return db.GetTableData(tableName);
        }

        public DataTable GetTheBranchBelongingToTheCenter(int id)
        {
            string tableName = "Şube";
            return db.GetParamData(tableName, "Merkez_ID", id);
        }

        public void RemoveLogisticsCenter(object ID)
        {
            string tableName = "Loj_Merkez";
            db.DeleteFromTable(tableName, "Depo_ID", ID);
        }
        public void RemoveBrunch(object ID)
        {
            string tableName = "Şube";
            db.DeleteFromTable(tableName, "Depo_ID", ID);
        }

        public void RemoveStorage(object ID)
        {
            db.DeleteFromTable(tableName, "Depo_ID", ID);
        }

        public DataTable GetStorageAndBranchAndLogisticsCenter()
        {
            using (SqlConnection connection = new SqlConnection(db.GetConnection()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectDepoSubeMerkez", connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    connection.Close();
                    return resultTable;
                }
            }
        }

        public void AddLogisticsCenter(string logisticsCenteName, string location)
        {
            string tableName = "Loj_Merkez";
            string[] columns = {"Ad","Lokasyon"};
            object[] values = { logisticsCenteName, location};
            
            DataTable dataTable = db.GetParamData(tableName, "Ad", logisticsCenteName);
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Depo_ID"].ToString() != null)
                {
                    MessageBox.Show("Bu merkez Zaten Kayıtlı");
                    return;
                }
            }
            db.InsertData(tableName, columns, values);
            MessageBox.Show("Başarılı Bir Şekilde Kaydedildi");
        }

        public void AddBranch(int centerID, string branchName, string location )
        {
            string tableName = "Şube";
            string[] columns = { "Ad", "Lokasyon","Merkez_ID"};
            object[] values = {branchName, location, centerID };

            DataTable dataTable = db.GetParamData(tableName, "Ad", branchName);

            if (dataTable.Rows.Count <= 0)
            {
                db.InsertData(tableName, columns, values);
                MessageBox.Show("Bu Şube Kaydedildi");
            }
            else
            {
                MessageBox.Show("Bu Şube Zaten Kayıtlı");
            }
        }

        public int GetLogisticsCenterID(string logisticsCenteName)
        {
            int id = -1;

            string tableName = "Loj_Merkez";
            string column = "Ad";

            DataTable dataTable = db.GetParamData(tableName, column, logisticsCenteName);

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Depo_ID"].ToString() != null)
                {
                    id = Convert.ToInt32(row["Depo_ID"]);
                }
            }
            return id;
        }

        public int GetBranchID(string branchName)
        {
            int id = -1;

            string tableName = "Şube";
            string column = "Ad";

            DataTable dataTable = db.GetParamData(tableName, column, branchName);

            foreach (DataRow row in dataTable.Rows)
            {
                id = Convert.ToInt32(row["Depo_ID"]);
            }
            return id;
        }

        public DataTable GetStorageTable()
        {
            storageTable = db.GetTableData(tableName);
            return storageTable;
        }
        
        public string ConvertIDToName(int id)
        {
            string name = "";

            string columnName = "Depo_ID";
            DataTable dataTable = db.GetParamData(tableName, columnName, id);

            foreach (DataRow row in dataTable.Rows)
                name = row["Ad"].ToString();
            
            return name;
        }

        public int ConvertNameToID(string storageName)
        {
            string columnName = "Ad";
            int storageID = -1;

            DataTable dataTable = db.GetParamData(tableName,columnName,storageName);
           
            foreach (DataRow row in dataTable.Rows)
                storageID = (int)row["Depo_ID"];
               
            return storageID;
        }
    }
}