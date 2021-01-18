using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms.Xaml;
using QRcode.Models;
using System.Collections.ObjectModel;
using ZXing.Client.Result;
using Xamarin.Essentials;
using Syncfusion.XForms.PopupLayout;
using QRcode.Helper;

namespace QRcode.View.Read
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadQR : ContentPage
    {
        ReadQRViewModel vm = new ReadQRViewModel();
        bool isReadOnline = (bool)Preferences.Get(nameof(Configuration.Econfiguration.isReadOnline), false);
        public ReadQR()
        {
            InitializeComponent();            
            this.BindingContext = vm;
            if (!isReadOnline)
            {
                PanelIsReadOnline.IsVisible = false;
                Grid.SetRowSpan(PanelZxing,2);                    
            }
        }
        private async void ZXingScannerView_OnOnScanResult(Result result)
        {
            try         
            {
                
                if (isReadOnline)
                {
                    vm.result_read = string.IsNullOrEmpty(result.Text) ? "No valid code has been scanned" : result.Text;
                }
                else
                {
                    vm.result_read = "no esta online";
                }
                
            }
            catch (Exception w)
            {
                await DisplayAlert("Error sacnn", "error:" + w, "OK");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            zxing.IsTorchOn = !zxing.IsTorchOn;
        }

        private void BtnGallery_Clicked(object sender, EventArgs e)
        {

        }
    }



}