using Newtonsoft.Json;
using System.IO;

namespace Common.Schema
{
    public static class SchemaReader
    {
        private static string Json { set; get; }
        //private static string Result { set; get; }
        //private static dynamic Array { set; get; }

        private static void LoadJson(string fileFullPath)
        {
            string tempFile = Path.GetTempFileName();
            using (StreamReader sr = new StreamReader(fileFullPath))
            {
                Json = sr.ReadToEnd();
            }
        }
        public static string ReadToEnd(string fileFullPath, bool useDefaultPath, Schema.SchemaType Type)
        {
            try
            {
                if (useDefaultPath)
                {
                    if (Type == Schema.SchemaType.Faq)
                        LoadJson(GetPath.GetSchemaFaqJsonPath() + "\\" + fileFullPath);
                    else if(Type == Schema.SchemaType.HowTo)
                        LoadJson(GetPath.GetSchemaHowToJsonPath() + "\\" + fileFullPath);
                    else if(Type == Schema.SchemaType.Video)
                        LoadJson(GetPath.GetSchemaVideoJsonPath() + "\\" + fileFullPath);
                }
                else
                    LoadJson(fileFullPath);
                return Formating.FixStringFormat(Json);
            }
            catch { return null; }
        }
    }
}
