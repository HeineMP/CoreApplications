using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class EmployeeDataAccess : IEmployeeDataAccess
    {
        public bool CreateEmployee(string fname, string lname, string phone, string email)
        {
            var query = $"CALL create_employee('{fname}','{lname}','{phone}','{email}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public List<Employee> GetEmployee(int id)
        {
            var query = $"CALL get_employee({id})";
            var conn = SQLFunctions.Connection();
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
        public List<Employee> GetAllEmployees()
        {
            var query = $"CALL get_all_employees()";
            var conn = SQLFunctions.Connection();
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
        public bool UpdateEmployee(int id, string fname, string lname, string phone, string email)
        {
            var query = $"CALL update_employee({id},'{fname}','{lname}','{phone}','{email}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
    }
}
