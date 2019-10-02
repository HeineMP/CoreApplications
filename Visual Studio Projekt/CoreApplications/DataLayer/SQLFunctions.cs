using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class SQLFunctions
    {
        public static MySqlConnection Connection()
        {
            var connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = "172.16.240.240";
            connectionString.UserID = "svc_sqlconnect";
            connectionString.Password = "St7XmYZQhzmNL4ZY";
            connectionString.Database = "core_applications";

            var connection = new MySqlConnection(connectionString.ConnectionString);
            return connection;
        }

        public static bool ExecuteNonQuery(string query)
        {
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            int RowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return (RowsAffected > 0) ? true : false;
        }
    }
}
