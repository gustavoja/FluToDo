using FluToDo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FluToDo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        public MainPage(object navigationArguments = null) : base(navigationArguments)
        {
            this.ViewModel = Services.ServiceLocator.GetInstance<MainPageViewModel>();
            this.ViewModel.NavigationArguments = NavigationArguments;
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}