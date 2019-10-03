using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications.InterfacesBusinessPresentation
{
    interface IBusiness
    {
        public List<CustomerUser> SearchCustomerUser(string search);
        public List<Customer> SearchCustomer(string search);
        public List<Case> SearchCases(string search, bool closed);
        public int SearchStatus(string search);
        public List<Case> GetCase(int id);
        public List<Customer> GetCustomer(int id);
        public List<CustomerUser> GetCustomerUser(int id);
        public bool CreateCase(string short_description, string description, int customer, int customer_user, int case_employee);
        public bool UpdateCase(int id, string short_description, string description, int customer, int customer_user, int case_employee, int status, float time_spent, string hidden_information);
        public bool UpdateCustomer(int id, string name, Nullable<int> contact_person, string phone, string email);
    }
}
