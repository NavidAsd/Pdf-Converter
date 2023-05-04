using Common;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Organizers.DeletePdfPages
{
    public interface IDeletePdfPagesService
    {
        Task<ResultMessage<ResultDeletePdfPagesDto>> ExecuteAsync(RequestDeletePdfPageDto request);
        ResultMessage<ResultReturnPdfPagesDto> ReturnPdfPages(RequestReturnPdfPagesDto request);
    }
    public class ResultDeletePdfPagesDto
    {
        public string OutFileName { set; get; }
        public string OutFilePath { set; get; }
    }
    public class ResultReturnPdfPagesDto
    {
        public int PageCount { set; get; }
        public long Id { set; get; }// for find input file
    }
    public class RequestReturnPdfPagesDto
    {
        public string InputFileFullPath { set; get; }
        public long Id { set; get; } // for find input file
    }
    public class RequestDeletePdfPageDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public int[] DeletePages { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class DeletePdfPagesService : IDeletePdfPagesService
    {
       async Task<ResultMessage<ResultDeletePdfPagesDto>> IDeletePdfPagesService.ExecuteAsync(RequestDeletePdfPageDto request)
        {
            var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
            if (PdfEncrypted.Result.Success)
            {
                return new ResultMessage<ResultDeletePdfPagesDto> { Success = false, Message = PdfEncrypted.Result.Message };
            }

            int[] Allpages;
            string pageskeeped = "";
            string OutFileName = Formating.ReturnFileName(FilesFormat.pdf, "Pdf");
            string OutFilePath = $"{request.OutputPath}\\{request.UserIp}";
            AppliedMethodes.CreateDirectory(OutFilePath);
            try
            {
                using (PdfReader reader = new PdfReader($"{request.InputFilePath}\\{request.InputFileName}"))
                {
                    Allpages = new int[reader.NumberOfPages];
                    for (int i = 0; i < reader.NumberOfPages; i++)
                    {
                        Allpages[i] = i + 1;
                    }
                    foreach (var item in Allpages.Except(request.DeletePages).ToList())
                    {
                        pageskeeped += $",{item}";
                    }
                    reader.SelectPages(pageskeeped);

                    using (PdfStamper stamper = new PdfStamper(reader, File.Create($"{OutFilePath}\\{OutFileName}")))
                    {
                        stamper.Close();
                    }
                }
                return new ResultMessage<ResultDeletePdfPagesDto>
                {
                    Success = true,
                    Enything = new ResultDeletePdfPagesDto
                    {
                        OutFileName = OutFileName,
                        OutFilePath = OutFilePath,
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultDeletePdfPagesDto>
                {
                    Success = false,
                    Message = "Error on Process Please Try Again",
                    Enything = null
                };
            }

        }
        ResultMessage<ResultReturnPdfPagesDto> IDeletePdfPagesService.ReturnPdfPages(RequestReturnPdfPagesDto request)
        {
            PdfReader pdfReader = new PdfReader(request.InputFileFullPath);
            int numberOfPages = pdfReader.NumberOfPages;
            if (numberOfPages > 0)
            {
                return new ResultMessage<ResultReturnPdfPagesDto>
                {
                    Success = true,
                    Enything = new ResultReturnPdfPagesDto { PageCount = numberOfPages, Id = request.Id },
                };
            }
            return new ResultMessage<ResultReturnPdfPagesDto>
            {
                Success = false,
                Enything = new ResultReturnPdfPagesDto { PageCount = 0 },
                Message = "Imported file pages not found. The file may be corrupted, please re-upload carefully"
            };
        }
    }
}
