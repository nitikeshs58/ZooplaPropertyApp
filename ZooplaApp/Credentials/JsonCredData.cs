using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZooplaApp.Credencials
{
    // Getter and Setter methods
    public class JsonCredData
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string WebsiteUrl { get; set; }
        public string PropertySearchName { get; set; }
        public string WebsiteTitle { get; set; }
        public string PropertyLocationTitle { get; set; }
        public string EmailForReport { get; set; }
        public string EmailForReportPassword { get; set; }
        public string InvalidEmail { get; set; }
        public string InvalidPassword { get; set; }
        public string NullValue { get; set; }
    }

    // Reading Json data from path location
    public static class JsonData
    {
        public static WebClient client = new WebClient();
        public static string text = client.DownloadString(@"C:\Users\Admin\source\repos\ZooplaApp\ZooplaApp\Credentials\Cred.json");
        public static JsonCredData data = JsonConvert.DeserializeObject<JsonCredData>(text);
    }
}
