using FluToDo.Models.ServiceContracts;
using Xamarin.Forms;

namespace FluToDo.Services
{
    public class DialogService : IDialogService
    {
        public void DisplayAlert(string title, string text, string buttonText)
        {
            Device.BeginInvokeOnMainThread(() =>
            App.Current.MainPage.DisplayAlert(title, text, buttonText));
        }
    }
}
