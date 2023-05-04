using Common;
using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Xunit;
using Newtonsoft.Json;
using Application.Services.ConvertFormPdf.PdfToPower;

namespace Converters.Test
{
    public class ConvertFromPdf : IDisposable
    {
        private string OutputPath = @"E:\C#\Web\Test\ConvertFromPdf\Output";
        private string InputPdfPath = @"E:\C#\Web\Test\ConvertFromPdf\Input\test2.pdf";
        private string InputPdfPathEnglish = @"E:\C#\Web\Test\ConvertFromPdf\Input\Test-English.pdf";
        private string InputPath = @"E:\C#\Web\Test\ConvertFromPdf\Input";
        private string InputName = @"Test-English.pdf";
        private string InputPathForApi = @"E:\C\Input";
        private string OutputPathForApi = @"E:\C\Output";

        private bool Result;
        [Fact]
        protected bool PdfToBmp()
        {
            //Passed\\
            try
            {
                string[] files;
                string ImagePath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);

                using (var document = PdfiumViewer.PdfDocument.Load(InputPdfPath))
                {
                    files = new string[document.PageCount];
                    for (int i = 0; i < document.PageCount; i++)
                    {
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.bmp, "Bmp", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Bmp);
                        files[i] = $"{ImagePath}\\{ImageName}";

                    }
                }
                string Output = $"{ImagePath}\\{Formating.ReturnZipFileName(FilesFormat.zip, "Bmp")}";
                AppliedMethodes.CreateZipFile(Output, files);
                Result = true;
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Bmp Files
                        File.Delete(files[i]);
                    }
                }
                catch { }
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;

        }

        [Fact]
        protected bool PdfToExcel()
        {
            try
            {
                // no
                string ExcelName = Formating.ReturnFileName(FilesFormat.xlsx, "Excel"); ;
                string ExcelPath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(ExcelPath))
                    Directory.CreateDirectory(ExcelPath);

                // Load PDF document
                /*Document pdfDocument = new Document(InputPdfPath);
                // Initialize ExcelSaveOptions
                ExcelSaveOptions options = new ExcelSaveOptions();
                // Set output 
                options.Format = ExcelSaveOptions.ExcelFormat.XLSX;
                options.MinimizeTheNumberOfWorksheets = true;
                options.UniformWorksheets = true;
                options.InsertBlankColumnAtFirst = true;
                // Save output file
                pdfDocument.Save($"{ExcelPath}\\{ExcelName}", options);*/

                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(InputPdfPathEnglish);

                if (f.PageCount > 0)
                    f.ToExcel($"{ExcelPath}\\{ExcelName}");



                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PdfToGif()
        {
            try
            {
                // Passed
                string[] files;
                string ImagePath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);

                using (var document = PdfiumViewer.PdfDocument.Load(InputPdfPath))
                {
                    files = new string[document.PageCount];
                    for (int i = 0; i < document.PageCount; i++)
                    {
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.gif, "Gif", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Gif);
                        files[i] = $"{ImagePath}\\{ImageName}";
                    }
                }
                string Output = $"{ImagePath}\\{Formating.ReturnZipFileName(FilesFormat.zip, "Gif")}";
                AppliedMethodes.CreateZipFile(Output, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Gif Files
                        File.Delete(files[i]);
                    }
                }
                catch { }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PdfToJpg()
        {
            try
            {
                // Passed
                string[] files;
                string ImagePath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);

                using (var document = PdfiumViewer.PdfDocument.Load(InputPdfPath))
                {
                    files = new string[document.PageCount];
                    for (int i = 0; i < document.PageCount; i++)
                    {
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.jpg, "Jpg", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Gif);
                        files[i] = $"{ImagePath}\\{ImageName}";
                    }
                }
                string Output = $"{ImagePath}\\{Formating.ReturnZipFileName(FilesFormat.zip, "Jpg")}";
                AppliedMethodes.CreateZipFile(Output, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Jpg Files
                        File.Delete(files[i]);
                    }
                }
                catch { }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PdfToPdfA()
        {
            try
            {
                // Passed
                string PdfAName = Formating.ReturnFileName(FilesFormat.pdf, "PdfA");
                string PdfAPath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(PdfAPath))
                    Directory.CreateDirectory(PdfAPath);

                SautinSoft.Document.PdfLoadOptions pdfLO = new SautinSoft.Document.PdfLoadOptions()
                {
                    // 'false' - means to load vector graphics as is. Don't transform it to raster images.
                    RasterizeVectorGraphics = false,
                    // The PDF format doesn't have real tables, in fact it's a set of orthogonal graphic lines.
                    // In case of 'true' the component will detect and recreate tables from graphic lines.
                    DetectTables = true,
                    ShowInvisibleText = true,
                    OptimizeImages = true,

                    // 'Auto' - Load only embedded fonts missing in the system. In other case, use the system fonts.
                    PreserveEmbeddedFonts = SautinSoft.Document.PropertyState.Auto
                };

                SautinSoft.Document.DocumentCore dc = SautinSoft.Document.DocumentCore.Load(InputPdfPath, pdfLO);

                SautinSoft.Document.PdfSaveOptions pdfSO = new SautinSoft.Document.PdfSaveOptions()
                {
                    Compliance = SautinSoft.Document.PdfCompliance.PDF_A1a
                };

                dc.Save($"{PdfAPath}\\{PdfAName}", pdfSO);
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PdfToPng()
        {
            try
            {
                string[] files;
                string ImagePath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);

                using (var document = PdfiumViewer.PdfDocument.Load(InputPdfPath))
                {
                    files = new string[document.PageCount];
                    for (int i = 0; i < document.PageCount; i++)
                    {
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.png, "Png", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Gif);
                        files[i] = $"{ImagePath}\\{ImageName}";
                    }
                }
                string Output = $"{ImagePath}\\{Formating.ReturnZipFileName(FilesFormat.zip, "Png")}";
                AppliedMethodes.CreateZipFile(Output, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Png Files
                        File.Delete(files[i]);
                    }
                }
                catch { }
                Result = true;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PdfToPpt_first()
        {// just convert 4 pages
           /* try
            {
                Aspose.Pdf.License license = new Aspose.Pdf.License();
                license.SetLicense("[Content_Types].xml");

                string PPtName = Formating.ReturnFileName(FilesFormat.ppt, "PowerPoint");
                string PPtPath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(PPtPath))
                    Directory.CreateDirectory(PPtPath);
                // Load PDF document
                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document(InputPdfPath);
                Aspose.Pdf.PptxSaveOptions pptxOptions = new Aspose.Pdf.PptxSaveOptions();
                pptxOptions.SlidesAsImages = true;
                // Save output file
                pdfDocument.Save($"{PPtPath}\\{PPtName}", pptxOptions);
                Result = true;
            }
            catch { Result = false; }*/
            return Result;

        }

        [Fact]
        protected bool PdfToPpt()
        {
            try
            {
                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.PdfToPpt, InputPathForApi, InputName, OutputPathForApi, GetMyIp()), false);
                var Response = JsonConvert.DeserializeObject<ResultMessage<ServiceResponseEntities>>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                    {
                       var a = new ResultMessage<ResultPdfToPowerPointDto>
                        {
                            Success = true,
                            Enything = new ResultPdfToPowerPointDto
                            {
                                PPTName = Response.Enything.OutFile,
                                PPTPath = Response.Enything.OutPath
                            }
                        };
                        Result = true;
                    }
                    else
                        Result = false;
                else
                    Result = false;
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }
        
        [Fact]
        protected bool PdfToWord()
        {
            //passed
            string DocName = Formating.ReturnFileName(FilesFormat.docx, "Word");
            string DocPath = $"{OutputPath}\\{GetMyIp()}";
            if (!Directory.Exists(DocPath))
                Directory.CreateDirectory(DocPath);

            try
            {
                SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
                f.OpenPdf(InputPdfPath);

                if (f.PageCount > 0)
                {
                    f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;
                    int result = f.ToWord($"{DocPath}\\{DocName}");
                    if (result == 0)
                        Result = true;
                    else
                        Result = false;
                }
            }
            catch { Result = false; }
            Assert.Equal(true, Result);
            return Result;
        }

        [Fact]
        protected bool PdfToTiff()
        {
            try
            {
                string[] files;
                string ImagePath = $"{OutputPath}\\{GetMyIp()}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);

                using (var document = PdfiumViewer.PdfDocument.Load(InputPdfPath))
                {
                    files = new string[document.PageCount];
                    for (int i = 0; i < document.PageCount; i++)
                    {
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.tiff, "Tiff", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Tiff);
                        files[i] = $"{ImagePath}\\{ImageName}";
                    }
                }
                string Output = $"{ImagePath}\\{Formating.ReturnZipFileName(FilesFormat.zip, "Tiff")}";
                AppliedMethodes.CreateZipFile(Output, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Tiff Files
                        File.Delete(files[i]);
                    }
                }
                catch { }
                Result = true;
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
