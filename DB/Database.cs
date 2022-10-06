using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Premier_AdminPanel.DB
{
    public class Database
    {
         public static string sqlDataSource = "Data Source =185.140.249.224,1503; Initial Catalog = primierXX; Persist Security Info=True;User ID = cubix; Password=mam@123"; // PremierOfficeDB
        // public static string sqlDataSource = "Data Source =PSERVERR2\\CUBIX,1501; Initial Catalog =c_bix; Persist Security Info=True;User ID = cubix; Password=mam@123"; //premier client DB

        public DataTable getTableDictionary(string sql, bool isProcedure, Dictionary<string, string> parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(sqlDataSource))
            {
                DataTable dt = new DataTable();
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    if (isProcedure)
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                    else
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = sql;
                    }
                    foreach (string parameter in parameters.Keys)
                    {
                        sqlCommand.Parameters.AddWithValue(parameter, parameters[parameter]);
                    }
                    sqlCommand.CommandTimeout = 300;
                    SqlDataReader sqldr = sqlCommand.ExecuteReader();
                    if (sqldr.
                        HasRows)
                    {
                        dt.Load(sqldr);
                        return dt;
                    }
                }
            }

            return null;
        }

    }
}
