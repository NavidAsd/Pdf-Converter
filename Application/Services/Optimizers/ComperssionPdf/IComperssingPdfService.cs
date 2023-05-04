using Common;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Application.Services.Optimizers.ComperssionPdf
{
    public interface IComperssingPdfService
    {
        Task<ResultMessage<ResultComperssingPdfDto>> ExecuteAsync(RequestComperssingPdfDto request);
    }
    public class ResultComperssingPdfDto
    {
        public string OutFileName { set; get; }
        public string OutFilePath { set; get; }
        public long OutFileSize { set; get; }
    }
    public class RequestComperssingPdfDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
        
    }
    public class ReturnDataForController
    {
        public string OutFileSize { set; get; }
        public string InputFileSize { set; get; }
        public long Id { set; get; }
        public string OutFileName { set; get; }
    }
    public class ComperssingPdfService : IComperssingPdfService
    {
        async Task<ResultMessage<ResultComperssingPdfDto>> IComperssingPdfService.ExecuteAsync(RequestComperssingPdfDto request)
        {
            try
            {
                var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
                if (PdfEncrypted.Result.Success)
                {
                    return new ResultMessage<ResultComperssingPdfDto> { Success = false, Message = PdfEncrypted.Result.Message };
                }

                // add other encoding to .net core for save outputfile
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string OutFileName = Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "Pdf-Compressed");
                string OutFilePath = $"{request.OutputPath}\\{request.UserIp}";

                AppliedMethodes.CreateDirectory(OutFilePath);
                using (var stream = new MemoryStream(File.ReadAllBytes($"{request.InputFilePath}\\{request.InputFileName}")) { Position = 0 })
                using (var source = PdfSharp.Pdf.IO.PdfReader.Open(stream, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import))
                using (var document = new PdfSharp.Pdf.PdfDocument())
                {
                    var options = document.Options;
                    options.FlateEncodeMode = PdfSharp.Pdf.PdfFlateEncodeMode.BestCompression;
                    options.UseFlateDecoderForJpegImages = PdfSharp.Pdf.PdfUseFlateDecoderForJpegImages.Automatic;
                    options.CompressContentStreams = true;
                    options.NoCompression = false;
                    foreach (var page in source.Pages)
                    {
                       document.AddPage(page);
                    }

                     document.Save($"{OutFilePath}\\{OutFileName}");
                }
                return new ResultMessage<ResultComperssingPdfDto>
                {
                    Success = true,
                    Enything = new ResultComperssingPdfDto
                    {
                        OutFileName = OutFileName,
                        OutFilePath = OutFilePath,
                        OutFileSize = new System.IO.FileInfo($"{OutFilePath}\\{OutFileName}").Length,
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultComperssingPdfDto>
                {
                    Success = false,
                    Message = "Error on Process Please Try Again",
                    Enything = null
                };
            }
        }
    }
}
