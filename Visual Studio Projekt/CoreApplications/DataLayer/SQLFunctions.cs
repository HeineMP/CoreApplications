using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CoreApplications
{
    class SQLFunctions
    {
        public static string[] ReadConfig()
        {
            string[] config = new string[4];
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../config.json";
            var json = File.ReadAllText(file);
            var json_object = JObject.Parse(json);
            if (json_object != null)
            {
                config[0] = Convert.ToString(json_object["Server"]);
                config[1] = Convert.ToString(json_object["UserID"]);
                config[2] = Convert.ToString(json_object["Password"]);
                config[3] = Convert.ToString(json_object["Database"]);
            }
            return config;
        }
        public static bool WriteConfig(string server, string user_id, string password, string database)
        {
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../config.json";
            var json = File.ReadAllText(file);
            var json_object = JObject.Parse(json);
            json_object["Server"] = server;
            json_object["UserID"] = user_id;
            json_object["Password"] = password;
            json_object["Database"] = database;
            try
            {
                File.WriteAllText(file, Newtonsoft.Json.JsonConvert.SerializeObject(json_object, Newtonsoft.Json.Formatting.Indented));
                return true;
            } catch
            {
                return false;
            }
        }
        public static bool CreateDBTablesAndProcedures()
        {
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../initialDatabaseSetup.txt";
            var query = File.ReadAllText(file);
            //Console.WriteLine(query);
            return SQLFunctions.ExecuteNonQuery(query);
            //return true;
        }
        public static MySqlConnection Connection()
        {
            var config = ReadConfig();
            var connectionString = new MySqlConnectionStringBuilder();
            connectionString.Server = config[0];
            connectionString.UserID = config[1];
            connectionString.Password = config[2];
            connectionString.Database = config[3];

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
