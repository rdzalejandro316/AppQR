//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("QRcode.View.GenerateQR.xaml", "View/GenerateQR.xaml", typeof(global::QRcode.View.GenerateQR))]

namespace QRcode.View {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("View\\GenerateQR.xaml")]
    public partial class GenerateQR : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ScrollView PanelMain;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Grid GridBarCode;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Syncfusion.SfBarcode.XForms.SfBarcode SyncBarCode;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Syncfusion.XForms.ComboBox.SfComboBox ComTipo;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(GenerateQR));
            PanelMain = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ScrollView>(this, "PanelMain");
            GridBarCode = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "GridBarCode");
            SyncBarCode = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.SfBarcode.XForms.SfBarcode>(this, "SyncBarCode");
            ComTipo = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Syncfusion.XForms.ComboBox.SfComboBox>(this, "ComTipo");
        }
    }
}
