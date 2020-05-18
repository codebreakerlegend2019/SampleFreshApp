using FreshMvvm;
using SampleFreshApp.Helpers;
using SampleFreshApp.Helpers.JdsClientTool;
using SampleFreshApp.PageModels.AuthRelatedPageModel;
using SampleFreshApp.ViewModels.ContactRelatedPageModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleFreshApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            JdsClient.BaseAddress = "http://developers.gpseyetrackerph.com/";
            DependencyInjectionTool.Register();
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LoginPageModel>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
