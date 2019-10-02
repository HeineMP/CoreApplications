using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CoreApplications
{

    class Status
    {
        public int id;
        public string title;
    }
    class Employee
    {
        public int id;
        public string first_name;
        public string last_name;
        public string phone;
        public string email;
    }
    class Customer
    {
        public int id;
        public string name;
        public Nullable<int> contact_person;
        public string phone;
        public string email;
    }
    class CustomerUser
    {
        public int id;
        public string first_name;
        public string last_name;
        public int customer;
        public string phone;
        public string email;
    }
    class Case
    {
        public int id;
        public string short_description;
        public string description;
        public int customer;
        public Nullable<int> customer_user;
        public int case_employee;
        public int status;
        public Nullable<float> time_spent;
        public string hidden_information;
    }

    class Program
    {
        static void Main(string[] args)
        {

            var result = GetAllCases();
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
        public static List<Case> GetCase(int id)
        {
            var query = $"CALL get_case({id})";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Case>();
            while (result.Read())
            {
                Nullable<int> customer_user = (result.IsDBNull(4)) ? null : (int?)result.GetInt32("customer_user");
                Nullable<float> time_spent = (result.IsDBNull(7)) ? null : (float?)result.GetFloat("time_spent");
                string hidden_information = (result.IsDBNull(8)) ? null : (string?)result.GetString("hidden_information");

                resultArray.Add(
                    new Case
                    {
                        id = result.GetInt32("id"),
                        short_description = result.GetString("short_description"),
                        description = result.GetString("description"),
                        customer = result.GetInt32("customer"),
                        customer_user = customer_user,
                        case_employee = result.GetInt32("case_employee"),
                        status = result.GetInt32("status"),
                        time_spent = time_spent,
                        hidden_information = hidden_information
                    });
            }
            conn.Close();
            return resultArray;
        }
        public static List<Case> GetAllCases()
        {
            var query = $"CALL get_all_cases()";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Case>();
            while (result.Read())
            {
                Nullable<int> customer_user = (result.IsDBNull(4)) ? null : (int?)result.GetInt32("customer_user");
                Nullable<float> time_spent = (result.IsDBNull(7)) ? null : (float?)result.GetFloat("time_spent");

                resultArray.Add(
                    new Case
                    {
                        id = result.GetInt32("id"),
                        short_description = result.GetString("short_description"),
                        customer = result.GetInt32("customer"),
                        customer_user = customer_user,
                        case_employee = result.GetInt32("case_employee"),
                        status = result.GetInt32("status"),
                        time_spent = time_spent
                    });
            }
            conn.Close();
            return resultArray;
        }
        public static List<CustomerUser> GetCustomerUser(int id)
        {
            var query = $"CALL get_customer_user({id})";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<CustomerUser>();
            while (result.Read())
            {
                resultArray.Add(new CustomerUser { id = result.GetInt32("id"), first_name = result.GetString("first_name"), last_name = result.GetString("last_name"), phone = result.GetString("phone"), email = result.GetString("email") });
            }
            conn.Close();
            return resultArray;
        }
        public static List<Customer> GetCustomer(int id)
        {
            var query = $"CALL get_customer({id})";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Customer>();
            while (result.Read())
            {
                Nullable<int> contact_person = (result.IsDBNull(2)) ? null : (int?)result.GetInt32("contact_person");
                resultArray.Add(new Customer { 
                    id = result.GetInt32("id"),
                    name = result.GetString("name"),
                    contact_person = contact_person,
                    phone = result.GetString("phone"),
                    email = result.GetString("email")
                });
            }
            conn.Close();
            return resultArray;
        }
        public static List<Employee> GetEmployee(int id)
        {
            var query = $"CALL get_employee({id})";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Employee>();
            while (result.Read())
            {
                resultArray.Add(new Employee { id = result.GetInt32("id"), first_name = result.GetString("first_name"), last_name = result.GetString("last_name"), phone = result.GetString("phone"), email = result.GetString("email") });
            }
            conn.Close();
            return resultArray;
        }
        public static List<Status> GetStatus(int id)
        {
            var query = $"CALL get_status({id})";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Status>();
            while (result.Read())
            {
                resultArray.Add(new Status { id = result.GetInt32("id"), title = result.GetString("title") });
            }
            conn.Close();
            return resultArray;
        }
        public static List<Status> GetAllStatus()
        {
            var query = $"CALL get_all_status()";
            var conn = Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Status>();
            while (result.Read())
            {
                resultArray.Add (new Status { id = result.GetInt32("id"), title = result.GetString("title") });
            }
            conn.Close();
            return resultArray;
        }

    }
}
