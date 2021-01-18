using QRcode.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRcode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        MyClass myClass = new MyClass();
        public Home()
        {
            InitializeComponent();
            this.BindingContext = myClass;

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushModalAsync(new View.Read.ReadQR());
            }
            catch (Exception w)
            {
                await DisplayAlert("alerta", "error al abrir:" + w, "OK");
            }
        }


        public class MyClass : PropertyChangedGlobal
        {
            public bool isReadOnlineHome
            {
                get => Preferences.Get(nameof(Configuration.Econfiguration.isReadOnline), false);
                set
                {
                    Preferences.Set(nameof(Configuration.Econfiguration.isReadOnline), value);
                    OnPropertyChanged("isReadOnlineHome");
                }
            }



        }


    }
}