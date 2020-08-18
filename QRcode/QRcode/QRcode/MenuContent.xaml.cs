using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QRcode
{    
    [DesignTimeVisible(false)]
    public partial class MenuContent : ContentPage
    {
        public MenuContent()
        {
            InitializeComponent();
        }

        private async void BtnGenereate_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new View.GenerateQR());
            }
            catch (Exception w)
            {
                await DisplayAlert("alert", "error la generacion de QR:" + w, "OK");
            }
        }

        private async void BtnScanner_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new View.ReadQR());
            }
            catch (Exception w)
            {
                await DisplayAlert("alert", "error Leer Qr:" + w, "OK");
            }
        }

        private async void BtnRecord_Clicked(object sender, EventArgs e)
        {
            try
            {
                App.MasterD.IsPresented = false;
                await App.MasterD.Detail.Navigation.PushAsync(new View.RecordsQR());
            }
            catch (Exception w)
            {
                await DisplayAlert("alert", "error Leer Qr:" + w, "OK");
            }
        }

        private void BtnConfig_Clicked(object sender, EventArgs e)
        {

        }


    }    

}
