using Syncfusion.SfBarcode.XForms;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Schema;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRcode.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateQR : ContentPage
    {
        GenerateQRViewModel ViewModel =  new GenerateQRViewModel();
        public GenerateQR()
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
             


            }
            catch (Exception w)
            {
                DisplayAlert("error","e:"+w,"OK");
            }
        }

    }



    public class GenerateQRViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public GenerateQRViewModel()
        {

        }
        public ICommand ButtonCommand { get; set; }

        string _textcode_bc = "12345";
        public string textcode_bc { get { return _textcode_bc; } set { _textcode_bc = value; OnPropertyChanged("textcode_bc"); } }

        string _textcode_qr = "texto qr";
        public string textcode_qr { get { return _textcode_qr; } set { _textcode_qr = value; OnPropertyChanged("textcode_qr"); } }        
        
        


        






    }
}