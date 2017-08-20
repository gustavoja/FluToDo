using FluToDo.ViewModels;
using Xamarin.Forms.Xaml;

namespace FluToDo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePage : BasePage
    {
		public CreatePage ()
        {
            this.ViewModel = Services.ServiceLocator.GetInstance<CreatePageViewModel>();
            InitializeComponent();
		}
	}
}