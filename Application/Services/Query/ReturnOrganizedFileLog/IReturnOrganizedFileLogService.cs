using Application.Interface;
using Application.UseServices;
using Common;
using System.Linq;

namespace Application.Services.Query.ReturnOrganizedFileLog
{
    public interface IReturnOrganizedFileLogService
    {
        ResultMessage<ResultReturnFeaturesFileLogDto> Execute(RequestReturnOrganizedFileLogDto request);
    }
    public class RequestReturnOrganizedFileLogDto
    {
        public string OutFileName { set; get; }
        public long Id { set; get; }
    }
    public class ReturnOrganizedFileLogService : IReturnOrganizedFileLogService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnOrganizedFileLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnFeaturesFileLogDto> IReturnOrganizedFileLogService.Execute(RequestReturnOrganizedFileLogDto request)
        {
            var result = _Context.OrganizersLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.OutFileName && p.Id == request.Id).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnFeaturesFileLogDto>
                {
                    Success = true,
                    Enything = new ResultReturnFeaturesFileLogDto
                    {
                        OutFileName = result.FileOutName,
                        UserIp = result.UserIp,
                        QrImage=result.QRImage,
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
