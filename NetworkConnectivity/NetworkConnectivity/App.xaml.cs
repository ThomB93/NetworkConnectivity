using System;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetworkConnectivity
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var nav = new NavigationPage(new MainPage());
            
            

            if (CrossConnectivity.Current.IsConnected)
            {
                MainPage = new NetworkViewPage();
            }
            else
            {
                MainPage = new NoNetworkPage();
            }

            
        }
        void OnChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected)
            {
                MainPage = new NetworkViewPage();
            }
            else
            {
                MainPage = new NoNetworkPage();
            }
        }

        protected override void OnStart()
        {
            CrossConnectivity.Current.ConnectivityChanged += OnChanged;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
