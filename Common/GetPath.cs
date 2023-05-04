using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    public enum Language
    {
        English,
        Persian
    }

    public static class GetPath
    {
        private static readonly string PrKey = "nlFRkasdfOI>?DJFL<K$#1sddf14/fruad>ty^&e5s$%#@@lLKFINfPMgrg>tdMEFDd547Dsd:wdfd5428741FNI#$DF5";
        private static string Json { set; get; }
        private static string Result { set; get; }
        private static dynamic Array { set; get; }
        public static readonly string HomeTopImage = "pdfconverter-top-img.webp";
        public static readonly string HomeDownImage = "pdfconverter-down-img.webp";
        private static void LoadJson()
        {
            using (StreamReader r = new StreamReader("Path.json"))
            {
                Json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(Json);
            }
            Array = JsonConvert.DeserializeObject(Json);
        }
        public static string GetApiAddress()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ConverterApi;
            }
            return Result;
        }

        public static string GetInputPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.InputPath;
            }
            return Result;
        }

        public static string GetOutputPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.OutputPath;
            }
            return Result;
        }
        public static string GetEnLanguaage()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.EnLang;
            }
            return Result;
        }

        public static string GetFaLanguage()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.FaLang;
            }
            return Result;
        }
        public static string GetCompanyEmail()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.CompanyEmail;
            }
            return Result;
        }
        public static string GetCompanyEmailPass()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.CmEmailPass;
            }
            return Result;
        }
        public static string GetBackupPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.FullBackupPath;
            }
            return Result;
        }
        public static string GetAdminImagePath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.AdminImage;
            }
            return Result;
        }
        public static string GetDomain()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.Domain;
            }
            return Result;
        }
        public static string GetQrImagesPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.QrImagesPath;
            }
            return Result;
        }
        public static int GetMaxCode()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.MaxCode;
            }
            return System.Convert.ToInt32(Result);
        }
        public static int GetMinCode()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.MinCode;
            }
            return System.Convert.ToInt32(Result);
        }
        public static int GetCommentCount()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.CommentCount;
            }
            return System.Convert.ToInt32(Result);
        }
        public static string GetDefaultAdminImage()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.DefaultAdminImage;
            }
            return Result;
        }
        public static string GetDefaultAdminImageName()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.DefaultAdminImageName;
            }
            return Result;
        }
        public static string GetAdobeClientId()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.AdobeClientId;
            }
            return Result;
        }
        public static string GetReadPdfPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ReadPdfPath;
            }
            return Result;
        }
        public static string GetBlogUrl()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.BlogUrl;
            }
            return Result;
        }
        public static string GetHelpVideoPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.HelpVideoPath;
            }
            return Result;
        }
        public static string GetVideoSize()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.VideoSize;
            }
            return Result;
        }
        public static string GetDomainHttps()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.DomainHttps;
            }
            return Result;
        }
        public static string GetCookieKey()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.CookieKey;
            }
            return Result;
        }
        public static string GetBlinkWinPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.BlinkWinPath;
            }
            return Result;
        }
        public static string GetServiceImages()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ServiceImages;
            }
            return Result;
        }
        public static string GetHomeImages()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.HomeImages;
            }
            return Result;
        }
        public static int GetBlogPostCount()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.BlogPostCount;
            }
            return System.Convert.ToInt32(Result);
        }
        public static int GetDeletLogsDay()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.DeletLogsDay;
            }
            return System.Convert.ToInt32(Result);
        }
        public static int GetFAQCount()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.FAQCount;
            }
            return System.Convert.ToInt32(Result);
        }
        public static string GetContentImatge1()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ContentImatge1;
            }
            return Result;
        }
        public static string GetContentImatge2()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ContentImatge2;
            }
            return Result;
        }
        public static string GetContentImatge3()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ContentImatge3;
            }
            return Result;
        }public static string GetSchemaVideoJsonPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.SchemaVideoJsonPath;
            }
            return Result;
        }
        public static string GetContentImatge4()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ContentImatge4;
            }
            return Result;
        }
        public static string GetContentImatge5()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ContentImatge5;
            }
            return Result;
        }
        public static string GetSlidePic1()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.SlidePic1;
            }
            return Result;
        }
        public static int GetBlogPostCountHomeSlide()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.BlogPostCountHomeSlide;
            }
            return System.Convert.ToInt32(Result);
        }
        public static string GetSlidePic2()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.SlidePic2;
            }
            return Result;
        }
        public static string GetSlidePic3()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.SlidePic3;
            }
            return Result;
        }
        public static int GetBlogPostCountHome()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.BlogPostCountHome;
            }
            return System.Convert.ToInt32(Result);
        }
        public static string GetValidSchemaCreator()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ValidSchemaCreator;
            }
            return Result;
        }
        public static string GetSchemaFaqJsonPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.SchemaFaqJsonPath;
            }
            return Result;
        }public static string GetSchemaHowToJsonPath()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.SchemaHowToJsonPath;
            }
            return Result;
        }
        public static string GetValidSchemaCreatortools()
        {
            LoadJson();
            foreach (var item in Array)
            {
                Result = item.ValidSchemaCreatortools;
            }
            return Result;
        }
        public static string GetPrivateKey()
        {
            return PrKey;
        }

    }

    class Item
    {
        private string ConverterApi { set; get; }
        private string InputPath { set; get; }
        private string OutputPath { set; get; }
        private string EnLang { set; get; }
        private string FaLang { set; get; }
        private string CompanyEmail { set; get; }
        private string CmEmailPass { set; get; }
        private string FullBackupPath { set; get; }
        private string AdminImage { set; get; }
        private string Domain { set; get; }
        private string QrImagesPath { set; get; }
        private int MaxCode { set; get; }
        private int MinCode { set; get; }
        private int CommentCount { set; get; }
        private string DefaultAdminImage { set; get; }
        private string DefaultAdminImageName { set; get; }
        private string AdobeClientId { set; get; }
        private string ReadPdfPath { set; get; }
        private string BlogUrl { set; get; }
        private string HelpVideoPath { set; get; }
        private string VideoSize { set; get; }
        private string DomainHttps { set; get; }
        private string CookieKey { set; get; }
        private string BlinkWinPath { set; get; }
        private string BlogPostCount { set; get; }
        private string DeletLogsDay { set; get; }
        private string ServiceImages { set; get; }
        private string HomeImages { set; get; }
        private string FAQCount { set; get; }
        private string ContentImatge1 { set; get; }
        private string ContentImatge2 { set; get; }
        private string ContentImatge3 { set; get; }
        private string ContentImatge4 { set; get; }
        private string ContentImatge5 { set; get; }
        private string SlidePic1 { set; get; }
        private string SlidePic2 { set; get; }
        private string SlidePic3 { set; get; }
        private int BlogPostCountHome { set; get; }
        public string ValidSchemaCreator { set; get; }
        public string SchemaFaqJsonPath { set; get; }
        public string SchemaHowToJsonPath { set; get; }
        public string SchemaVideoJsonPath { set; get; }
        public string ValidSchemaCreatortools { set; get; }
        public int BlogPostCountHomeSlide { set; get; }
    }
}
