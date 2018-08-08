using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using OnlineStore.DataProvider.Repositories;
using OnlineStore.DataProvider.DataContext;
using OnlineStore.Model;

namespace OnlineStore.Website.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IServiceRepository>().To<EFServiceRepository>();
        }
    }
}