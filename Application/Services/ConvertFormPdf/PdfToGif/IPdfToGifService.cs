using Application.UseServices;
using Common;
using System.Drawing.Imaging;
using System.IO;

namespace Application.Services.ConvertFormPdf.PdfToGif
{
    public interface IPdfToGifService
    {
        ResultMessage<ReturnPdfToImagesDto> Execute(RequestPdfToGifDto request);
    }
    public class RequestPdfToGifDto
    {
        public string OutputPath { set; get; }
        public string InputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class PdfToGifService : IPdfToGifService
    {
        ResultMessage<ReturnPdfToImagesDto> IPdfToGifService.Execute(RequestPdfToGifDto request)
        {
            try
            {
                var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted(request.InputPath);
                if (PdfEncrypted.Result.Success)
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
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.gif, "Gif", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Gif);
                        files[i] = $"{ImagePath}\\{ImageName}";
                    }
                }
                string OutFileName = Formating.ReturnZipFileName(FilesFormat.zip, "Gif");
                string OutputFullPath = $"{ImagePath}\\{OutFileName}";
                AppliedMethodes.CreateZipFile(OutputFullPath, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Gif Files
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
