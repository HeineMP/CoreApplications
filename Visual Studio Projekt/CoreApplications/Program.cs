using System;
using MySql.Data.MySqlClient;

namespace CoreApplications
{

    class Status
    {
        public int id;
        public string title;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = GetAllStatus();
            foreach (var item in result)
            {
                Console.WriteLine($"ID: {item.id} Title: {item.title}");
            }
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

        public static void CreateCustomer(string name, string phone, string email)
        {
            var query = $"CALL create_customer('{name}','{phone}','{email}')";
            ExecuteNonQuery(query);
        }
        public static void CreateCustomerUser(string fname, string lname, int company, string phone, string email)
        {
            var query = $"CALL create_customer_user('{fname}','{lname}',{company},'{phone}','{email}')";
            ExecuteNonQuery(query);
        }
        public static void CreateEmployee(string fname, string lname, string phone, string email)
        {
            var query = $"CALL create_employee('{fname}','{lname}','{phone}','{email}')";
            ExecuteNonQuery(query);
        }
        public static void CreateStatus(string title)
        {
            var query = $"CALL create_status('{title}')";
            ExecuteNonQuery(query);
        }
        public static void CreateCase(string short_description, string description, int customer, int customer_user, int case_employee, int status)
        {
            var query = $"CALL create_case('{short_description}','{description}',{customer},{customer_user},{case_employee},{status})";
            ExecuteNonQuery(query);
        }
        public static void UpdateCase(int id, string short_description, string description, int customer, int customer_user, int case_employee, int status, float time_spent, string hidden_information)
        {
            var query = $"CALL update_case({id},'{short_description}','{description}',{customer},{customer_user},{case_employee},{status},{time_spent},'{hidden_information}')";
            ExecuteNonQuery(query);
        }
        public static void UpdateCustomer(int id, string name, int contact_person, string phone, string email)
        {
            var query = $"CALL update_customer({id},'{name}',{contact_person},'{phone}','{email}')";
            ExecuteNonQuery(query);
        }
        public static void UpdateCustomerContactPerson(int id, int contact_person)
        {
            var query = $"CALL update_customer_contact_person({id},{contact_person})";
            ExecuteNonQuery(query);
        }
        public static void UpdateCustomerUser(int id, string fname, string lname, string phone, string email)
        {
            var query = $"CALL update_customer_user({id},'{fname}','{lname}','{phone}','{email}')";
            ExecuteNonQuery(query);
        }
        public static void UpdateEmployee(int id, string fname, string lname, string phone, string email)
        {
            var query = $"CALL update_employee({id},'{fname}','{lname}','{phone}','{email}')";
            ExecuteNonQuery(query);
        }

        public static void DeleteCustomerUser(int id)
        {
            var query = $"CALL delete_customer_user({id})";
            ExecuteNonQuery(query);
        }
        public static void DeleteCase(int id)
        {
            var query = $"CALL delete_case({id})";
            ExecuteNonQuery(query);
        }
        public static void GetCase(int id)
        {
            var query = $"CALL get_case({id})";
            ExecuteNonQuery(query);
        }
        public static void GetCustomerUser(int id)
        {
            var query = $"CALL get_customer_user({id})";
            ExecuteNonQuery(query);
        }
        public static void GetCustomer(int id)
        {
            var query = $"CALL get_customer({id})";
            ExecuteNonQuery(query);
        }
        public static void GetEmployee(int id)
        {
            var query = $"CALL get_employee({id})";
            ExecuteNonQuery(query);
        }
        public static void GetStatus(int id)
        {
            var query = $"CALL get_status({id})";
            ExecuteNonQuery(query);
        }
        public static Status[] GetAllStatus()
        {
            var query = $"CALL get_all_status()";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            Status[] resultArray = new Status[];
            int i = 0;
            while (result.Read())
            {
                resultArray[i] = new Status();
                resultArray[i].id = result.GetInt32("id");
                resultArray[i].title = result.GetString("title");
                i++;
            }
            conn.Close();
            return resultArray;
        }

    }
}
