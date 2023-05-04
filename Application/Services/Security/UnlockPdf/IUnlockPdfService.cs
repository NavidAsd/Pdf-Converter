using Common;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Application.Services.Security.UnlockPdf
{
    public interface IUnlockPdfService
    {
        Task<ResultMessage<ResultUnlockPdfDto>> ExecuteAsync(RequestUnlockPdfDto request);
    }
    public class ResultUnlockPdfDto
    {
        public string FileName { set; get; }
        public string FilePath { set; get; }
        public string ProcessTime { set; get; }
        public string Password { set; get; }
    }
    public class RequestUnlockPdfDto
    {
        public string InputFileName { set; get; }
        public string InputFilePath { set; get; }
        public string FilePWDName { set; get; }
        public string FilePWDPath { set; get; }
        public string UserIp { set; get; }
        public string OutputPath { set; get; }

    }
    public class UnlockPdfService : IUnlockPdfService
    {
        async Task<ResultMessage<ResultUnlockPdfDto>> IUnlockPdfService.ExecuteAsync(RequestUnlockPdfDto request)
        {
            var PdfEncrypted = AppliedMethodes.CheckPdfEncrypted($"{request.InputFilePath}\\{request.InputFileName}");
            if (!PdfEncrypted.Result.Success)
            {
                return new ResultMessage<ResultUnlockPdfDto> { Success = false, Message = "Uploaded file is not protected" };
            }
            try
            {
                var Sender =await AppliedMethodes.RequestSender(AppliedMethodes.UrlMaker(GetPath.GetApiAddress(), ApiServices.UnlockPdf, request.InputFilePath, request.InputFileName, request.OutputPath, request.UserIp),true);
                var Response = JsonConvert.DeserializeObject<UnlockPdfServiceResponseEntitires>(Sender.ResponseContent);
                if (Sender.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultUnlockPdfDto>
                        {
                            Success = true,
                            Message = Response.Message,
                            Enything = new ResultUnlockPdfDto
                            {
                                FileName = Response.OutFile,
                                FilePath = Response.OutPath,
                                ProcessTime = Response.ProcessTime,
                                Password = Response.Password
                            }
                        };
                return new ResultMessage<ResultUnlockPdfDto>
                {
                    Success = false,
                    Message = Response.Message,
                };
            }
            catch
            {
                return new ResultMessage<ResultUnlockPdfDto>
                {
                    Success = false,
                    Message = "Error on Process Please Try Again",
                };
            }
        }
    }
    public class ResultUnlockPdfForView
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
        public string ProcessTime { set; get; }
        public string PassFounded { set; get; }
    }
}
