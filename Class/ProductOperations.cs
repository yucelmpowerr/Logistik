using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lojistik.Class
{
    public class ProductOperations
    {
        DbConfig db = new DbConfig();
        string tableName = "Urun";             
        string tableName2 = "Kategoriler";



        public string GetProdactName(int productID)          //sql e sorgu yollayıp ürün id yollar o id ait urunun adını bize dönderır.
        {
            string name = "";

            DataTable dataTable = db.GetParamData(tableName, "Urun_ID", productID);
            foreach (DataRow row in dataTable.Rows)
            {
                name = row["Ad"].ToString();
            }
            return name;
        }

        public int GetProductID(string productName)
        {
            int id = -1;
            DataTable dataTable = db.GetParamData(tableName, "Ad", productName);

            foreach (DataRow row in dataTable.Rows)
            {
                id = Convert.ToInt32(row["Urun_ID"]);
            }

            return id;
        }

        public DataTable GetProductToID(string categoriName)
        {
            DataTable table = db.GetParamData(tableName2,"Ad",categoriName);

            foreach (DataRow dr in table.Rows)
            {
                return db.GetParamData(tableName, "Kategori_ID", dr["Kategori_ID"].ToString());
            }
            return null;
        }

        public DataTable GetAllCategories()
        {
            return db.GetTableData(tableName2);
        }
          // tüm tabloyu dönderir
        public DataTable GetAllProduct()
        {
            return db.GetTableData(tableName);
        }
    }
}
