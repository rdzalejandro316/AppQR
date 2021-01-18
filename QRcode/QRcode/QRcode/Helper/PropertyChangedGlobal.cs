using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QRcode.Helper
{
    public class PropertyChangedGlobal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
