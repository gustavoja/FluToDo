namespace FluToDo.Models.ServiceContracts
{
    public interface IDialogService
    {
            void DisplayAlert(string title, string text, string buttonText);
    }
}
