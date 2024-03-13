using System;
using System.Collections.Generic;
using System.Data;

namespace Lojistik.Class
{
    public class PersonnelOperations
    {
        private DbConfig db = new DbConfig();
        private DataTable personnelTable;
        private string tableName = "Personel";

        public void AddPersonnel(string name,string surname,string duty, int storageID)
        {
            string[] columns = {"Ad","Soyad","Görev","Depo_ID"};
            object[] values = {name,surname,duty, storageID};

            db.InsertData(tableName, columns, values);
        }

        public void DeletePersonel(object personnelID)
        {
            string columnName = "Personel_ID";
            db.DeleteFromTable(tableName, columnName, personnelID);
        }

        public void UpdatePersonnel(string name, string surname, string duty, int storageID, object conditionValue)
        {
            string conditionColumn = "Personel_ID";
            string[] columnsToUpdate = { "Ad", "Soyad", "Görev", "Depo_ID" };
            object[] newValues = { name, surname, duty, storageID };

            db.UpdateTable(tableName, columnsToUpdate, newValues, conditionColumn, conditionValue);
        }

        public DataTable GetPersonelDataTable()
        {
            personnelTable = db.GetTableData(tableName);
            return personnelTable;
        }
    }
}