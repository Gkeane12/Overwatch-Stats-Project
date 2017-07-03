using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchStats.Store.Service.CleanUp
{
    public class CleanUpStore
    {
        private string _connectionString;

        public CleanUpStore(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteUser(Guid profileGuid)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("CleanUp.DeleteUser", conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add( new SqlParameter ("@profileGuid", profileGuid ));

                    command.ExecuteNonQuery();

                }
            }
            catch(SqlException Sqle)
            {

            }
        }
    }
}
