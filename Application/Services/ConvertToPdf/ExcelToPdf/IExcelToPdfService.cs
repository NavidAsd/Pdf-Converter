using Common;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Application.Services.ConvertToPdf.ExcelToPdf
{
   public interface IExcelToPdfService
    {
        Task<ResultMessage<ResultExcelToPdfDto>> ExecuteAsync(RequestExcelToPdfDto request);
    }
    public class ResultExcelToPdfDto
    {
        public string PdfName { set; get; }
        public string PdfPath { set; get; }
    }
    public class RequestExcelToPdfDto
    {
        public string InputFilePath { set; get; }
        public string InputFileName { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class ExcelToPdfService : IExcelToPdfService
    {
        async Task<ResultMessage<ResultExcelToPdfDto>> IExcelToPdfService.ExecuteAsync(RequestExcelToPdfDto request)
        {
            try
            {
                var Sender = await AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.XlsxToPdf, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp), false);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.ResponseContent);
                if (Sender.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultExcelToPdfDto>
                        {
                            Success = true,
                            Enything = new ResultExcelToPdfDto
                            {
                                PdfName = Response.OutFile,
                                PdfPath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultExcelToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultExcelToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
    }
}
