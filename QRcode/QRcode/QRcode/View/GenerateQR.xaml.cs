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

        private void ComTipo_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            try
            {
                string valor = (sender as SfComboBox).SelectedValue.ToString();
                BarcodeSymbolType v = (BarcodeSymbolType)Enum.Parse(typeof(BarcodeSymbolType),valor);
                
                switch (v)
                {                                                                
                    case BarcodeSymbolType.DataMatrix:
                        DataMatrixSettings setting_DataMatrix = new DataMatrixSettings();
                        setting_DataMatrix.XDimension = 6;
                        SyncBarCode.SymbologySettings = setting_DataMatrix;
                        break;
                    case BarcodeSymbolType.QRCode:                        
                        QRBarcodeSettings setting_QRCode = new QRBarcodeSettings();
                        setting_QRCode.XDimension = 5;
                        SyncBarCode.SymbologySettings = setting_QRCode;
                        break;
                    case BarcodeSymbolType.UpcBarcode:                        
                        break;                    
                    default:
                        break;
                }

                SyncBarCode.Symbology = v;                

            }
            catch (Exception w)
            {
                Application.Current.MainPage.DisplayAlert("alerta", "errro al cambiar de item:"+w, "OK");
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
        
        //string _textcode = "www.wikipedia.org";
        //string _textcode = "$52675:14-98";
        string _textcode = "$52675:14-98 esta mierda es la ques e convriete en giganete por que no tienen margen";
        public string textcode { get { return _textcode; } set { _textcode = value; OnPropertyChanged("textcode"); } }
        public ObservableCollection<string> typeCollection { get; set; }
        
        public GenerateQRViewModel()
        {
            typeCollection = new ObservableCollection<string>(Enum.GetNames(typeof(BarcodeSymbolType)));
        }


        



    }

}