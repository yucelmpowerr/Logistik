using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojistik.Class
{
    public class CompanyOperations
    {
        DbConfig db = new DbConfig();        
        string tableName = "Nakliye_Firmasi";

        public DataTable GetAllCompany()
        {
            return db.GetTableData(tableName);
        }

        public void AddCompany(string companyName, string companyAddress,string companyPhoneNumber)
        {
            string[] columns = {"Ad","Adres","Telefon"};
            object[] values = { companyName, companyAddress, companyPhoneNumber };
            db.InsertData(tableName,columns,values);
        }

        public void RemoveCompany(int companyID)
        {
            db.DeleteFromTable(tableName,"Firma_ID" ,companyID);
        }
    }
}