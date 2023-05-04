using Common;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Application.Services.ConvertToPdf.PptToPdf
{
    public interface IPptToPdfService
    {
        Task<ResultMessage<ResultPptToPdfDto>> ExecuteAsync(RequestPptToPdfDto request);
    }
    public class ResultPptToPdfDto
    {
        public string OutFile { set; get; }
        public string OutPath { set; get; }
    }
    public class RequestPptToPdfDto
    {
        public string InputFilePath { set; get; }
        public string InputFileName { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class PptToPdfService : IPptToPdfService
    {
        async Task<ResultMessage<ResultPptToPdfDto>> IPptToPdfService.ExecuteAsync(RequestPptToPdfDto request)
        {
            try
            {
                var Sender = await AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.PptToPdf, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp), true);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.ResponseContent);
                if (Sender.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultPptToPdfDto>
                        {
                            Success = true,
                            Enything = new ResultPptToPdfDto
                            {
                                OutFile = Response.OutFile,
                                OutPath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultPptToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultPptToPdfDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
    }
}
