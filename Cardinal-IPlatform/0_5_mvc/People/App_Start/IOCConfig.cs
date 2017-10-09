using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using People.IoC;
using People.Repositories;
using People.Services;
using System.Web.Mvc;

namespace People
{
    public class IOCConfig
    {
        public static void RegisterComponents()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IRepository, InMemoryRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRequests, RequestsService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPeopleLookup, PeopleLookupService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


        }
    }
}