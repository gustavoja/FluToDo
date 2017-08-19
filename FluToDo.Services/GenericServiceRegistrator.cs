using FluToDo.Models.ServiceContracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Models.Services
{
    public class GenericServiceRegistrator
    {
        private GenericServiceRegistrator()
        { }

        public static void Register(IUnityContainer ioc)
        {
            ioc.RegisterInstance<INetService>(new NetService());
        }
    }
}
