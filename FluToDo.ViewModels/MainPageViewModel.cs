using FluToDo.Models.ServiceContracts;
using FluToDo.Models.ServicesContracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        public MainPageViewModel([Dependency] INavigationService navigationService, [Dependency] INetService netService):base(navigationService, netService)
        {

        }
       
    }
}
