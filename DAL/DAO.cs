using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    class DAO : IDAO
    {
        public string ConnectionString = @"Server=.\SQLEXPRESS;Database=Capstone;Trusted_Connection=True;";

        public int Write(SqlParameter[] parameter, string proc)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(proc, connection))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameter);
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameter);
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
