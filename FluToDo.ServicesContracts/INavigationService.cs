using System;
using FluToDo.Models.ServicesContracts.Helpers;

namespace FluToDo.Models.ServicesContracts
{
    public interface INavigationService
    {
        void PushPage(Type ViewModel, NavigationArgument args =null, bool pushModal=false);
        void PopPage(NavigationArgument args = null, bool pushModal = false);
        void PopToRoot();
        void PagePopped(NavigationArgument args);
    }
}
