using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyObjects.Helpers
{
    public enum Urls
    {
        SauceDemo,
        GuruAlert,
        GuruPopup
    }

    public static class Url
    {
        public static string SauceDemoUrl = MyAppSettings.GetConfig(Section.Urls, $"{Urls.SauceDemo}");
        public static string Guru99AlertUrl = MyAppSettings.GetConfig(Section.Urls, $"{Urls.GuruAlert}");
        public static string Guru99PopupUrl = MyAppSettings.GetConfig(Section.Urls, $"{Urls.GuruPopup}");

    }
}
