using Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Syncfusion.HtmlConverter;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using WkHtmlToPdfDotNet;
using Xunit;
using Newtonsoft.Json;

namespace Converters.Test
{
    public class ConvertToPdf : IDisposable
    {
        private bool Result;
        private string OutputPath = @"E:\C#\Web\Test\ConvertFromPdf\Output";
        private string InputPath = @"E:\C#\Web\Test\ConvertFromPdf\Input";
        private string InputPdfPathEnglish = @"E:\C#\Web\Test\ConvertFromPdf\Input\Test-English.pdf";
        private string InputPathForApi = @"E:\C\Input";
        private string OutputPathForApi = @"E:\C\Output";

        [Fact]
        protected bool JpgToPdf()
        {
            try
            {
                Document document = new Document();
                using (var stream = new FileStream($"{OutputPath}\\Resume.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    for (int i = 1; i <= 2; i++)
                    {
                        using (var imageStream = new FileStream($"{InputPath}\\Resume.jpg", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            document.Add(image);
                        }
                    }
                    document.Close();
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PngToPdf()
        {
            try
            {
                Document document = new Document();
                using (var stream = new FileStream($"{OutputPath}\\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    for (int i = 1; i <= 5; i++)
                    {
                        using (var imageStream = new FileStream($"{InputPath}\\{Formating.ReturnFileNameWithoutDate(FilesFormat.png, "", i)}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            document.Add(image);
                        }
                    }
                    document.Close();
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool BmpToPdf()
        {
            try
            {
                Document document = new Document();
                using (var stream = new FileStream($"{OutputPath}\\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    for (int i = 1; i <= 5; i++)
                    {
                        using (var imageStream = new FileStream($"{InputPath}\\{Formating.ReturnFileNameWithoutDate(FilesFormat.bmp, "", i)}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            document.Add(image);
                        }
                    }
                    document.Close();
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool TiffToPdf()
        {
            try
            {
                Document document = new Document();
                using (var stream = new FileStream($"{OutputPath}\\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    for (int i = 1; i <= 5; i++)
                    {
                        using (var imageStream = new FileStream($"{InputPath}\\{Formating.ReturnFileNameWithoutDate(FilesFormat.tiff, "", i)}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            document.Add(image);
                        }
                    }
                    document.Close();
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool GifToPdf()
        {
            try
            {
                Document document = new Document();
                using (var stream = new FileStream($"{OutputPath}\\test.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    for (int i = 1; i <= 5; i++)
                    {
                        using (var imageStream = new FileStream($"{InputPath}\\{Formating.ReturnFileNameWithoutDate(FilesFormat.gif, "", i)}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            document.Add(image);
                        }
                    }
                    document.Close();
                }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool HtmlToPdf_WithouthCss()
        {
            try
            {
                //Initialize the HTML to PDF converter with the Blink rendering engine.
                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

                BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

                //Set the BlinkBinaries folder path 
                blinkConverterSettings.BlinkPath = "BlinkBinariesWindows"; ;

                //Assign Blink converter settings to HTML converter.
                htmlConverter.ConverterSettings = blinkConverterSettings;

                //Convert HTML string to PDF.
                Syncfusion.Pdf.PdfDocument document = htmlConverter.Convert(AppliedMethodes.GetSourcePage(@"https://www.nuget.org/packages/Wkhtmltopdf.NetCore/"), "");

                FileStream fileStream = new FileStream($"{OutputPath}\\{GetMyIp()}\\{Formating.ReturnFileName(FilesFormat.pdf, "Pdf")}", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                //Save and close the PDF document .
                document.Save(fileStream);
                document.Close(true);
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(Result, true);
            return true;
        }

        [Fact]
        protected bool HtmlToPdfWithCss()
        {
            try
            {
                var converter = new SynchronizedConverter(new PdfTools());
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    ColorMode = WkHtmlToPdfDotNet.ColorMode.Color,
                    Orientation = WkHtmlToPdfDotNet.Orientation.Portrait,
                    PaperSize = WkHtmlToPdfDotNet.PaperKind.A4,
                    ImageQuality=350,
                    Margins = new MarginSettings() { Top = 25 },
                    Out = $"{OutputPath}\\{GetMyIp()}\\{Formating.ReturnFileName(FilesFormat.pdf,"Pdf")}",
                    },
                    Objects = {
                    new ObjectSettings()
                    {
                        Page = @"https://github.com/HakanL/WkHtmlToPdf-DotNet",
                        PagesCount = true,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }

                    },
                    }
                };
                converter.Convert(doc);
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(Result, true);
            return true;
        }

        [Fact]
        protected bool PptToPdf()
        {
            try
            {
                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker("http://127.0.0.1:5000", ApiServices.PptToPdf, InputPathForApi, "samplepptx.pptx", OutputPathForApi, GetMyIp()), false);
                var Response = JsonConvert.DeserializeObject<ResultMessage<ServiceResponseEntities>>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        Result = true;
                    else
                        Result = false;
                else
                    Result = false;
            }
            catch
            {
                Result = false;
            }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool XlsxToPdf()
        {
            try
            {
                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker("http://127.0.0.1:5000", ApiServices.XlsxToPdf, InputPathForApi, "Financial.xlsx", OutputPathForApi, GetMyIp()), false);
                var Response = JsonConvert.DeserializeObject<ResultMessage<ServiceResponseEntities>>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        Result = true;
                    else
                        Result = false;
                else
                    Result = false;
            }
            catch
            {
                Result = false;
            }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool WordToPdf()
        {
            try
            {
                // internal feature
                /*string outpath = OutputPath ;
                if (!Directory.Exists(outpath))
                    Directory.CreateDirectory(outpath);
                DocumentCore dc = DocumentCore.Load("E:\\Daneshgah\\Term 01\\ggg.docx");
                dc.Save(outpath, new HtmlFixedSaveOptions()
                {
                    EmbedImages = true
                });*/

                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker("http://127.0.0.1:5000", ApiServices.DocToPdf, InputPathForApi, "ggg.docx", OutputPathForApi, GetMyIp()), false);
                var Response = JsonConvert.DeserializeObject<ResultMessage<ServiceResponseEntities>>(Sender.Result.ResponseContent);
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

        public void Dispose()
        {

        }
    }
}
