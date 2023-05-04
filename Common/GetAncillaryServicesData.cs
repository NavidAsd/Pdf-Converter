using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Common
{
   public class GetAncillaryServicesData
    {
        private static string Json { set; get; }
        private static string Result { set; get; }
        private static dynamic Array { set; get; }
        private static void LoadJson()
        {
            using (StreamReader r = new StreamReader("AncillaryServicesData.json"))
            {
                Json = r.ReadToEnd();
                List<ACItem> items = JsonConvert.DeserializeObject<List<ACItem>>(Json);
            }
            Array = JsonConvert.DeserializeObject(Json);
        }
        public static string GetDropBoxApiKey()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ApiKey;
            }
            return Result;
        }
        public static string GetDropBoxSecretKey()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ApiSecret;
            }
            return Result;
        }
    }
    class ACItem
    {
        private string ApiKey { set; get; }
        private string ApiSecret { set; get; }
    }

}
