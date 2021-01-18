using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace QRcode.Helper
{
    static class Configuration
    {
        public enum Econfiguration
        {
            isSound,
            isSaveData,
            isReadOnline,
        }
        public static void Active()
        {
            if (!Preferences.ContainsKey(nameof(Econfiguration.isSound)))
                Preferences.Set(nameof(Econfiguration.isSound), false);
            
            if (!Preferences.ContainsKey(nameof(Econfiguration.isSaveData)))
                Preferences.Set(nameof(Econfiguration.isSaveData), false);

            if (!Preferences.ContainsKey(nameof(Econfiguration.isReadOnline)))
                Preferences.Set(nameof(Econfiguration.isReadOnline), false);

        }




    }
}
