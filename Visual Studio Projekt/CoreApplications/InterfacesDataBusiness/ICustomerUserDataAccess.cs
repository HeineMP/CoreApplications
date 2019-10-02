using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications
{
    interface ICustomerUserDataAccess
    {
        bool CreateCustomerUser(string fname, string lname, int company, string phone, string email);
        List<CustomerUser> GetCustomerUser(int id);
        List<CustomerUser> GetAllCustomerUsers();
        bool UpdateCustomerUser(int id, string fname, string lname, string phone, string email);
        bool DeleteCustomerUser(int id);
    }
}
