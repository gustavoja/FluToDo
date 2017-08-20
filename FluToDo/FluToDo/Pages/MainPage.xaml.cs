using FluToDo.Models.ServicesContracts.Helpers;
using FluToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FluToDo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        public MainPage(NavigationArgument navigationArguments = null) : base(navigationArguments)
        {
            this.ViewModel = Services.ServiceLocator.GetInstance<MainPageViewModel>();
            this.ViewModel.NavigationArgument = NavigationArguments;
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}