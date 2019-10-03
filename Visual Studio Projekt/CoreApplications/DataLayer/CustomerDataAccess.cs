using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class CustomerDataAccess : ICustomerDataAccess
    {
        public bool CreateCustomer(string name, string phone, string email)
        {
            var query = $"CALL create_customer('{name}','{phone}','{email}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public List<Customer> GetCustomer(int id)
        {
            var query = $"CALL get_customer({id})";
            var conn = SQLFunctions.Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Customer>();
            while (result.Read())
            {
                Nullable<int> contact_person = (result.IsDBNull(2)) ? null : (int?)result.GetInt32("contact_person");
                resultArray.Add(new Customer
                {
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
        public List<Customer> GetAllCustomers()
        {
            var query = $"CALL get_all_customers()";
            var conn = SQLFunctions.Connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            conn.Open();
            var result = cmd.ExecuteReader();
            var resultArray = new List<Customer>();
            while (result.Read())
            {
                Nullable<int> contact_person = (result.IsDBNull(2)) ? null : (int?)result.GetInt32("contact_person");
                resultArray.Add(new Customer
                {
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
        public bool UpdateCustomer(int id, string name, Nullable<int> contact_person, string phone, string email)
        {
            var query = $"CALL update_customer({id},'{name}',{contact_person},'{phone}','{email}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public bool UpdateCustomerContactPerson(int id, int contact_person)
        {
            var query = $"CALL update_customer_contact_person({id},{contact_person})";
            return SQLFunctions.ExecuteNonQuery(query);
        }
    }
}
