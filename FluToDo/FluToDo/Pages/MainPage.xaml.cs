using FluToDo.ViewModels;
using Xamarin.Forms.Xaml;

namespace FluToDo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : BasePage
    {
        public MainPage()
        {
            this.ViewModel = Services.ServiceLocator.GetInstance<MainPageViewModel>();
            InitializeComponent();
        }
    }
}