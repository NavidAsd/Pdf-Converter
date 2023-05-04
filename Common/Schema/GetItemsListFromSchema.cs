using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Common.Schema
{
    public enum SchemaType
    {
        Faq = 0,
        HowTo = 1,
        Video = 2,
    }
    public class GetItemsListFromSchema
    {

        public GetItemsListFromSchema(string FileFullPath) { fileFullPath = FileFullPath; }
        private string fileFullPath { get; set; }
        private string Json { set; get; }
        private string Result { set; get; }
        private dynamic Array { set; get; }

        private void LoadJson()
        {
            string tempFile = Path.GetTempFileName();
            using (StreamReader sr = new StreamReader(fileFullPath))
            {
                Json = sr.ReadToEnd();
                Items datalist = JsonConvert.DeserializeObject<Items>(Json);
            }
            Array = JsonConvert.DeserializeObject(Json);
        }
        public ResultMessage<List<Faq>> GetFaqList()
        {
            LoadJson();
            List<Faq> faqlist = new List<Faq>();
            bool permission = CheckSchema(SchemaType.Faq);
            if (permission)
            {
                foreach (var item in Array["mainEntity"])
                {
                    try
                    {
                        Faq faq = new Faq();
                        faq.Question = item.name;
                        faq.Answer = item["acceptedAnswer"]["text"];
                        faqlist.Add(faq);
                    }
                    catch { }
                }
                if (faqlist.Count < 1)
                {
                    return new ResultMessage<List<Faq>>
                    {
                        Success = false,
                        Message = "No new faq found!"
                    };
                }
                return new ResultMessage<List<Faq>>
                {
                    Success = true,
                    Enything = faqlist
                };
            }
            return new ResultMessage<List<Faq>>
            {
                Success = false,
                Message = $"The schema must be built from address {GetPath.GetValidSchemaCreator()} and only faq type is acceptable"
            };
        }

        public bool CheckSchema(SchemaType Type)
        {
            LoadJson();
            if (Type == SchemaType.Faq)
            {
                if (Array["@context"] == GetPath.GetValidSchemaCreator() && Array["@type"].ToString().ToLower() == "faqpage")
                    return true;
                return false;
            }
            else if (Type == SchemaType.HowTo)
            {
                var context = Array["@context"].ToString().ToLower();
                var type = Array["@type"].ToString().ToLower();
                if (context == GetPath.GetValidSchemaCreator() && type == "howto")
                    return true;
                if (context == GetPath.GetValidSchemaCreator() + "/" && type == "howto")
                    return true;
                return false;
            }
            else if(Type == SchemaType.Video)
            {
                /*var context = Array["@context"].ToString().ToLower();
                var type = Array["@type"].ToString().ToLower();
                if (type == "VideoObject" || type == "Video" || type == "Videos")
                {
                    if (context == GetPath.GetValidSchemaCreator())
                        return true;
                    if (context == GetPath.GetValidSchemaCreator() + "/")
                        return true;
                }
                return false;*/
                return true;
            }
            return false;
        }
    }
    public class Faq
    {
        public string Question { set; get; }
        public string Answer { set; get; }
    }
    class Items
    {
        public string name { set; get; }
        public string text { set; get; }
    }
}
