using FluToDo.Models.ServiceContracts;
using FluToDo.Models.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FluToDo
{
    public partial class App : Application
    {

        #region constructor

        public App()
        {
            Services.ServiceLocator.Initialize();
            InitializeNetService();

            InitializeComponent();

            Services.ServiceLocator.GetInstance<INavigationService>().PushPage(typeof(ViewModels.MainPageViewModel));
        }

        #endregion constructor

        #region lifecycle

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes

        }

        #endregion lifecycle

        #region methods

        private void InitializeNetService()
        {
            var netservice = Services.ServiceLocator.GetInstance<INetService>();
            netservice.ServerAddress = "http://localhost";
            netservice.Port = 15000;
            netservice.ApiRoute = "api/todo/";
        }

        #endregion methods
    }
}
