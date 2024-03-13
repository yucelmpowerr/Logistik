using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Lojistik.Class
{
    public class DbConfig
    {
        private string dbConnection = "Data Source=DESKTOP-Q40BHHF;Initial Catalog=LojistikFirmasi;Integrated Security=True";

        public void InsertData(string tableName, string[] columns, object[] values)
        {
            if (columns.Length != values.Length)
            {
                throw new ArgumentException("Columns and values count mismatch");
            }

            string columnNames = string.Join(",", columns);
            string[] paramNames = columns.Select((c, index) => $"@Param{index}").ToArray();
            string valueParams = string.Join(",", paramNames);

            string query = $"INSERT INTO {tableName} ({columnNames}) VALUES ({valueParams})";

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    for (int i = 0; i < columns.Length; i++)
                    {
                        command.Parameters.AddWithValue(paramNames[i], values[i]);
                    }
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public string GetConnection()
        {
            return dbConnection;
        }

        public DataTable GetTableData(string tableName)
        {
            string sqlQuery = $"SELECT * FROM {tableName}";

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    connection.Close();
                    return resultTable;
                }
            }
        }

        public DataTable GetParamData(string tableName, string columnName, object param)
        {
            string sqlQuery = $"SELECT * FROM {tableName} WHERE {columnName} = @p";
            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@p", param);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);
                        return resultTable;
                    }
                }
            }
        }

        public void DeleteFromTable(string tableName, string columnName, object value)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(dbConnection))
                {
                    connection.Open();
                    string deleteQuery = $"DELETE FROM {tableName} WHERE {columnName} = @ValueToDelete";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ValueToDelete", value);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateTable(string tableName, string[] columnsToUpdate, object[] newValues, string conditionColumn, object conditionValue)
        {             
            string updateQuery = $"UPDATE {tableName} SET ";

            for (int i = 0; i < columnsToUpdate.Length; i++)
            {
                updateQuery += $"{columnsToUpdate[i]} = @{columnsToUpdate[i]}";

                if (i < columnsToUpdate.Length - 1)
                {
                    updateQuery += ", ";
                }
            }
            updateQuery += $" WHERE {conditionColumn} = @{conditionColumn}";

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    for (int i = 0; i < columnsToUpdate.Length; i++)
                    {
                        command.Parameters.AddWithValue($"@{columnsToUpdate[i]}", newValues[i]);
                    }
                    command.Parameters.AddWithValue($"@{conditionColumn}", conditionValue);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}