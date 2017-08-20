using FluToDo.ViewModels;
using Xamarin.Forms.Xaml;

namespace FluToDo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePage : BasePage
    {
		public CreatePage (object navigationArguments=null):base(navigationArguments)
        {
            this.ViewModel = Services.ServiceLocator.GetInstance<CreatePageViewModel>();
            this.ViewModel.NavigationArguments = NavigationArguments;
            InitializeComponent();
		}
	}
}