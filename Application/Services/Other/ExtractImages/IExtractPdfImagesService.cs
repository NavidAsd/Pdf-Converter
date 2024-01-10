using Common;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Application.Services.Other.ExtractImages
{
    public interface IExtractPdfImagesService
    {
        Task<ResultMessage<ResultExtractPdfImagesDto>> ExecuteAsync(RequestExtractPdfImagesDto request);
    }
    public class ResultExtractPdfImagesDto
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
    }
    public class RequestExtractPdfImagesDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class ExtractPdfImagesService : IExtractPdfImagesService
    {
        async Task<ResultMessage<ResultExtractPdfImagesDto>> IExtractPdfImagesService.ExecuteAsync(RequestExtractPdfImagesDto request)
        {
            try
            {
                var PdfEncrypted =await AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
                if (PdfEncrypted.Success)
                {
                    return new ResultMessage<ResultExtractPdfImagesDto> { Success = false, Message = PdfEncrypted.Message };
                }

                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.ExtractImages, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp), false);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultExtractPdfImagesDto>
                        {
                            Success = true,
                            Enything = new ResultExtractPdfImagesDto
                            {
                                FileName = Response.OutFile,
                                FilePath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultExtractPdfImagesDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultExtractPdfImagesDto>
                {
                    Success = false,
                    Message = "Error on Process Please Try Again",
                };
            }
        }
    }
}
