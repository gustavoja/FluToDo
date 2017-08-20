using FluToDo.Models.ServiceContracts;
using FluToDo.Pages;
using FluToDo.ViewModels;
using System;
using Xamarin.Forms;

namespace FluToDo.Services
{
    public class NavigationService : INavigationService
    {
        public void PopPage(bool modalPush = false)
        {
            if (App.Current.MainPage != null && App.Current.MainPage.Navigation.NavigationStack.Count>1)
            {
                if (!modalPush)
                {
                    App.Current.MainPage.Navigation.PopAsync();
                }
                else
                {
                    App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
        }

        public void PushPage(Type ViewModel, object args = null, bool modalPush = false)
        {
            BasePage newPage;
            switch (ViewModel.Name)
            {
                case nameof(MainPageViewModel):
                    newPage = new MainPage();
                    if (App.Current.MainPage != null)
                    {
                        Push(newPage, modalPush);
                    }
                    else
                    {
                        App.Current.MainPage = newPage;
                    }
                    break;

                case nameof(CreatePageViewModel):
                    newPage = new CreatePage();
                    Push(newPage, modalPush);
                    break;
                default:
                    break;
            }
        }

        public void PopToRoot()
        {
            if (App.Current.MainPage != null)
                App.Current.MainPage.Navigation.PopToRootAsync();
        }

        private void Push(ContentPage page, bool modalPush)
        {
            if (!modalPush)
            {
                App.Current.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                App.Current.MainPage.Navigation.PushModalAsync(page);
            }
        }
    }
}
