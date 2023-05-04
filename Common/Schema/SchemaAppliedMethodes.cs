using System;
using System.IO;

namespace Common.Schema
{
    public static class SchemaAppliedMethodes
    {
        public static bool CheckSchemaFileExist(long? Service, Common.Schema.SchemaType Type)
        {
            var result = GenerateJsonFileFullPath(Service, Type, Environment.CurrentDirectory.ToString());
            try
            {
                if (File.Exists(result.FilePath + "\\" + result.FileName))
                    return true;
                return false;
            }
            catch { return false; }
        }
        public static ResultSchemaGenerator GenerateJsonFileFullPath(long? Service, Common.Schema.SchemaType Type, string EnvironmentCurrentDirectory)
        {
            string FullPath = EnvironmentCurrentDirectory;
            string FileName = null;
            if (Type == Common.Schema.SchemaType.Faq)
            {
                FileName = $"{Formating.StandardFaqSchemaFileName}{Service}.json";
                FullPath += $"\\{GetPath.GetSchemaFaqJsonPath()}";
            }
            else if (Type == Common.Schema.SchemaType.HowTo)
            {
                FileName = $"{Formating.StandardHowToSchemaFileName}{Service}.json";
                FullPath += $"\\{GetPath.GetSchemaHowToJsonPath()}";
            }
            else if (Type == Common.Schema.SchemaType.Video)
            {
                FileName = $"{Formating.StandardVideoSchemaFileName}{Service}.json";
                FullPath += $"\\{GetPath.GetSchemaVideoJsonPath()}";
            }
            return new ResultSchemaGenerator { FileName = FileName, FilePath = FullPath };
        }

    }
}
