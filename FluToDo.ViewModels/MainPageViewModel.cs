using FluToDo.Models.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluToDo.Models.Helpers.Localisation;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using FluToDo.Models.Entities;

namespace FluToDo.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        #region Fields

        List<TodoItem> EntityItemList;

        #endregion Fields

        #region Commands

        private ICommand synchronizeCommand;
        public ICommand SynchronizeCommand
        {
            get { return synchronizeCommand; }
            set { SetProperty(ref synchronizeCommand, value); }
        }

        private ICommand itemTappedCommand;
        public ICommand ItemTappedCommand
        {
            get { return itemTappedCommand; }
            set { SetProperty(ref itemTappedCommand, value); }
        }

        private ICommand itemDeletedCommand;
        public ICommand ItemDeletedCommand
        {
            get { return itemDeletedCommand; }
            set { SetProperty(ref itemDeletedCommand, value); }
        }

        private ICommand newItemClickedCommand;
        public ICommand NewItemClickedCommand
        {
            get { return newItemClickedCommand; }
            set { SetProperty(ref newItemClickedCommand, value); }
        }

        #endregion Commands

        #region Porperties

        private ObservableCollection<TodoItemViewModel> itemList = new ObservableCollection<TodoItemViewModel>();
        public ObservableCollection<TodoItemViewModel> ItemList
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

        public MainPageViewModel([Microsoft.Practices.Unity.Dependency] INavigationService navigationService, [Microsoft.Practices.Unity.Dependency] INetService netService, [Microsoft.Practices.Unity.Dependency] IDialogService dialogService) : base(navigationService, netService, dialogService)
        {
            SynchronizeCommand = new Command(OnSynchornize);
            ItemTappedCommand = new Command<object>(OnItemTapped);
            ItemDeletedCommand = new Command<object>(OnItemDeleted);
            NewItemClickedCommand = new Command(OnNewItemClicked);
            Title = Strings.FluToDo;

            SynchronizeCommand.Execute(null);
        }

        #endregion Constructor

        #region Handlers

        private async void OnSynchornize()
        {
            IsRefreshing = true;
            try
            {
                await Task.Delay(1000);
                EntityItemList = await NetService.GetAll();
                var vmList = EntityItemList.Select(i => new TodoItemViewModel(i)).ToList();
                if (ItemList != null)
                    ItemList.Clear();
                ItemList = new ObservableCollection<TodoItemViewModel>(vmList.AsEnumerable());
            }
            catch (Exception e)
            {
                DialogService.DisplayAlert(Strings.ConnectionFailed, e.Message, Strings.Ok);
            }
            finally
            {
                IsRefreshing = false;
#if debug
                var listN = new List<TodoItem>();
                listN.Add(new TodoItem() { Name = "1sdfjdfhasdfhdfdafhaskdjlfhasfjkhadsjklfhadsfjkldashfljkadshfasdhjklfdhsjfjhasdfhasdjklfajsdjhfasdjklfdjkl", IsComplete = true, Key = "0" });
                listN.Add(new TodoItem() { Name = "2dsfadfdasf", IsComplete = false, Key = "1" });
                listN.Add(new TodoItem() { Name = "3asdfadsfasdfadsf", IsComplete = true, Key = "2" });
                listN.Add(new TodoItem() { Name = "4asdfasdfsdafdsfdfasdfdfdsfdfdsafasdgfdgdgdadgasddfdsfadsfadfadsafdfs", IsComplete = false, Key = "3" });
                EntityItemList = listN;
                List<TodoItemViewModel> vmList1 = EntityItemList.Select(i => new TodoItemViewModel(i)).ToList();
                ItemList = new ObservableCollection<TodoItemViewModel>(vmList1.AsEnumerable());
#endif
            }
        }

        private async void OnItemTapped(object eventArg)
        {
            var arg = eventArg as ItemTappedEventArgs;
            var index = ItemList.IndexOf(arg.Item as TodoItemViewModel);

            try
            {
                ItemList.ElementAt(index).IsBusy = true;
                var todoItem = new TodoItem() { Key = EntityItemList.ElementAt(index).Key, Name = EntityItemList.ElementAt(index).Name, IsComplete = !EntityItemList.ElementAt(index).IsComplete };
                var updated = await NetService.Update(todoItem, todoItem.Key);
                if (updated)
                {
                    EntityItemList.ElementAt(index).IsComplete = todoItem.IsComplete;
                    ItemList.ElementAt(index).IsComplete = todoItem.IsComplete;
                }
                else
                {
                    DialogService.DisplayAlert(Strings.Failed, string.Format(Strings.UpdatedIncorrectly, todoItem.Name), Strings.Ok);
                }
            }
            catch (Exception e)
            {
                DialogService.DisplayAlert(Strings.ConnectionFailed, e.Message, Strings.Ok);
            }
            finally
            {
                ItemList.ElementAt(index).IsBusy = false;           
                #if debug
                var todoItem1 = new TodoItem() { Key = EntityItemList.ElementAt(index).Key, Name = EntityItemList.ElementAt(index).Name, IsComplete = !EntityItemList.ElementAt(index).IsComplete };
                EntityItemList.ElementAt(index).IsComplete = todoItem1.IsComplete;
                ItemList.ElementAt(index).IsComplete = todoItem1.IsComplete;
                #endif 
            }
        }

        private async void OnItemDeleted(object eventArg)
        {
            var index = ItemList.IndexOf(eventArg as TodoItemViewModel);
            try
            {
                ItemList.ElementAt(index).IsBusy = true;
                var todoItem = EntityItemList.ElementAt(index);
                var deleted = await NetService.Delete(todoItem);
                if (deleted)
                {
                    ItemList.RemoveAt(index);
                    EntityItemList.RemoveAt(index);
                    DialogService.DisplayAlert(Strings.Succesful, string.Format(Strings.DeletedCorrectly, todoItem.Name), Strings.Ok);
                }
                else
                {
                    ItemList.ElementAt(index).IsBusy = false;
                    DialogService.DisplayAlert(Strings.Failed, string.Format(Strings.DeletedIncorrectly, todoItem.Name), Strings.Ok);
                }
            }
            catch (Exception e)
            {
                ItemList.ElementAt(index).IsBusy = false;
                DialogService.DisplayAlert(Strings.ConnectionFailed, e.Message, Strings.Ok);

                #if debug
                EntityItemList.RemoveAt(index);
                ItemList.RemoveAt(index);
                #endif 
            }

        }

        private void OnNewItemClicked(object eventArg)
        {
            NavigationService.PushPage(typeof(CreatePageViewModel));
        }

        #endregion Handlers
    }
}
