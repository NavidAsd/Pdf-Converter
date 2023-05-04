using Application.Interface;
using Application.UseServices;
using Common;
using System.Linq;

namespace Application.Services.Query.ReturnOtherFileLog
{
    public interface IReturnOtherFileLogService
    {
        ResultMessage<ResultReturnFeaturesFileLogDto> Execute(RequestReturnOtherFileLogDto request);
        ResultMessage<ResultReturnFeaturesFileLogDto> ReturnWithLen(RequestReturnFileWithLenDto request);
    }
    public class RequestReturnOtherFileLogDto
    {
        public string OutFileName { set; get; }
        public long Id { set; get; }
    }
    public class RequestReturnFileWithLenDto
    {
        public long Id { set; get; }
        public string FileLength { set; get; }
    }
    public class ReturnOtherFileLogService : IReturnOtherFileLogService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnOtherFileLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnFeaturesFileLogDto> IReturnOtherFileLogService.Execute(RequestReturnOtherFileLogDto request)
        {
            var result = _Context.OtherFeaturesLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.OutFileName && p.Id == request.Id).FirstOrDefault();
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
        ResultMessage<ResultReturnFeaturesFileLogDto> IReturnOtherFileLogService.ReturnWithLen(RequestReturnFileWithLenDto request)
        {
            var result = _Context.OtherFeaturesLogs.Where(p => p.IsRemoved == false && p.FileInputSize == request.FileLength && p.Id == request.Id).FirstOrDefault();
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
