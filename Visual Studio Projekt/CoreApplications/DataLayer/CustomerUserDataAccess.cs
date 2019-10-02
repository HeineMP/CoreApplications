using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class CustomerUserDataAccess : ICustomerUserDataAccess
    {
        public bool CreateCustomerUser(string fname, string lname, int company, string phone, string email)
        {
            var query = $"CALL create_customer_user('{fname}','{lname}',{company},'{phone}','{email}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public List<CustomerUser> GetCustomerUser(int id)
        {
            var query = $"CALL get_customer_user({id})";
            var conn = SQLFunctions.Connection();
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
        public List<CustomerUser> GetAllCustomerUsers()
        {
            var query = $"CALL get_all_customer_users()";
            var conn = SQLFunctions.Connection();
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
        public bool UpdateCustomerUser(int id, string fname, string lname, string phone, string email)
        {
            var query = $"CALL update_customer_user({id},'{fname}','{lname}','{phone}','{email}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public bool DeleteCustomerUser(int id)
        {
            var query = $"CALL delete_customer_user({id})";
            return SQLFunctions.ExecuteNonQuery(query);
        }
    }
}
