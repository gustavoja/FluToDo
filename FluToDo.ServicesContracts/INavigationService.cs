using System;
namespace FluToDo.Models.ServiceContracts
{
    public interface INavigationService
    {
        void PushPage(Type ViewModel, object args=null, bool pushModal=false);
        void PopPage(bool pushModal);
        void PopToRoot();
    }
}
