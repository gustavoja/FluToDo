using FluToDo.Models.ServiceContracts;
using FluToDo.Models.Helpers.Localisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.ViewModels
{
    public class CreatePageViewModel : BaseViewModel
    {
        #region Constructor

        public CreatePageViewModel([Microsoft.Practices.Unity.Dependency] INavigationService navigationService, [Microsoft.Practices.Unity.Dependency] INetService netService, [Microsoft.Practices.Unity.Dependency] IDialogService dialogService) : base(navigationService, netService, dialogService)
        {
            Title = Strings.CreatePageTitle;
        }

        #endregion Constructor
    }
}
