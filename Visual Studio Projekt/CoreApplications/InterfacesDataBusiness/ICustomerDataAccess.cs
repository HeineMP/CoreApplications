using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications
{
    interface ICustomerDataAccess
    {
        bool CreateCustomer(string name, string phone, string email);
        List<Customer> GetCustomer(int id);
        List<Customer> GetAllCustomers();
        bool UpdateCustomer(int id, string name, Nullable<int> contact_person, string phone, string email);
        bool UpdateCustomerContactPerson(int id, int contact_person);
    }
}
