using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications.BusinessLayer
{
    class Business
    {
        public List<CustomerUser> SearchCustomerUser(string search) // Search all customer users and return what contains search string
        {
            search = search.ToLower();
            ICustomerUserDataAccess data_access = new CustomerUserDataAccess();
            var data = data_access.GetAllCustomerUsers();
            var found_users = new List<CustomerUser>();
            foreach (var user in data)
            {
                if (user.email.ToLower().Contains(search) || user.first_name.ToLower().Contains(search) || user.last_name.ToLower().Contains(search) || (user.first_name+" "+user.last_name).ToLower().Contains(search))
                {
                    found_users.Add(new CustomerUser {
                        id = user.id,
                        first_name = user.first_name,
                        last_name = user.last_name,
                        customer = user.customer,
                        phone = user.phone,
                        email = user.email
                    });
                }
            }
            return found_users;
        }
        public List<Customer> SearchCustomer(string search) // Search all customers and return what contains search string
        {
            search = search.ToLower();
            ICustomerDataAccess data_access = new CustomerDataAccess();
            var data = data_access.GetAllCustomers();
            var found_customers = new List<Customer>();
            foreach (var customer in data)
            {
                if (customer.name.ToLower().Contains(search) || customer.phone.ToLower().Contains(search) || customer.email.ToLower().Contains(search))
                {
                    found_customers.Add(new Customer {
                        id = customer.id,
                        name = customer.name,
                        contact_person = customer.contact_person,
                        phone = customer.phone,
                        email = customer.email
                    });
                }
            }
            return found_customers;
        }
        public List<Case> SearchCases(string search, bool closed)
        {
            search = search.ToLower();
            ICaseDataAccess data_access = new CaseDataAccess();
            var data = data_access.GetAllCases();
            var found_cases = new List<Case>();
            int counter = 0;
            int closed_id = 0;
            if (closed == false)
            {
                closed_id = SearchStatus("closed");
            }
            foreach (var case_item in data)
            {
                if (closed == false)
                {
                    if (case_item.status == closed_id)
                    {
                        continue;
                    }
                }
                if (Convert.ToString(case_item.id) == search || case_item.short_description.ToLower().Contains(search) || case_item.description.ToLower().Contains(search))
                {
                    found_cases.Add(new Case { 
                        id = case_item.id,
                        short_description = case_item.short_description,
                        description = case_item.description,
                        customer = case_item.customer,
                        customer_user = case_item.customer_user,
                        case_employee = case_item.case_employee,
                        status = case_item.status
                    });
                    counter++;
                }
            }
            if (counter == 0)
            {
                var found_users = SearchCustomerUser(search);
                foreach (var case_item in data)
                {
                    foreach (var user in found_users)
                    {
                        if (case_item.customer_user == user.id)
                        {
                            found_cases.Add(new Case {
                                id = case_item.id,
                                short_description = case_item.short_description,
                                description = case_item.description,
                                customer = case_item.customer,
                                customer_user = case_item.customer_user,
                                case_employee = case_item.case_employee,
                                status = case_item.status
                            });
                        }
                    }
                }
            }
            return found_cases;
        }
        public int SearchStatus(string search)
        {
            IStatusDataAccess data_access = new StatusDataAccess();
            var data = data_access.GetAllStatus();
            int id = 0;
            foreach (var status in data)
            {
                if (status.title.ToLower() == search.ToLower())
                {
                    id = status.id;
                    break;
                }
            }
            return id;
        }
        public List<Case> GetCase(int id) // Get case by id
        {
            ICaseDataAccess data_access = new CaseDataAccess();
            return data_access.GetCase(id);
        }
        public List<Customer> GetCustomer(int id)
        {
            ICustomerDataAccess data_access = new CustomerDataAccess();
            return data_access.GetCustomer(id);
        }
        public List<CustomerUser> GetCustomerUser(int id)
        {
            ICustomerUserDataAccess data_access = new CustomerUserDataAccess();
            return data_access.GetCustomerUser(id);
        }
        public bool CreateCase(string short_description, string description, int customer, int customer_user, int case_employee)
        {
            int status = 1;
            ICaseDataAccess data_access = new CaseDataAccess();
            return data_access.CreateCase(short_description, description, customer, customer_user, case_employee, status);
        }
        public bool UpdateCase(int id, string short_description, string description, int customer, int customer_user, int case_employee, int status, float time_spent, string hidden_information)
        {
            ICaseDataAccess data_access = new CaseDataAccess();
            return data_access.UpdateCase(id, short_description, description, customer, customer_user, case_employee, status, time_spent, hidden_information);
        }
        public bool UpdateCustomer(int id, string name, Nullable<int> contact_person, string phone, string email)
        {
            ICustomerDataAccess data_access = new CustomerDataAccess();
            return data_access.UpdateCustomer(id, name, contact_person, phone, email);
        }
    }
}
