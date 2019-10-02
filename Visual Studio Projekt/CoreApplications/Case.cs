using System;

namespace CoreApplications
{
    class Case
    {
        public int id;
        public string short_description;
        public string description;
        public int customer;
        public Nullable<int> customer_user;
        public int case_employee;
        public int status;
        public Nullable<float> time_spent;
        public string hidden_information;
    }
}
