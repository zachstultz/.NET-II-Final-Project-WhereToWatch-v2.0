using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDataAccess
{
    /// <summary>
    /// Handles our Database Connection.
    /// </summary>
    internal static class DBConnection
    {
        private static string connectionString =
            @"Data Source=localhost;Initial Catalog=wheretowatch_db;Integrated Security=True";

        public static SqlConnection GetDBConnection()
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
