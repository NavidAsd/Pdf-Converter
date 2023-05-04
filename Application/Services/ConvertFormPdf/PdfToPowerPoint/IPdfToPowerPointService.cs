using Common;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Application.Services.ConvertFormPdf.PdfToPower
{
    public interface IPdfToPowerPointService
    {
        Task<ResultMessage<ResultPdfToPowerPointDto>> ExecuteAsync(RequestPdfToPowerPointDto request);
    }
    public class ResultPdfToPowerPointDto
    {
        public string PPTName { set; get; }
        public string PPTPath { set; get; }
    }
    public class RequestPdfToPowerPointDto
    {
        public string InputFilePath { set; get; }
        public string InputFileName { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
    }
    public class PdfToPowerPointService : IPdfToPowerPointService
    {
        async Task<ResultMessage<ResultPdfToPowerPointDto>> IPdfToPowerPointService.ExecuteAsync(RequestPdfToPowerPointDto request)
        {
            try
            {
                var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
                if (PdfEncrypted.Result.Success)
                {
                    return new ResultMessage<ResultPdfToPowerPointDto> { Success = false, Message = PdfEncrypted.Result.Message };
                }
                if (AppliedMethodes.ReturnPdfPagesCount($"{request.InputFilePath}\\{request.InputFileName}") > 50)
                {
                    return new ResultMessage<ResultPdfToPowerPointDto>
                    {
                        Success = false,
                        Message = "We can not accept pdfs longer than 50 pages for this service",
                        Enything = null
                    };
                }

                var Sender = await AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.PdfToPpt, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp), true);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.ResponseContent);
                if (Sender.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultPdfToPowerPointDto>
                        {
                            Success = true,
                            Enything = new ResultPdfToPowerPointDto
                            {
                                PPTName = Response.OutFile,
                                PPTPath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultPdfToPowerPointDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultPdfToPowerPointDto>
                {
                    Success = false,
                    Message = "Error In Converting Proccess",
                    Enything = null
                };
            }
        }
    }
}
