using QRcode.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
                

            }
            catch (Exception w)
            {
                Application.Current.MainPage.DisplayAlert("alerta", "error al eliminar:" + w, "OK");
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

        private List<Record> _RecordInfo;

        public List<Record> RecordInfo
        {
            get { return _RecordInfo; }
            set { this._RecordInfo = value; }
        }

        public RecordQrViewModel()
        {
            RecordInfo = new List<Record>();
            RecordInfo = App.Database.GetRecordAsync().Result;
        }


    }



}