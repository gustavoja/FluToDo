using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Models.ServicesContracts
{
    public interface INavigationService
    {
        void PushPage(Type ViewModel, object args=null, bool pushModal=false);
        void PopPage(bool pushModal);
        void PopToRoot();
    }
}
