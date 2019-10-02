using System;
using System.Collections.Generic;
using System.Text;

namespace CoreApplications
{
    interface IStatusDataAccess
    {
        bool CreateStatus(string title);
        List<Status> GetStatus(int id);
        List<Status> GetAllStatus();
    }
}
