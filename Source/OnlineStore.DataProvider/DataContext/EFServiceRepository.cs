using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.Model;

namespace OnlineStore.DataProvider.DataContext
{
    public class EFServiceRepository: IServiceRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Service> Services
        {
            get { return context.Services; }
        }
    }
}
