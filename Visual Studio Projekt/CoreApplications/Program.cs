using System;
using System.Collections.Generic;

namespace CoreApplications
{

    class Program
    {
        static void Main(string[] args)
        {
            SQLFunctions.ImportCases();
            //SQLFunctions.WriteConfig("172.16.240.240", "svc_sqlconnect", "St7XmYZQhzmNL4ZY", "core_applications");
            
            //BusinessLayer.Business test = new BusinessLayer.Business();
            //test.SearchCases("test",true).ForEach(i => Console.Write("ID: {0} Short Description: {1} Customer User: {2}\n", i.id, i.short_description, i.customer_user));
            
            //StatusDataAccess result = new StatusDataAccess();
            //Console.WriteLine(result.CreateStatus("Test asdasd"));
            //result.ForEach(i => Console.Write("ID: {0} Short Description: {1} Customer: {2} Customer User: {3} Case Employee: {4} Status: {5} Time Spent: {6}\n", i.id, i.short_description, i.customer, i.customer_user, i.case_employee, i.status, i.time_spent));

            //for GetCustomer
            //result.ForEach(i => Console.Write("ID: {0} Name: {1} Contact Person {2} Phone: {3} Email: {4}\n", i.id, i.name, i.contact_person, i.phone, i.email));

            //for GetCase
            //result.ForEach(i => Console.Write("ID: {0} Short Description: {1} Description: {2} Customer: {3} Customer User: {4} Case Employee: {5} Status: {6} Time Spent: {7} Hidden Information: {8}\n", i.id, i.short_description, i.description, i.customer, i.customer_user, i.case_employee, i.status, i.time_spent, i.hidden_information));

            //for GetCustomerUser & GetEmployee
            //result2.ForEach(i => Console.Write("ID: {0} Name: {2}, {1} Phone: {3} Email: {4}\n", i.id, i.first_name, i.last_name, i.phone, i.email));

            //for GetAllStatus
            //result.ForEach(i => Console.Write("ID: {0} Title: {1}\n", i.id, i.title));

            //CreateCustomerUser("Bjarke", "Jensen", 1, "+4521215121", "lort@asda.dk");
            //CreateCustomerUser("Morten", "Jensen", 1, "+4521215121", "lort@qweq.dk");
        }
    }
}
