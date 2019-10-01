using System;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateCustomerUser("Jens","Jensen",1,"+4521212121","lort@wow.dk");
        }

        public static void CreateCustomerUser(string fname, string lname, int company, string phone, string email)
        {
            var query = $"CALL create_customer_user('{fname}','{lname}',{company},'{phone}','{email}')";
            ExecuteQuery(query);
        }

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

        public static void ExecuteQuery(string query)
        {
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
