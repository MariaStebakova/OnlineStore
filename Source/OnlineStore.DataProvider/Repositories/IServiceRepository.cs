﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Model;

namespace OnlineStore.DataProvider.Repositories
{
    public interface IServiceRepository
    {
        IEnumerable<Service> Services { get; }
        void SaveService(Service service);
        Service DeleteService(int serviceId);
    }
}
