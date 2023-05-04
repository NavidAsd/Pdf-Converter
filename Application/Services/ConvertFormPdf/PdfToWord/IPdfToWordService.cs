using Common;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services.ConvertFormPdf.PdfToWord
{
    public interface IPdfToWordService
    {
        Task<ResultMessage<ResultPdfToWordDto>> ExecuteAsync(RequestPdfToWordDto request);
    }
    public class ResultPdfToWordDto
    {
        public string DocName { set; get; }
        public string DocPath { set; get; }
    }
    public class RequestPdfToWordDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string OutputPath { set; get; }
        public string UserIp { set; get; }
        public SautinSoft.PdfFocus.CWordOptions.eWordDocument DocFormat { set; get; }
    }
    public class PdfToWordService : IPdfToWordService
    {
        async Task<ResultMessage<ResultPdfToWordDto>> IPdfToWordService.ExecuteAsync(RequestPdfToWordDto request)
        {
            try
            {

                var PdfEncrypted = await AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
                if (PdfEncrypted.Success)
                {
                    return new ResultMessage<ResultPdfToWordDto> { Success = false, Message = PdfEncrypted.Message };
                }
                string OutPath = $"{request.OutputPath}\\{request.UserIp}";
                if (!Directory.Exists(OutPath))
                    Directory.CreateDirectory(OutPath);

                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMakerForPdfToDoc(GetPath.GetApiAddress(), ApiServices.PdfToDoc, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp, (int)request.DocFormat),true);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultPdfToWordDto>
                        {
                            Success = true,
                            Enything = new ResultPdfToWordDto
                            {
                                DocName = Response.OutFile,
                                DocPath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultPdfToWordDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultPdfToWordDto>
                {
                    Success = false,
                    Message = "Error on Converting Process",
                    Enything = null
                };
            }
        }
    }
}
