// ReSharper disable once CheckNamespace
namespace ExtraLife2017.Web
{
    public static class WebConfiguration
    {
        public static string AppName = "ExtraLife2017.Web";
    }

    public class AppSettings
    {
        public string Domain { get; set; }
        public string PrizeServiceUri { get; set; }
        public string PrizeServiceApiKey { get; set; }
    }
}