using Application.Interface;
using Common;
using System.Linq;
using Application.UseServices;

namespace Application.Services.Query.ReturnSecurityFileLog
{
    public interface IReturnSecurityFileLogService
    {
        ResultMessage<ResultReturnFeaturesFileLogDto> Execute(RequestReturnSecurityFileLogDto request);
    }
    public class RequestReturnSecurityFileLogDto
    {
        public string OutFileName { set; get; }
        public long Id { set; get; }
    }
    public class ReturnSecurityFileLogService : IReturnSecurityFileLogService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnSecurityFileLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnFeaturesFileLogDto> IReturnSecurityFileLogService.Execute(RequestReturnSecurityFileLogDto request)
        {
            var result = _Context.SecurityLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.OutFileName && p.Id == request.Id).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnFeaturesFileLogDto>
                {
                    Success = true,
                    Enything = new ResultReturnFeaturesFileLogDto
                    {
                        OutFileName = result.FileOutName,
                        UserIp = result.UserIp,
                        QrImage = result.QRImage,
                        ShortLink = result.ShortLink,
                    }
                };
            }
            return new ResultMessage<ResultReturnFeaturesFileLogDto>
            {
                Success = false,
                Message = "File Not Found!"
            };
        }
    }
}
