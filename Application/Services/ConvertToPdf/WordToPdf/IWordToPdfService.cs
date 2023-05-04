using Common;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Application.Services.ConvertToPdf.WordToPdf
{
    public interface IWordToPdfService
    {
        Task<ResultMessage<ResultWordToPdfDto>> ExecuteAsync(RequestWordToPdfDto request);
    }
    public class ResultWordToPdfDto
    {
        public string PdfName { set; get; }
        public string PdfPath { set; get; }
    }
    public class RequestWordToPdfDto
    {
        public string InputFilePath { set; get; }
        public string InputFileName { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class WordToPdfService : IWordToPdfService
    {
        async Task<ResultMessage<ResultWordToPdfDto>> IWordToPdfService.ExecuteAsync(RequestWordToPdfDto request)
        {
            try
            {
                var Sender = await AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.DocToPdf, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp), false);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.ResponseContent);
                if (Sender.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultWordToPdfDto>
                        {
                            Success = true,
                            Enything = new ResultWordToPdfDto
                            {
                                PdfName = Response.OutFile,
                                PdfPath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultWordToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultWordToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
    }
}
