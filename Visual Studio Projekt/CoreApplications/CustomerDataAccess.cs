using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class CustomerDataAccess
    {
        public static void CreateCustomer(string name, string phone, string email)
        {
            var query = $"CALL create_customer('{name}','{phone}','{email}')";
            Program.ExecuteNonQuery(query);
        }
        public static void UpdateCustomer(int id, string name, int contact_person, string phone, string email)
        {
            var query = $"CALL update_customer({id},'{name}',{contact_person},'{phone}','{email}')";
            Program.ExecuteNonQuery(query);
        }
        public static void UpdateCustomerContactPerson(int id, int contact_person)
        {
            var query = $"CALL update_customer_contact_person({id},{contact_person})";
            Program.ExecuteNonQuery(query);
        }
        public static List<Customer> GetCustomer(int id)
        {
            var query = $"CALL get_customer({id})";
            var conn = Program.Connection();
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
    }
}
