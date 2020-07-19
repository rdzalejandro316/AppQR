using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRcode
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItems : ContentPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MenuItems()
        {
            InitializeComponent();
            loadItems();
        }

        public void loadItems()
        {

            menuList = new List<MasterPageItem>();
            menuList.Add(new MasterPageItem() { Title = "Inicio", Icon = "home.png", TargetType = typeof(MenuContent) });
            
            menuList.Add(new MasterPageItem() { Title = "Generar QR", Icon = "qrcodegray.png", TargetType = typeof(View.ReadQR) });

            menuList.Add(new MasterPageItem() { Title = "Leer QR", Icon = "qrreadgray.png", TargetType = typeof(View.ReadQR) });

            menuList.Add(new MasterPageItem() { Title = "Historial", Icon = "historialgray.png", TargetType = typeof(View.ReadQR) });

            menuList.Add(new MasterPageItem() { Title = "Configuracion", Icon = "configgray.png", TargetType = typeof(View.ReadQR) });


            navigationDrawerList.ItemsSource = menuList;
        }

        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (MasterPageItem)e.SelectedItem;
                Type page = item.TargetType;

                if (item.Title == "Inicio")
                {
                    Application.Current.MainPage = new NavigationPage(new Menu());
                }
                else
                {
                    await App.MasterD.Detail.Navigation.PushAsync((Page)Activator.CreateInstance(page));
                }
                App.MasterD.IsPresented = false;
            }
            catch (Exception w)
            {
                await DisplayAlert("error en inicio", "errro:" + w, "OK");
            }
        }

        public class MasterPageItem
        {
            public string Title { get; set; }
            public string Icon { get; set; }
            public Type TargetType { get; set; }
        }

    }
}