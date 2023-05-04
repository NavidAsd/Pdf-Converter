using Common;
using Newtonsoft.Json;

namespace Application.Services.QRCode
{
    public interface IGenerateQrCodeService
    {
        ResultMessage<ResultGenerateQrCodeDto> CreateNewCode(RequestGenerateQrCodeDto request);
    }
    public class ResultGenerateQrCodeDto
    {
        public string QrImageName { set; get; }
        public string QrImagePath { set; get; }
    }
    public class RequestGenerateQrCodeDto
    {
        public string Url { set; get; }
        public string UserIp { set; get; }
        public string QrImagePath { set; get; }
    }

    public class GenerateQrCodeService : IGenerateQrCodeService
    {
        ResultMessage<ResultGenerateQrCodeDto> IGenerateQrCodeService.CreateNewCode(RequestGenerateQrCodeDto request)
        {
            try
            {
                string OutPath = $"{request.QrImagePath}\\{request.UserIp}";
                AppliedMethodes.CreateDirectory(OutPath);

                var Sender = AppliedMethodes.RequestSender(AppliedMethodes.UrlMakerForQrMaker(GetPath.GetApiAddress(),request.Url ,request.QrImagePath, request.UserIp), true);
                var Response = JsonConvert.DeserializeObject<ServiceResponseEntities>(Sender.Result.ResponseContent);
                if (Sender.Result.StatusCode == 200)
                    if (Response.Success)
                        return new ResultMessage<ResultGenerateQrCodeDto>
                        {
                            Success = true,
                            Enything = new ResultGenerateQrCodeDto
                            {
                                QrImageName = Response.OutFile,
                                QrImagePath = Response.OutPath
                            },
                            Message = Response.Message,
                        };
                return new ResultMessage<ResultGenerateQrCodeDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                    Enything = null
                };
            }
            catch
            {
                return new ResultMessage<ResultGenerateQrCodeDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again",
                    Enything = null
                };
            }
        }
    }
}
