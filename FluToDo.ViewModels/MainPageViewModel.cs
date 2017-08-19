using FluToDo.Models.ServiceContracts;
using FluToDo.Models.ServicesContracts;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluToDo.Models.Helpers.Localisation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FluToDo.Models.Entities;
using FluToDo.Models.Helpers.Localisation;

namespace FluToDo.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        #region Commands
        
        private ICommand synchronizeCommand;
        public ICommand SynchronizeCommand
        {
            get { return synchronizeCommand; }
            set { SetProperty(ref synchronizeCommand, value); }
        }
        #endregion Commands

        #region Porperties

        #endregion Porperties

        #region Porperties

        private ObservableCollection<TodoItem> itemList = new ObservableCollection<TodoItem>();
        public ObservableCollection<TodoItem> ItemList
        {
            get { return itemList; }
            set { SetProperty(ref itemList, value); }
        }

        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        #endregion Porperties

        #region Constructor

        public MainPageViewModel([Microsoft.Practices.Unity.Dependency] INavigationService navigationService, [Microsoft.Practices.Unity.Dependency] INetService netService, [Microsoft.Practices.Unity.Dependency] IDialogService dialogService) :base(navigationService, netService, dialogService)
        {
            //Referencing Xmarin.Forms to use the Command implementation
            SynchronizeCommand = new Command(Synchornize);
            Title = Strings.FluToDo;

            SynchronizeCommand.Execute(null);
        }

        #endregion Constructor

        #region Methods

        private async void Synchornize()
        {
            IsRefreshing = true;
            try
            {
                await Task.Delay(1000);
                var list = await NetService.GetAll() as IEnumerable<TodoItem>;
                ItemList = new ObservableCollection<TodoItem>(list);
            }
            catch (Exception e)
            {
                DialogService.DisplayAlert(Strings.ConnectionFailed, e.Message, Strings.Ok);
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        #endregion Methods



    }
}
