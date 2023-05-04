using Common;
using System;
using Xunit;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using Application.Interface.FacadPattern;
using Application.Services.Blog.ReturnBlogPostsData;
using Domain.Entities.Blog;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Common.Schema;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Converters.Test
{
    public class Other : IDisposable
    {
        private bool Result;
        private string OutputPath = @"E:\C#\Web\Test\ConvertFromPdf\Output";
        private string InputPath = @"E:\C#\Web\Test\ConvertFromPdf\Input";
        private string InputPdfPathEnglish = @"E:\C#\Web\Test\ConvertFromPdf\Input\Test-English.pdf";
        private string InputPathForApi = @"E:\C\Input";
        private string OutputPathForApi = @"E:\C\Output";
        private string InputEnglishFile = "Test-English.pdf";

        //[Fact]
        //protected bool GetJsonParams()
        //{
        //    int we = 1;
        //    List<Domain.Entities.OtherContext.FrequentlyQuestions> gh = new List<Domain.Entities.OtherContext.FrequentlyQuestions>();

        //    while (true)
        //    {
        //        Domain.Entities.OtherContext.FrequentlyQuestions qq = new Domain.Entities.OtherContext.FrequentlyQuestions();

        //        qq.Answer = "werwe-" + we.ToString();
        //        qq.Question = "trtrtr-" + we.ToString();
        //        gh.Add(qq);
        //        we += 1;
        //        if (we == 3)
        //            break;
        //    }
        //    foreach (var item in gh)
        //    {
        //        if (item.Answer == "werwe-1")
        //            gh.Remove(item);
        //    }


        //    GetItemsListFromSchema getSchema = new Common.Schema.GetItemsListFromSchema("D:\\C#\\Web\\Core\\PdfConverter\\EndPoint\\wwwroot\\Services\\Json\\SchemaFile\\file.json");
        //    var gg = getSchema.GetFaqList();
        //    return true;
        //}

        [Fact]
        protected bool ExtractPdfImages()
        {
            try
            {
                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker("http://127.0.0.1:5000", ApiServices.ExtractImages, InputPathForApi, InputEnglishFile, OutputPathForApi, GetMyIp()), false);
                var Response = JsonConvert.DeserializeObject<ResultMessage<UnlockPdfServiceResponseEntitires>>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        Result = true;
                    else
                        Result = false;
                else
                    Result = false;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }
        private string GetMyIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }
        [Fact]
        public string BlogPosts()
        {
            var Response = AppliedMethodes.RequestSender(GetPath.GetBlogUrl(), false);
            if (Response.Result.StatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                dynamic JsonResult = JsonConvert.DeserializeObject(Response.Result.ResponseContent);
                Domain.Entities.Blog.BlogEntities Blog = new BlogEntities();
                List<BlogEntities> LBlog = new List<BlogEntities>();
                for (int i = 0; i < JsonResult.Count; i++)
                {
                    Blog.Id = JsonResult[i].id;
                    Blog.InsertDate = JsonResult[i].date;
                    Blog.Status = JsonResult[i].status;
                    Blog.Link = JsonResult[i].link;
                    Blog.Type = JsonResult[i].type;
                    Blog.Title = JsonResult[i].title.rendered;
                    //Blog.TitleImage = JsonResult[i].better_featured_image;
                    Blog.Content = JsonResult[i].content.rendered;
                    LBlog.Add(Blog);
                }
            }
            Console.WriteLine();
            return "";
        }
        [Fact]
        public string LinkShorter()
        {
            var aa = AppliedMethodes.LinkShorter(@"https://localhost:44304/Downloader/DownloadLink?OutFileName=PdfToConverter.com-Pdf-Compressed_5-12-2022_10-48-44_AM-409.pdf&Id=13&LogService=OptimizersLog");
            return aa.ToString();
        }
        public void Dispose()
        {

        }
    }
}
