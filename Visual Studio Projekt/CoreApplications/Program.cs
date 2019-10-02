using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CoreApplications
{

    class Program
    {   
        static void Main(string[] args)
        {

            var result = CaseDataAccess.GetAllCases();
            result.ForEach(i => Console.Write("ID: {0} Short Description: {1} Customer: {2} Customer User: {3} Case Employee: {4} Status: {5} Time Spent: {6}\n", i.id, i.description, i.customer, i.customer_user, i.case_employee, i.status, i.time_spent));

            //for GetCustomer
            //result.ForEach(i => Console.Write("ID: {0} Name: {1} Contact Person {2} Phone: {3} Email: {4}\n", i.id, i.name, i.contact_person, i.phone, i.email));

            //for GetCase
            //result.ForEach(i => Console.Write("ID: {0} Short Description: {1} Description: {2} Customer: {3} Customer User: {4} Case Employee: {5} Status: {6} Time Spent: {7} Hidden Information: {8}\n", i.id, i.short_description, i.description, i.customer, i.customer_user, i.case_employee, i.status, i.time_spent, i.hidden_information));

            //for GetCustomerUser & GetEmployee
            //result.ForEach(i => Console.Write("ID: {0} Name: {2}, {1} Phone: {3} Email: {4}\n", i.id, i.first_name, i.last_name, i.phone, i.email));

            //for GetAllStatus
            //result.ForEach(i => Console.Write("ID: {0} Title: {1}\n", i.id, i.title));

            //CreateCustomerUser("Bjarke", "Jensen", 1, "+4521215121", "lort@asda.dk");
            //CreateCustomerUser("Morten", "Jensen", 1, "+4521215121", "lort@qweq.dk");
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
        }

        public static void ExecuteNonQuery(string query)
        {
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var RowAffected = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
