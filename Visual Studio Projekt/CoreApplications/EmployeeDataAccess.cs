using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class EmployeeDataAccess
    {
        public static void CreateEmployee(string fname, string lname, string phone, string email)
        {
            var query = $"CALL create_employee('{fname}','{lname}','{phone}','{email}')";
            Program.ExecuteNonQuery(query);
        }
        public static void UpdateEmployee(int id, string fname, string lname, string phone, string email)
        {
            var query = $"CALL update_employee({id},'{fname}','{lname}','{phone}','{email}')";
            Program.ExecuteNonQuery(query);
        }
        public static List<Employee> GetEmployee(int id)
        {
            var query = $"CALL get_employee({id})";
            var conn = Program.Connection();
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
        public static List<Employee> GetAllEmployees()
        {
            var query = $"CALL get_all_employees()";
            var conn = Program.Connection();
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
    }
}
