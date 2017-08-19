using FluToDo.Models.ServiceContracts;
using FluToDo.Models.ServicesContracts;
using FluToDo.ViewModels.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluToDo.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        #region Fields

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        #endregion Fields

        #region Properties      

        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;

        #endregion Properties

        #region Services
        
        protected INetService NetService;
        protected INavigationService NavigationService;

        #endregion Services

        #region Constructor

        public BaseViewModel(INavigationService navigationService,INetService netService)
        {
            NavigationService = navigationService;
            NetService = netService;
        }

        #endregion Constructor

        #region Lifecycle

        virtual public void OnAppearing()
        { }

        virtual public void OnDisappearing()
        { }

        #endregion Lifecycle

        #region Methods

        virtual public bool OnBackButtonPressed()
        {
            return true;
        }

        #endregion Methods

    }
}
