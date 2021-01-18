using QRcode.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;

namespace QRcode.View.Read
{
    class ReadQRViewModel : PropertyChangedGlobal
    {
        MobileBarcodeScanningOptions options = new MobileBarcodeScanningOptions();
        public ReadQRViewModel()
        {
            options.PossibleFormats = new List<BarcodeFormat>
            {
                BarcodeFormat.QR_CODE,
                BarcodeFormat.CODE_128,
                BarcodeFormat.EAN_13,
                BarcodeFormat.CODABAR
            };

        }
        
        private string _result_read;
        public string result_read
        {
            get { return _result_read; }
            set { _result_read = value; OnPropertyChanged("result_read"); }
        }






    }


}
