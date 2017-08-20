using FluToDo.Models.ServicesContracts.Helpers;
using FluToDo.ViewModels;
using Xamarin.Forms.Xaml;

namespace FluToDo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePage : BasePage
    {
		public CreatePage (NavigationArgument navigationArguments =null):base(navigationArguments)
        {
            this.ViewModel = Services.ServiceLocator.GetInstance<CreatePageViewModel>();
            this.ViewModel.NavigationArgument = NavigationArguments;
            InitializeComponent();
		}
	}
}