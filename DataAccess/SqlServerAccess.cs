using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class SqlServerAccess
    {
        public SqlServerAccess(string connectionString)
        {
            ConnectionString = connectionString;
         }

        public string ConnectionString { get; init; }

        public string InsertFacilitator(string firstName, string surname, string printerCode)
        {
            
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = ConnectionString;
                cn.Open();
                //This is to demonstrate a ado method.
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsert_Facilitator";

                    cmd.Parameters.Add(new SqlParameter("@FirstName",firstName));
                    cmd.Parameters.Add(new SqlParameter("@Surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@PrinterCode", printerCode));

                    SqlParameter msg = new SqlParameter();
                    msg.ParameterName = "@Msg";
                    msg.Direction = ParameterDirection.Output;
                    msg.Size = 100;
                    cmd.Parameters.Add(msg);

                    cmd.ExecuteNonQuery();
                    return msg.ToString();
                }
            }
        }
    }
}
