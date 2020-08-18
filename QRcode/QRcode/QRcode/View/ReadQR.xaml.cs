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

namespace QRcode.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadQR : ContentPage
    {
        MainPageViewModel vm = new MainPageViewModel();
        public ReadQR()
        {
            InitializeComponent();            
            this.BindingContext = vm;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {                
                var parameter = (sender as Button).CommandParameter;
                await Clipboard.SetTextAsync(parameter.ToString());
            }
            catch (Exception w)
            {
                await Application.Current.MainPage.DisplayAlert("alerta", "errro copiar:" + w, "OK");
            }            
        }
    }


    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public ObservableCollection<ListCodeBar> ListCode { get; set; }

        private ListCodeBar _SelectedCodeBar;
        public ListCodeBar SelectedCodeBar
        {
            get { return _SelectedCodeBar; }
            set { _SelectedCodeBar = value; OnPropertyChanged("SelectedCodeBar");}
        }

        public ICommand ButtonCommand { get; set; }        

        public MainPageViewModel()
        {
            ButtonCommand = new Command(OnButtomCommand);
            ListCode = new ObservableCollection<ListCodeBar>();
            ListCode.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnButtomCommand()
        {
            var options = new MobileBarcodeScanningOptions();
            options.PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_128,
                BarcodeFormat.EAN_13,
                BarcodeFormat.CODABAR
            };

            //var overlay = new ZXingDefaultOverlay
            //{
            //    ShowFlashButton = false,
            //    //TopText = "I'm at the top",
            //    //BottomText = "I'm at the bottom",                
            //};
            //overlay.BindingContext = overlay;


            //var page = new ZXingScannerPage(options, overlay) { Title = "Scanner"};
            var page = new ZXingScannerPage(options) { Title = "Scanner" };
            var closeItem = new ToolbarItem { Text = "Close" };

            closeItem.Clicked += (object sender, EventArgs e) =>
            {
                page.IsScanning = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                });
            };


            page.ToolbarItems.Add(closeItem);
            page.OnScanResult += (result) =>
            {
                page.IsScanning = false;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                    if (string.IsNullOrEmpty(result.Text))
                    {
                        Result = "No valid code has been scanned";
                    }
                    else
                    {
                        Result = $"Resultado: {result.Text}";
                        ListCode.Add(new ListCodeBar()
                        {
                            code = result.Text,
                            date = DateTime.Now
                        });
                        
                        //save database local
                        App.Database.SavePersonAsync(new Record
                        {
                            Code = result.Text,
                            Date = DateTime.Now
                        });
                    }
                });
            };

            Application.Current.MainPage.Navigation.PushModalAsync(
                new NavigationPage(page)
                { BarTextColor = Color.White, BarBackgroundColor = Color.FromHex("#F44336") },
                    true
                );
        }



    }
}