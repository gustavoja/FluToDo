using FluToDo.Models.ServicesContracts;
using FluToDo.ViewModels;
using System;

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
            switch (ViewModel.Name)
            {
                case nameof(MainPageViewModel):
                    var newPage = new Pages.MainPage();
                    if (App.Current.MainPage != null)
                    {
                        if (!modalPush)
                        {
                            App.Current.MainPage.Navigation.PushAsync(newPage);
                        }
                        else
                        {
                            App.Current.MainPage.Navigation.PushModalAsync(newPage);
                        }
                    }
                    else
                    {
                        App.Current.MainPage = newPage;
                    }
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
    }
}
