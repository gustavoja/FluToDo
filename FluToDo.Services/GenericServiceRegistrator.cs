using FluToDo.Models.ServicesContracts;
using Microsoft.Practices.Unity;

namespace FluToDo.Models.Services
{
    public class GenericServiceRegistrator
    {
        private GenericServiceRegistrator()
        { }

        public static void Register(IUnityContainer ioc)
        {
            ioc.RegisterInstance<INetService>(new NetService());
            //Use Mock for offline debug
            //ioc.RegisterInstance<INetService>(new Mocks.MockNetService());
        }
    }
}
