using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class CaseDataAccess
    {
        public static void CreateCase(string short_description, string description, int customer, int customer_user, int case_employee, int status)
        {
            var query = $"CALL create_case('{short_description}','{description}',{customer},{customer_user},{case_employee},{status})";
            Program.ExecuteNonQuery(query);
        }
        public static void UpdateCase(int id, string short_description, string description, int customer, int customer_user, int case_employee, int status, float time_spent, string hidden_information)
        {
            var query = $"CALL update_case({id},'{short_description}','{description}',{customer},{customer_user},{case_employee},{status},{time_spent},'{hidden_information}')";
            Program.ExecuteNonQuery(query);
        }
        public static void DeleteCase(int id)
        {
            var query = $"CALL delete_case({id})";
            Program.ExecuteNonQuery(query);
        }
        public static List<Case> GetCase(int id)
        {
            var query = $"CALL get_case({id})";
            var conn = Program.Connection();
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
            var conn = Program.Connection();
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
    }
}
