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
        private ApplicationContext context;

        public EFServiceRepository(ApplicationContext db)
        {
            context = db;
        }

        public IEnumerable<Service> Services
        {
            get { return context.Services.ToList(); }
        }

        public void SaveService(Service service)
        {
            if (service.ServiceId == 0)
                context.Services.Add(service);
            else
            {
                Service dbEntry = context.Services.Find(service.ServiceId);
                if (dbEntry != null)
                {
                    dbEntry.Name = service.Name;
                    dbEntry.Description = service.Description;
                    dbEntry.Price = service.Price;
                    dbEntry.ServiceType = service.ServiceType;
                    dbEntry.ImageData = service.ImageData;
                    dbEntry.ImageMimeType = service.ImageMimeType;
                }
            }
            context.SaveChanges();
        }

        public Service DeleteService(int serviceId)
        {
            Service dbEntry = context.Services.Find(serviceId);
            if (dbEntry != null)
            {
                context.Services.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }




    }
}
