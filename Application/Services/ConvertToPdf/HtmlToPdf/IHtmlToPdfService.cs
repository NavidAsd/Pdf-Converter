using Common;
using Syncfusion.HtmlConverter;
using System;
using System.IO;
using System.Threading.Tasks;
using WkHtmlToPdfDotNet;

namespace Application.Services.ConvertToPdf.HtmlToPdf
{
    public interface IHtmlToPdfService
    {
        Task<ResultMessage<ResultHtmlToPdfDto>> ConvertWithCssAsync(RequestHtmlToPdfDto request);
        Task<ResultMessage<ResultHtmlToPdfDto>> ExecuteAsync(RequestHtmlToPdfDto request);
    }
    public class ResultHtmlToPdfDto
    {
        public string PdfName { set; get; }
        public string PdfPath { set; get; }
    }
    public class RequestHtmlToPdfDto
    {
        public string InputUrl { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class HtmlToPdfService : IHtmlToPdfService
    {
       async Task<ResultMessage<ResultHtmlToPdfDto>> IHtmlToPdfService.ConvertWithCssAsync(RequestHtmlToPdfDto request)
        {
            try
            {
                if (!Uri.IsWellFormedUriString(request.InputUrl, UriKind.Absolute))
                {
                    return new ResultMessage<ResultHtmlToPdfDto>
                    {
                        Success = false,
                        Message = "The entered url is invalid",
                        Enything = null
                    };
                }
            }
            catch { }
            try
            {
                var converter = new SynchronizedConverter(new PdfTools());
                string FileOutName = Formating.ReturnFileName(FilesFormat.pdf, "Pdf");
                string FileOutPath = $"{request.OutputPath}\\{ request.UserIp}";
                AppliedMethodes.CreateDirectory(FileOutPath);
                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                    ColorMode = WkHtmlToPdfDotNet.ColorMode.Color,
                    Orientation = WkHtmlToPdfDotNet.Orientation.Portrait,
                    PaperSize = WkHtmlToPdfDotNet.PaperKind.A4,
                    ImageQuality=350,
                    Margins = new MarginSettings() { Top = 25 },
                    Out = $"{FileOutPath}\\{FileOutName}",
                    },
                    Objects = {
                    new ObjectSettings()
                    {
                        Page = request.InputUrl,
                        PagesCount = true,
                        WebSettings = { DefaultEncoding = "utf-8" },
                        HeaderSettings = { FontSize = 9, Right = "Page [page] of [toPage]", Line = true, Spacing = 2.812 }
                    },
                    }
                };
                converter.Convert(doc);
                
                return new ResultMessage<ResultHtmlToPdfDto>
                {
                    Success = true,
                    Enything = new ResultHtmlToPdfDto
                    {
                        PdfName = FileOutName,
                        PdfPath = FileOutPath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultHtmlToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
  
       async Task<ResultMessage<ResultHtmlToPdfDto>> IHtmlToPdfService.ExecuteAsync(RequestHtmlToPdfDto request)
        {
            try
            {
                if (!Uri.IsWellFormedUriString(request.InputUrl, UriKind.Absolute))
                {
                    return new ResultMessage<ResultHtmlToPdfDto>
                    {
                        Success = false,
                        Message = "The entered url is invalid",
                        Enything = null
                    };
                }
            }
            catch { }
            try
            {
                string FileOutName = Formating.ReturnFileName(FilesFormat.pdf, "Pdf");
                string FileOutPath = $"{request.OutputPath}\\{request.UserIp}";
                AppliedMethodes.CreateDirectory(FileOutPath);

                //Initialize the HTML to PDF converter with the Blink rendering engine.
                HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.Blink);

                BlinkConverterSettings blinkConverterSettings = new BlinkConverterSettings();

                //Set the BlinkBinaries folder path 
                blinkConverterSettings.BlinkPath = $"{GetPath.GetBlinkWinPath()}/BlinkBinariesWindows";

                //Assign Blink converter settings to HTML converter.
                htmlConverter.ConverterSettings = blinkConverterSettings;

                //Convert HTML string to PDF.
                Syncfusion.Pdf.PdfDocument document = htmlConverter.Convert(AppliedMethodes.GetSourcePage(request.InputUrl), "");

                FileStream fileStream = new FileStream($"{FileOutPath}\\{FileOutName}", FileMode.OpenOrCreate, FileAccess.ReadWrite);

                //Save and close the PDF document 
                document.Save(fileStream);
                document.Close(true);
                fileStream.Close();

                return new ResultMessage<ResultHtmlToPdfDto>
                {
                    Success = true,
                    Enything = new ResultHtmlToPdfDto
                    {
                        PdfName = FileOutName,
                        PdfPath = FileOutPath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultHtmlToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
    }
}