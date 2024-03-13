using System;
using System.Collections.Generic;
using System.Data;

namespace Lojistik.Class
{
    public class CustomerOperations
    {
        DbConfig db = new DbConfig();
        string tableName = "Musteri";

        public string GetCustomerName(int customerID)
        {
            string name = "";

            DataTable dataTable = db.GetParamData(tableName, "Musteri_ID", customerID);
            foreach (DataRow row in dataTable.Rows)
            {
                name = row["Ad"].ToString() + " " + row["Soyad"].ToString();
            }
            return name;
        }

        public int GetCustomerID(string name)
        {
            int id = -1;
            DataTable dataTable = db.GetParamData(tableName,"Ad",name);

            foreach (DataRow row in dataTable.Rows)
            {
                id = Convert.ToInt32(row["Musteri_ID"]);
            }

            return id;
        }

        public DataTable GetCustomers()
        {
            return db.GetTableData(tableName);
        }

        public void AddCustomer(string name, string surname, string mail, string phoneNumber)
        {
            string[] columns = {"Ad","Soyad","Eposta","Telefon"};
            object[] values = { name, surname, mail, phoneNumber };
            db.InsertData(tableName,columns,values);
        }
        public void RemoveCustomer(int customerID)
        {
            db.DeleteFromTable(tableName,"Musteri_ID", customerID);
        }
    }
}