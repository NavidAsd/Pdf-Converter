using Application.Interface;
using Application.UseServices;
using Common;
using System.Linq;

namespace Application.Services.Query.ReturnOptimizedFileLog
{
    public interface IReturnOptimizedFileLogService
    {
        ResultMessage<ResultReturnFeaturesFileLogDto> Execute(RequestReturnOptimizedFileLogDto request);
    }
    public class RequestReturnOptimizedFileLogDto
    {
        public string OutFileName { set; get; }
        public long Id { set; get; }
    }
    public class ReturnOptimizedFileLogService : IReturnOptimizedFileLogService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnOptimizedFileLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnFeaturesFileLogDto> IReturnOptimizedFileLogService.Execute(RequestReturnOptimizedFileLogDto request)
        {
            var result = _Context.OptimizersLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.OutFileName && p.Id == request.Id).FirstOrDefault();
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
