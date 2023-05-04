using Application.UseServices;
using Common;
using iTextSharp.text.pdf;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.ConvertFormPdf.PdfToBmp
{
    public interface IPdfToBmpService
    {
        ResultMessage<ReturnPdfToImagesDto> Execute(RequestPdfToBmpDto request);
    }
    public class RequestPdfToBmpDto
    {
        public string OutputPath { set; get; }
        public string InputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class PdfToBmpService : IPdfToBmpService
    {
        ResultMessage<ReturnPdfToImagesDto> IPdfToBmpService.Execute(RequestPdfToBmpDto request)
        {
            try
            {
                var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted(request.InputPath);
                if (!PdfEncrypted.Result.Success)
                {
                    return new ResultMessage<ReturnPdfToImagesDto> { Success = false, Message = PdfEncrypted.Result.Message };
                }

                string[] files;
                string ImagePath = $"{request.OutputPath}\\{request.UserIp}";
                if (!Directory.Exists(ImagePath))
                    Directory.CreateDirectory(ImagePath);

                 using (var document = PdfiumViewer.PdfDocument.Load(request.InputPath))
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
                string OutFileName = Formating.ReturnZipFileName(FilesFormat.zip, "Bmp");
                string OutputFullPath = $"{ImagePath}\\{OutFileName}";
                AppliedMethodes.CreateZipFile(OutputFullPath, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Bmp Files
                        File.Delete(files[i]);
                    }
                }
                catch { }
                return new ResultMessage<ReturnPdfToImagesDto>
                {
                    Success = true,
                    Enything = new ReturnPdfToImagesDto
                    {
                        ImageName = OutFileName,
                        ImagePath = ImagePath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ReturnPdfToImagesDto>
                {
                    Success = false,
                    Message = "Error on Converting Process",
                    Enything = null
                };
            }
        }
    }

}
