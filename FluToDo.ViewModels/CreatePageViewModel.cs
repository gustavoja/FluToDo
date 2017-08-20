using FluToDo.Models.ServicesContracts;
using FluToDo.Models.Helpers.Localisation;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using FluToDo.Models.Entities;
using FluToDo.Models.ServicesContracts.Helpers;
using System.Collections.Generic;

namespace FluToDo.ViewModels
{
    public class CreatePageViewModel : BaseViewModel
    {
        #region Fields

        List<TodoItem> newListItems = new List<TodoItem>();

        #endregion Fields

        #region Properties

        private string itemText = "";
        public string ItemText
        {
            get { return itemText; }
            set
            {
                SetProperty(ref itemText, value);
                (CreateItemCommand as Command).ChangeCanExecute();
            }
        }

        #endregion Properties

        #region Commands

        private ICommand createItemCommand;
        public ICommand CreateItemCommand
        {
            get { return createItemCommand; }
            set { SetProperty(ref createItemCommand, value); }
        }
        #endregion Commands

        #region Constructor

        public CreatePageViewModel([Microsoft.Practices.Unity.Dependency] INavigationService navigationService, [Microsoft.Practices.Unity.Dependency] INetService netService, [Microsoft.Practices.Unity.Dependency] IDialogService dialogService) : base(navigationService, netService, dialogService)
        {
            Title = Strings.CreatePageTitle;
            CreateItemCommand = new Command(OnCreateItem, delegate () { return !string.IsNullOrEmpty(ItemText) && !string.IsNullOrWhiteSpace(ItemText); });
        }

        #endregion Constructor

        #region Handlers

        public override bool OnBackButtonPressed()
        {
            NavigationService.PopPage();
            return false;
        }

        private async void OnCreateItem()
        {
            TodoItem item = new TodoItem() { Name = itemText, IsComplete = false };
            try
            {
                var createditem = await NetService.Create(item);
                var itemList = await NetService.GetAll();
                //Get the updated list from the server to display it in order
                newListItems.Clear();
                newListItems.AddRange(itemList);
            }
            catch (Exception e)
            {
                DialogService.DisplayAlert(Strings.ConnectionFailed, e.Message, Strings.Ok);
            }

        }

        #endregion Handlers

        #region Lifecycle

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            NavigationService.PagePopped(new NavigationArgument(){Key= MainPageViewModel.RefreshListArgumentKey,Object=newListItems });
        }

        #endregion Lifecyle
    }
}
