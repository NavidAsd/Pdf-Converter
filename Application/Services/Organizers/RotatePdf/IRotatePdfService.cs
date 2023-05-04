using Common;
using iTextSharp.text.pdf;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.Organizers.RotatePdf
{
    public interface IRotatePdfService
    {
        Task<ResultMessage<ResultRotatePdfDto>> ExecuteAsync(RequestRotatePdfDto request);
    }
    public enum Rotation
    {
        Normal = 0,
        Position1 =90,
        Position2 = 180,
        Position3 = 270,
        Position4 = 360
    }
    public class ResultRotatePdfDto
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
    }
    public class RequestRotatePdfDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public Rotation DegreeRotation { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class RotatePdfService : IRotatePdfService
    {
      async Task<ResultMessage<ResultRotatePdfDto>> IRotatePdfService.ExecuteAsync(RequestRotatePdfDto request)
        {
            var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
            if (PdfEncrypted.Result.Success)
            {
                return new ResultMessage<ResultRotatePdfDto> { Success = false, Message = PdfEncrypted.Result.Message };
            }

            string OutFileName = Formating.ReturnFileNameWithoutModified(FilesFormat.pdf, "Rotated-Pdf");
            string OutFilePath = $"{request.OutputPath}\\{request.UserIp}";
            if (!Directory.Exists(OutFilePath))
                Directory.CreateDirectory(OutFilePath);
            try
            {
                PdfReader reader = new PdfReader($"{request.InputFilePath}\\{request.InputFileName}");
                int pagesCount = reader.NumberOfPages;

                for (int n = 1; n <= pagesCount; n++)
                {
                    PdfDictionary page = reader.GetPageN(n);
                    PdfNumber rotate = page.GetAsNumber(PdfName.ROTATE);
                    int rotation =
                           rotate == null ? 90 : (rotate.IntValue + (int)request.DegreeRotation) % 360;

                    page.Put(PdfName.ROTATE, new PdfNumber(rotation));

                }
                PdfStamper stamper = new PdfStamper(reader, File.Create($"{OutFilePath}\\{OutFileName}"));

                stamper.Close();
                reader.Close();
                return new ResultMessage<ResultRotatePdfDto>
                {
                    Success = true,
                    Enything = new ResultRotatePdfDto
                    {
                        FileName = OutFileName,
                        FilePath = OutFilePath,
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultRotatePdfDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                    Enything = null
                };
            }
        }
    }
}
