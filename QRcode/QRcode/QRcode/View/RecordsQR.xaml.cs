using QRcode.Models;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRcode.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordsQR : ContentPage
    {
        RecordQrViewModel vm = new RecordQrViewModel();
        public RecordsQR()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var product = btn.BindingContext as Record;
                vm.RecordInfo.Remove(product);//elimina a nivel visual
                App.Database.DeleteRecordAsync(product);//elimina a nivel BD


                #region creacion de popup 

                SfPopupLayout popupLayout = new SfPopupLayout();
                popupLayout.PopupView.HeightRequest = 50;
                popupLayout.PopupView.WidthRequest = Application.Current.MainPage.Width;

                popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    grid.BackgroundColor = Color.Black;
                    var label1 = new Label()
                    {
                        Text = "Texto Eliminado",
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    Color colorMain = (Color)App.Current.Resources["ColorMain"];

                    var button = new Button()
                    {
                        Text = "Cerrar",
                        TextColor = colorMain,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.Black
                    };

                    button.Clicked += (s, a) => popupLayout.IsOpen = false;

                    grid.Children.Add(label1, 0, 0);
                    grid.Children.Add(button, 1, 0);
                    return grid;

                });

                popupLayout.PopupView.ShowHeader = false;
                popupLayout.PopupView.ShowFooter = false;
                popupLayout.HeightRequest = 50;
                popupLayout.WidthRequest = 50;
                popupLayout.ShowRelativeToView(ListViewHistory, RelativePosition.AlignBottom, 0, -20);

                #endregion

            }
            catch (Exception w)
            {
                Application.Current.MainPage.DisplayAlert("alerta", "error al eliminar:" + w, "OK");
            }
        }

        private async void BtnCopy_Clicked(object sender, EventArgs e)
        {
            try
            {

                var parameter = (sender as Button).CommandParameter;
                await Clipboard.SetTextAsync(parameter.ToString());

                #region creacion de popup 

                SfPopupLayout popupLayout = new SfPopupLayout();
                popupLayout.PopupView.HeightRequest = 50;
                popupLayout.PopupView.WidthRequest = Application.Current.MainPage.Width;

                popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid();
                    grid.BackgroundColor = Color.Black;
                    var label1 = new Label()
                    {
                        Text = "Texto Copiado",
                        TextColor = Color.White,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };

                    Color colorMain = (Color)App.Current.Resources["ColorMain"];

                    var button = new Button()
                    {
                        Text = "Cerrar",
                        TextColor = colorMain,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.Black
                    };

                    button.Clicked += (s, a) => popupLayout.IsOpen = false;

                    grid.Children.Add(label1, 0, 0);
                    grid.Children.Add(button, 1, 0);
                    return grid;

                });

                popupLayout.PopupView.ShowHeader = false;
                popupLayout.PopupView.ShowFooter = false;
                popupLayout.HeightRequest = 50;
                popupLayout.WidthRequest = 50;
                popupLayout.ShowRelativeToView(ListViewHistory, RelativePosition.AlignBottom, 0, -20);

                #endregion


            }
            catch (Exception w)
            {
                await Application.Current.MainPage.DisplayAlert("alerta", "error al copiar:" + w, "OK");
            }
        }

        private async void BtnShare_Clicked(object sender, EventArgs e)
        {
            try
            {
                var btn = sender as Button;
                var product = btn.BindingContext as Record;
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = product.Code,
                    Title = "Share Text"
                });
            }
            catch (Exception)
            {

                throw;
            }
        }


    }


    class RecordQrViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Record> _RecordInfo;
        public ObservableCollection<Record> RecordInfo
        {
            get { return _RecordInfo; }
            set { this._RecordInfo = value; }
        }

        public RecordQrViewModel()
        {
            RecordInfo = new ObservableCollection<Record>(App.Database.GetRecordAsync().Result);
        }



    }

}