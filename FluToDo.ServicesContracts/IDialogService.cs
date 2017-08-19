using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo.Models.ServicesContracts
{
    public interface IDialogService
    {
            void DisplayAlert(string title, string text, string buttonText);
    }
}
