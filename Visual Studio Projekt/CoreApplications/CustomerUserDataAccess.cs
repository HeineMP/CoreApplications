using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class CustomerUserDataAccess
    {
        public static void CreateCustomerUser(string fname, string lname, int company, string phone, string email)
        {
            var query = $"CALL create_customer_user('{fname}','{lname}',{company},'{phone}','{email}')";
            Program.ExecuteNonQuery(query);
        }
        public static void UpdateCustomerUser(int id, string fname, string lname, string phone, string email)
        {
            var query = $"CALL update_customer_user({id},'{fname}','{lname}','{phone}','{email}')";
            Program.ExecuteNonQuery(query);
        }
        public static void DeleteCustomerUser(int id)
        {
            var query = $"CALL delete_customer_user({id})";
            Program.ExecuteNonQuery(query);
        }
        public static List<CustomerUser> GetCustomerUser(int id)
        {
            var query = $"CALL get_customer_user({id})";
            var conn = Program.Connection();
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
        public static List<CustomerUser> GetAllCustomerUsers()
        {
            var query = $"CALL get_all_customer_users()";
            var conn = Program.Connection();
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
    }
}
