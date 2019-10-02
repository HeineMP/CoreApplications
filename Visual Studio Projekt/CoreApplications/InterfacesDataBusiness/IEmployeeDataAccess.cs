using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications
{
    interface IEmployeeDataAccess
    {
        bool CreateEmployee(string fname, string lname, string phone, string email);
        List<Employee> GetEmployee(int id);
        List<Employee> GetAllEmployees();
        bool UpdateEmployee(int id, string fname, string lname, string phone, string email);
    }
}
