using QRcode.Models;
using Syncfusion.SfBarcode.XForms;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRcode
{
    public partial class App : Application
    {
        static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "QRcode.db3"));
                }
                return database;
            }
        }


        public static MasterDetailPage MasterD { get; set; }        
        public App()
        {
            //version 18.1.0.42
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjQ0NjY5QDMxMzgyZTMxMmUzMG1EQkJLeHZXTEpROFo4Yk9MUEtYZ0IwWkF1eFdpV0RjcFBqbXVYYXF5ekE9");          
            InitializeComponent();
            MainPage = new Menu();
        }
        
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
