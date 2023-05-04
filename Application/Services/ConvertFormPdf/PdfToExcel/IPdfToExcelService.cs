using Application.Interface;
using Common;
using System.IO;

namespace Application.Services.ConvertFormPdf.PdfToExcel
{
    public interface IPdfToExcelService
    {
        ResultMessage<ResultPdfToExcelDto> Execute(RequestPdfToExcelDto request);
    } 
    public class ResultPdfToExcelDto
    {
        public string ExcelName { set; get; }
        public string ExcelPath { set; get; }
    }
    public class RequestPdfToExcelDto
    {
        public string PdfPath { set; get; }
        public string ExcelPath { set; get; }
        public string UserIp { set; get; }
    }
    public class PdfToExcelService : IPdfToExcelService
    {
        ResultMessage<ResultPdfToExcelDto> IPdfToExcelService.Execute(RequestPdfToExcelDto request)
        {
            try
            {
                string ExcelName = Formating.ReturnFileName(FilesFormat.xlsx, "Excel"); ;
                string ExcelPath = $"{request.ExcelPath}\\{request.UserIp}";
                if (!Directory.Exists(ExcelPath))
                    Directory.CreateDirectory(ExcelPath);

               /* // Load PDF document
                Document pdfDocument = new Document(request.PdfPath);
                // Initialize ExcelSaveOptions
                ExcelSaveOptions options = new ExcelSaveOptions();
                // Set output 
                options.Format = ExcelSaveOptions.ExcelFormat.XLSX;
                options.MinimizeTheNumberOfWorksheets = true;
                options.UniformWorksheets = true;
                options.InsertBlankColumnAtFirst = true;
                // Save output file
                pdfDocument.Save($"{ExcelPath}\\{ExcelName}", options);*/

                return new ResultMessage<ResultPdfToExcelDto>
                {
                    Success = true,
                    Enything = new ResultPdfToExcelDto
                    {
                        ExcelName = ExcelName,
                        ExcelPath = ExcelPath
                    }
                };
            }
            catch
            {
                return new ResultMessage<ResultPdfToExcelDto>
                {
                    Success = false,
                    Message = "Error on Converting Process",
                    Enything = null
                };
            }
        }
    }

}
