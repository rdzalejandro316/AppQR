//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("QRcode.View.Read.ReadQR.xaml", "View/Read/ReadQR.xaml", typeof(global::QRcode.View.Read.ReadQR))]

namespace QRcode.View.Read {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("View\\Read\\ReadQR.xaml")]
    public partial class ReadQR : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ImageButton BtnGallery;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ImageButton BtnLantern;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ImageButton BtnOption;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Grid PanelZxing;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::ZXing.Net.Mobile.Forms.ZXingScannerView zxing;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Grid PanelIsReadOnline;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label Tresult;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(ReadQR));
            BtnGallery = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ImageButton>(this, "BtnGallery");
            BtnLantern = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ImageButton>(this, "BtnLantern");
            BtnOption = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ImageButton>(this, "BtnOption");
            PanelZxing = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "PanelZxing");
            zxing = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::ZXing.Net.Mobile.Forms.ZXingScannerView>(this, "zxing");
            PanelIsReadOnline = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Grid>(this, "PanelIsReadOnline");
            Tresult = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "Tresult");
        }
    }
}