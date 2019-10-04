using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Data;

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
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public static bool InsertDefaultStatus()
        {
            string[] data = { "Received", "Open", "In progress", "Awaiting Customer", "Awaiting Approval", "On Hold", "Closed" };
            int i = 0;
            foreach (string status in data)
            {
                Console.WriteLine($"Inserted \"{status}\" into Status table");
                string query = $"INSERT INTO status (title) VALUES ('{status}')";
                SQLFunctions.ExecuteNonQuery(query);
                i++;
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ImportCustomers()
        {
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../companyData.csv";
            var data = File.ReadAllText(file);
            int i = 0;
            foreach (string row in data.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    string[] customer = row.Split(',');
                    string query = $"INSERT INTO customers (name,phone,email) VALUES ('{customer[0]}','{customer[1]}','{customer[2]}')";
                    Console.WriteLine(query);
                    SQLFunctions.ExecuteNonQuery(query);
                    i++;
                }
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ImportCustomerUsers()
        {
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../userData.csv";
            var data = File.ReadAllText(file);
            int i = 0;
            foreach (string row in data.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    string[] customer_user = row.Split(',');
                    string query = $"INSERT INTO customer_users (first_name,last_name,customer,phone,email) VALUES ('{customer_user[0]}','{customer_user[1]}',{customer_user[2]},'{customer_user[3]}','{customer_user[4]}')";
                    Console.WriteLine(query);
                    SQLFunctions.ExecuteNonQuery(query);
                    i++;
                }
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ImportEmployees()
        {
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../employeeData.csv";
            var data = File.ReadAllText(file);
            int i = 0;
            foreach (string row in data.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    string[] employee = row.Split(',');
                    string query = $"INSERT INTO employees (first_name,last_name,phone,email) VALUES ('{employee[0]}','{employee[1]}','{employee[2]}','{employee[3]}')";
                    Console.WriteLine(query);
                    SQLFunctions.ExecuteNonQuery(query);
                    i++;
                }
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ImportCases()
        {
            string file = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\../caseData.csv";
            var data = File.ReadAllText(file);
            int i = 0;
            foreach (string row in data.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    string[] import_case = row.Split('*');
                    string query = $"INSERT INTO cases (short_description,description,customer,customer_user,case_employee,status) VALUES ('{import_case[0]}','{import_case[1]}',(SELECT customer FROM customer_users WHERE id={import_case[2]}),{import_case[2]},{import_case[3]},{import_case[4]})";
                    SQLFunctions.ExecuteNonQuery(query);
                }
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
