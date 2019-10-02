using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications
{
    interface ICaseDataAccess
    {
        bool CreateCase(string short_description, string description, int customer, int customer_user, int case_employee, int status);
        List<Case> GetCase(int id);
        List<Case> GetAllCases();
        bool UpdateCase(int id, string short_description, string description, int customer, int customer_user, int case_employee, int status, float time_spent, string hidden_information);
        bool DeleteCase(int id);
    }
}
