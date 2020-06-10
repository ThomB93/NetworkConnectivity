using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConnectivityChangedEventArgs = Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs;

namespace NetworkConnectivity
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NetworkViewPage : ContentPage
    {
        public NetworkViewPage()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            connectionDetailsLbl.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();
            CrossConnectivity.Current.ConnectivityChanged += OnChanged;
            CrossConnectivity.Current.ConnectivityTypeChanged += OnConnectivityTypeChanged;
        }

        private void OnConnectivityTypeChanged(object sender, ConnectivityTypeChangedEventArgs e)
        {
            if (e.IsConnected.ToString().Equals("False"))
            {
                if (CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi))
                {
                    // WE LOST AN CONNECTION BUT WIFI IS STILL ON 
                    connectionDetailsLbl.Text = "WE LOST AN CONNECTION BUT WIFI IS STILL ON";
                }
            }
            else
            {
                if (CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi))
                {
                    // WIFI WAS TURN ON AND WE HAVE A CONNECTION 
                    connectionDetailsLbl.Text = "WIFI WAS TURN ON AND WE HAVE A CONNECTION";
                }
                else
                {
                    // WE HAVE A CONNECTION BUT NOT WIFI
                    connectionDetailsLbl.Text = "WE HAVE A CONNECTION BUT NOT WIFI";
                }
            }
        }

        protected override void OnDisappearing()
        {
            CrossConnectivity.Current.ConnectivityChanged -= OnChanged;
            CrossConnectivity.Current.ConnectivityTypeChanged -= OnConnectivityTypeChanged;
        }

        private void OnChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.IsConnected.ToString().Equals("False"))
            {
                if (CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi))
                {
                    // WE LOST AN CONNECTION BUT WIFI IS STILL ON 
                    connectionDetailsLbl.Text = "WE LOST AN CONNECTION BUT WIFI IS STILL ON";
                }
            }
            else
            {
                if (CrossConnectivity.Current.ConnectionTypes.Contains(ConnectionType.WiFi))
                {
                    // WIFI WAS TURN ON AND WE HAVE A CONNECTION 
                    connectionDetailsLbl.Text = "WIFI WAS TURN ON AND WE HAVE A CONNECTION";
                }
                else
                {
                    // WE HAVE A CONNECTION BUT NOT WIFI
                    connectionDetailsLbl.Text = "WE HAVE A CONNECTION BUT NOT WIFI";
                }
            }
        }
    }
}