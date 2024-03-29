﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreApplications
{
    class StatusDataAccess : IStatusDataAccess
    {
        public bool CreateStatus(string title)
        {
            var query = $"CALL create_status('{title}')";
            return SQLFunctions.ExecuteNonQuery(query);
        }
        public List<Status> GetStatus(int id)
        {
            var query = $"CALL get_status({id})";
            var conn = SQLFunctions.Connection();
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
        public List<Status> GetAllStatus()
        {
            var query = $"CALL get_all_status()";
            var conn = SQLFunctions.Connection();
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
    }
}
