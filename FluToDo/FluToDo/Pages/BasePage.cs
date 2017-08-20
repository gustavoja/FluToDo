using FluToDo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FluToDo.Pages
{
    public class BasePage : ContentPage
    {
        #region bindable properties

        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create("ViewModel", typeof(object), typeof(object), true, propertyChanged: OnViewModelPropertyChanged);
        static void OnViewModelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bindable.BindingContext = newValue;
        }
        public BaseViewModel ViewModel
        {
            get { return (BaseViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        #endregion bindable properties

        public BasePage()
        {

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            return ViewModel.OnBackButtonPressed();
        }
    }
}
