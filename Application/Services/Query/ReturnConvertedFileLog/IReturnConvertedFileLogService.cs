using Application.Interface;
using Application.UseServices;
using Common;
using Domain.Entities.Features;
using System.Linq;

namespace Application.Services.Query.ReturnConvertedFileLog
{
    public interface IReturnConvertedFileLogService
    {
        ResultMessage<ResultReturnFeaturesFileLogDto> Execute(RequestReturnConvertedFileLogDto request);
    }
    public class RequestReturnConvertedFileLogDto
    {
        public string OutFileName { set; get; }
        public long Id { set; get; }
    }
    public class ReturnConvertedFileLogService : IReturnConvertedFileLogService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnConvertedFileLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnFeaturesFileLogDto> IReturnConvertedFileLogService.Execute(RequestReturnConvertedFileLogDto request)
        {
            //  can change: .find(id);
             var result = _Context.ConverterLogs.Where(p => p.IsRemoved == false && p.FileOutName==request.OutFileName && p.Id == request.Id).FirstOrDefault();
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
                         ShortLink=result.ShortLink,
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
