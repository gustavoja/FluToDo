using FluToDo.Models.ServiceContracts;
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

            MainPage = new FluToDo.MainPage();
        }

        #endregion constructor

        #region lifecycle

        protected async override void OnStart()
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
