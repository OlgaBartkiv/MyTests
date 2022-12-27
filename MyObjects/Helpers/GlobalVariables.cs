using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Helpers
{
    public static class GlobalVariables
    {
        public static string Saucedemo => SaucedemoLazy.Value;

        public static string GuruAlert => GuruAlertLazy.Value;

        public static string GuruPopup => GuruPopupLazy.Value;

        public static string Google => GoogleLazy.Value;



        private static readonly Lazy<string> SaucedemoLazy =
            new Lazy<string>(() => ConfigurationManager.AppSettings.Get("Saucedemo"));

        private static readonly Lazy<string> GuruAlertLazy =
            new Lazy<string>(() => ConfigurationManager.AppSettings.Get("GuruAlert"));

        private static readonly Lazy<string> GuruPopupLazy =
            new Lazy<string>(() => ConfigurationManager.AppSettings.Get("GuruPopup"));

        private static readonly Lazy<string> GoogleLazy =
            new Lazy<string>(() => ConfigurationManager.AppSettings.Get("Google"));


    }
}
