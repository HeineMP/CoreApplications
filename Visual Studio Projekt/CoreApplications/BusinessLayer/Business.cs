using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications.BusinessLayer
{
    class Business
    {
        public void GetCustomerUser(string search)
        {
            search = search.ToLower();
            ICustomerUserDataAccess data_access = new CustomerUserDataAccess();
            var data = data_access.GetAllCustomerUsers();
            var found_users = new List<CustomerUser>();
            foreach (var user in data)
            {
                if (user.email.ToLower().Contains(search) || user.first_name.ToLower().Contains(search) || user.last_name.ToLower().Contains(search) || (user.first_name+" "+user.last_name).ToLower().Contains(search))
                {
                    found_users.Add(new CustomerUser { id = user.id, first_name = user.first_name, last_name = user.last_name, customer = user.customer, phone = user.phone, email = user.email });
                }
            }
            found_users.ForEach(i => Console.Write("ID: {0} Name: {2}, {1} Phone: {3} Email: {4}\n", i.id, i.first_name, i.last_name, i.phone, i.email));
        }
        public void GetCustomer()
        {

        }
        public void CreateCase(string short_description, string description, int customer, int customer_user, int case_employee)
        {
            int status = 1;
            ICaseDataAccess data_access = new CaseDataAccess();
            data_access.CreateCase(short_description, description, customer, customer_user, case_employee, status);
        }
    }
}
