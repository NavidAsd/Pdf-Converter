using Application.UseServices;
using Common;
using System.Drawing.Imaging;
using System.IO;

namespace Application.Services.ConvertFormPdf.PdfToTiff
{
    public interface IPdfToTiffService
    {
        ResultMessage<ReturnPdfToImagesDto> Execute(RequestPdfToTiffDto request);
    }
    public class RequestPdfToTiffDto
    {
        public string OutputPath { set; get; }
        public string InputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class PdfToTiffService : IPdfToTiffService
    {
        ResultMessage<ReturnPdfToImagesDto> IPdfToTiffService.Execute(RequestPdfToTiffDto request)
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
                        string ImageName = Formating.ReturnFileNameWithoutDate(FilesFormat.tiff, "Tiff", i);
                        var image = document.Render(i, 300, 300, true);
                        image.Save($"{ImagePath}\\{ImageName}", ImageFormat.Tiff);
                        files[i] = $"{ImagePath}\\{ImageName}";
                    }
                }
                string OutFileName = Formating.ReturnZipFileName(FilesFormat.zip, "Tiff");
                string OutputFullPath = $"{ImagePath}\\{OutFileName}";
                AppliedMethodes.CreateZipFile(OutputFullPath, files);
                try
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        //Delete All Tiff Files
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
