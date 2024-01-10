using Common.Schema;
using iTextSharp.text.pdf.codec.wmf;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public enum ApiServices
    {
        PdfToPpt,
        PdfToDoc,
        PptToPdf,
        XlsxToPdf,
        DocToPdf,
        UnlockPdf,
        ExtractImages,
        QrMaker
    }
    public static class AppliedMethodes
    {
        private static readonly string UrlRegex = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
        public static void CreateZipFile(string OutputPath, string[] files)
        {
            // Create and open a new ZIP file
            var zip = ZipFile.Open(OutputPath, ZipArchiveMode.Create);
            foreach (var file in files)
            {
                // Add the entry for each file
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            // Dispose of the object when we are done
            zip.Dispose();
        }
        public static string GetSourcePage(string Url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage response = client.GetAsync(Url).Result)
                    {
                        using (HttpContent content = response.Content)
                        {
                            return content.ReadAsStringAsync().Result;
                        }
                    }
                }
            }
            catch { return null; }

        }

        public static void DeleteFile(string FullFilePath)
        {
            try
            {
                File.Delete(FullFilePath);
            }
            catch { }
        }
        public static void DeleteFiles(string[] FullFilePath)
        {
            for (int i = 0; i < FullFilePath.Length; i++)
            {
                try
                {
                    File.Delete(FullFilePath[i]);
                }
                catch { }
            }
        }

        public static void DeleteAllFiles(string DirectoryPath)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(DirectoryPath);
                FileInfo[] files = di.GetFiles();
                foreach (FileInfo file in files)
                {
                    file.Delete();
                }
            }
            catch { }
        }
        public static async Task<InternalServiceResponse> RequestSender(string Url, bool MaxTimeout)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Url);
                if (!MaxTimeout)
                    client.Timeout = TimeSpan.FromMinutes(4);
                else
                    client.Timeout = TimeSpan.FromMinutes(8);

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

                // List data response.
                HttpResponseMessage response = await client.GetAsync("");  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                client.Dispose();
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body.
                    var Content = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    return new InternalServiceResponse { ResponseContent = Content, StatusCode = (int)response.StatusCode };
                }
                else
                    return new InternalServiceResponse { StatusCode = (int)response.StatusCode };
            }
            catch
            {
                return new InternalServiceResponse { StatusCode = 500 };
            }
        }
        public static async Task<Common.someEntities.ShortUrl> LinkShorter(string Url)
        {
            try
            {
                var client = new RestClient("https://api.apilayer.com/short_url/hash");
                var request = new RestRequest();
                request.Method = Method.Post;
                request.Timeout = -1;
                request.AddHeader("apikey", "7mhH4cZ6B4uU7Sq7xDAJAsLwFR1wVxDM"); //key
                request.AddParameter("text/plain", Url, ParameterType.RequestBody);

                RestResponse response = await client.ExecuteAsync(request);

                dynamic result = JsonConvert.DeserializeObject(response.Content);
                someEntities.ShortUrl LinkGenerated = new someEntities.ShortUrl();
                LinkGenerated.hash = result.hash; // for delete generatedlink on linkshorter server
                LinkGenerated.short_url = result.short_url;
                return LinkGenerated;
            }
            catch { return null; }

        }
        public static FilesFormat ReturnFormat(string FileName)
        {
            string Format = Path.GetExtension(FileName).ToLower();
            if (Format.Equals(".pdf"))
                return FilesFormat.pdf;
            else if (Format.Equals(".jpg") || Format.Equals(".jpeg"))
                return FilesFormat.jpg;
            else if (Format.Equals(".bmp"))
                return FilesFormat.bmp;
            else if (Format.Equals(".gif"))
                return FilesFormat.gif;
            else if (Format.Equals(".png"))
                return FilesFormat.png;
            else if (Format.Equals(".tiff"))
                return FilesFormat.tiff;
            else if (Format.Equals(".ppt") || Format.Equals(".pptx"))
                return FilesFormat.ppt;
            else if (Format.Equals(".xlsx") || Format.Equals("csv"))
                return FilesFormat.xlsx;
            else if (Format.Equals(".doc") || Format.Equals(".docx"))
                return FilesFormat.docx;
            else if (Format.Equals(".rtf"))
                return FilesFormat.rtf;
            else if (Format.Equals(".zip"))
                return FilesFormat.zip;
            else if (Format.Equals(".rar"))
                return FilesFormat.rar;
            else
                return FilesFormat.none;
        }

        public static string UrlMaker(string ApiAddress, ApiServices Service, string InputFilePath, string InputFileName, string OutputPath, string UserIp)
        {
            return FixRequestFormat($"{ApiAddress}/{ReturnApiService(Service)}?InputFilePath={InputFilePath}&InputFileName={InputFileName}&OutputPath={OutputPath}&UserIp={UserIp}");
        }
        public static string UrlMakerForUnlock(string ApiAddress, ApiServices Service, string PWDFilePath, string PWDFileName, string InputFilePath, string InputFileName, string OutputPath, string UserIp)
        {
            return FixRequestFormat($"{ApiAddress}/{ReturnApiService(Service)}?PWDFilePath={PWDFilePath}&PWDFileName={PWDFileName}&InputFilePath={InputFilePath}&InputFileName={InputFileName}&OutputPath={OutputPath}&UserIp={UserIp}");
        }
        public static string UrlMakerForPdfToDoc(string ApiAddress, ApiServices Service, string InputFilePath, string InputFileName, string OutputPath, string UserIp, int FormatType)
        {
            return FixRequestFormat($"{ApiAddress}/{ReturnApiService(Service)}?InputFilePath={InputFilePath}&InputFileName={InputFileName}&OutputPath={OutputPath}&UserIp={UserIp}&FormatType={FormatType}");
        }
        public static string UrlMakerForQrMaker(string ApiAddress, string DestUrl, string OutputPath, string UserIp)
        {
            return FixRequestFormat($"{ApiAddress}/{ApiServices.QrMaker}?DestUrl={DestUrl}&OutputPath={OutputPath}&UserIp={UserIp}");
        }
        public static string FindServiceName(List<Domain.Entities.Details.FeaturesDetails> Services, int Service)
        {
            string output = "";
            foreach (var item in Services)
            {
                if (item.Service == Service)
                    output = item.Name;
            }
            return output;
        }
        public static void CopyFile(string FilePath, string DestPath)
        {
            try
            {
                File.Copy(FilePath, DestPath, true);
            }
            catch { }
        }

        public static bool UrlValidation(string Url)
        {
            return (bool)Uri.IsWellFormedUriString(Url, UriKind.RelativeOrAbsolute);
        }
        public static string FixRequestFormat(string Url)
        {
            return Url.Replace("\\", "-");
        }
        private static string ReturnApiService(ApiServices Service)
        {
            switch (Service)
            {
                case ApiServices.PdfToPpt:
                    return "PdfToPpt";
                case ApiServices.PdfToDoc:
                    return "PdfToDoc";
                case ApiServices.PptToPdf:
                    return "PptToPdf";
                case ApiServices.XlsxToPdf:
                    return "XlsxToPdf";
                case ApiServices.DocToPdf:
                    return "DocToPdf";
                case ApiServices.UnlockPdf:
                    return "UnllockPdf";
                case ApiServices.ExtractImages:
                    return "ExtractImages";
                case ApiServices.QrMaker:
                    return "QrMaker";
                default:
                    return null;
            }
        }

        public static void CreateDirectory(string Path)
        {
            try
            {
                if (!Directory.Exists(Path))
                    Directory.CreateDirectory(Path);
            }
            catch { }
        }

        public async static Task<ResultMessage> CheckPdfEncrypted(string FileFullPath)
        {
            try
            {
                using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(FileFullPath))
                {
                    if (reader.IsEncrypted())
                    {
                        return new ResultMessage { Success = true, Message = "Your file is encrypted, we can not access it. Please upload the correct file or use the unlock pdf service" };
                    }
                    return new ResultMessage { Success = false };
                }
            }
            catch
            {
                return new ResultMessage { Success = true, Message = "Your file is encrypted, we can not access it. Please upload the correct file or use the unlock pdf service" };
            }
        }

        public static int ReturnPdfPagesCount(string FullPath)
        {
            int[] Allpages;
            using (iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(FullPath))
            {
                Allpages = new int[reader.NumberOfPages];
                for (int i = 0; i < reader.NumberOfPages; i++)
                {
                    Allpages[i] = i + 1;
                }
            }
            return Allpages.Length;
        }

    }
}
