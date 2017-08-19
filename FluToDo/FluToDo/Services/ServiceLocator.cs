using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using FluToDo.Models;

namespace FluToDo.Services
{
    public static class ServiceLocator
    {
        #region properties

        /// <summary>
        /// Can be used to register specific platform service to the ioc
        /// </summary>
        public static IUnityContainer Ioc { get { return ioc; } }
        private static UnityContainer ioc = new UnityContainer();

        #endregion properties

        #region methods

        public static void Initialize()
        {
            RegisterServices();
        }

        private static void RegisterServices()
        {
            //Register generic services located at the service project
            Models.Services.GenericServiceRegistrator.Register(Ioc);
        }

        public static T GetInstance<T>()
        {
            return Ioc.Resolve<T>();
        }

        #endregion methods
    }
}
