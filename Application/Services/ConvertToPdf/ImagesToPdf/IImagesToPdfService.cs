using Application.UseServices;
using Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;

namespace Application.Services.ConvertToPdf.ImagesToPdf
{
    public interface IImagesToPdfService
    {
        ResultMessage<ResultImagesToPdfDto> Execute(RequestJpgToPdfDto request);
    }
    public class ResultImagesToPdfDto
    {
        public string PdfName { set; get; }
        public string PdfPath { set; get; }
    }
    public class RequestJpgToPdfDto
    {
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
        public List<InputImages> Images { set; get; }
    }
    public class InputImages
    {
        public string InputFilePath { set; get; }
        public string InputFileName { set; get; }
    }
    public class ImagesToPdfService : IImagesToPdfService
    {
        ResultMessage<ResultImagesToPdfDto> IImagesToPdfService.Execute(RequestJpgToPdfDto request)
        {
            string FileOutName = Formating.ReturnFileName(FilesFormat.pdf, "Pdf");
            string FileOutPath = $"{ request.OutputPath }\\{request.UserIp}";
            AppliedMethodes.CreateDirectory(FileOutPath);
            try
            {
                Rectangle Size = new Rectangle(950, 950);// images size
                Rectangle pSize = new Rectangle(1000, 1000); //page size
                Document document = new Document(pSize, 5, 5, 15, 10);
                using (var stream = new FileStream($"{FileOutPath}\\{FileOutName}", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    foreach (var item in request.Images)
                    {
                        using (var imageStream = new FileStream($"{item.InputFilePath}\\{item.InputFileName}", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var image = Image.GetInstance(imageStream);
                            image.Alignment = Element.ALIGN_CENTER;
                            image.ScaleToFit(Size);
                            document.Add(image);
                        }
                    }
                    document.Close();
                }
                return new ResultMessage<ResultImagesToPdfDto>
                {
                    Success = true,
                    Enything = new ResultImagesToPdfDto
                    {
                        PdfName = FileOutName,
                        PdfPath = FileOutPath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultImagesToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
    }
}
