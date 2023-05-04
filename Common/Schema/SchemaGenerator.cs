using System.Collections.Generic;
using System.IO;

namespace Common.Schema
{
    public class SchemaGenerator
    {
        public ResultMessage<ResultSchemaGenerator> Generate(List<RequestSchemaGenerator> FAQ, string Path, long Service)
        {
            if (FAQ.Count < 0 && string.IsNullOrWhiteSpace(Path))
            {
                return new ResultMessage<ResultSchemaGenerator>
                {
                    Success = false,
                    Message = "No Item Found For Generat or Path Is Null!"
                };
            }
            string FileName = $"{Formating.StandardFaqSchemaFileName}{Service}.json";
            string basic = "{\r\n  \"@context\": \"https://schema.org\",\r\n  \"@type\": \"FAQPage\",\r\n  \"mainEntity\": [\r\n";
            string Result = basic;
            string Question = "    {\r\n      \"@type\": \"Question\",\r\n";
            string Answer = "\t\"acceptedAnswer\": {\r\n        \"@type\": \"Answer\",";
            string End = "  ]\r\n}";
            int count = 0;
            foreach (var item in FAQ)
            {
                count += 1;
                Result += Question;
                Result += $"      \"name\": \"{item.Questoin}\",\r\n";
                Result += Answer;
                Result += $"\n        \"text\": \"{item.Answer}\"\r\n";
                if (count == FAQ.Count)
                    Result += "      }\r\n    }\r\n";
                else
                    Result += "      }\r\n    },\r\n";
            }
            Result += End;
            AppliedMethodes.CreateDirectory(Path);
            AppliedMethodes.DeleteFile(Path + "/" + FileName);
            try
            {
                using (StreamWriter writer = new StreamWriter(Path + "/" + FileName))
                {
                    writer.WriteLine(Result);
                }
                return new ResultMessage<ResultSchemaGenerator>
                {
                    Success = true,
                    Enything = new ResultSchemaGenerator
                    {
                        FileName = FileName,
                        FilePath = Path
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultSchemaGenerator>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }
    }
    public class ResultSchemaGenerator
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
    }

    public class RequestSchemaGenerator
    {
        public string Questoin { set; get; }
        public string Answer { set; get; }
    }
}
