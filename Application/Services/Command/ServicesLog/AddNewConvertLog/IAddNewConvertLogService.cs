using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Command.ServicesLog.AddNewConvertLog
{
    public interface IAddNewConvertLogService
    {
        ResultMessage<ResultAddNewConvertLogDto> Execute(RequestAddNewConvertLogDto request);
        ResultMessage<ResultAddNewConvertLogDto> AddLogList(RequesetAddRangeNewConvertLogDto request);
    }
    public class ResultAddNewConvertLogDto
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
    }
    public class RequestAddNewConvertLogDto
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileOutName { set; get; }
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
    }
    public class RequesetAddRangeNewConvertLogDto
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileOutName { set; get; }
        public List<OtherData> OtherDatas { set; get; }
    }
    public class OtherData
    {
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
    }
    public class AddNewConverterLogService : IAddNewConvertLogService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewConverterLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultAddNewConvertLogDto> IAddNewConvertLogService.Execute(RequestAddNewConvertLogDto request)
        {
            Domain.Entities.Logs.ConverterLog converter = new Domain.Entities.Logs.ConverterLog()
            {
                FileInputName = request.FileInputName,
                FileInputSize = request.FileInputSize,
                FileOutName = request.FileOutName,
                Type = request.Type,
                InsertTime = System.DateTime.Now,
                UserIp = request.UserIp,
                IsRemoved = false,
                
            }; try
            {
                _Context.ConverterLogs.Add(converter);
                _Context.SaveChanges();
                var result = _Context.ConverterLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewConvertLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewConvertLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewConvertLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewConvertLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Converting Proccess Pleas Try Again"
                };
            }
        }
        ResultMessage<ResultAddNewConvertLogDto> IAddNewConvertLogService.AddLogList(RequesetAddRangeNewConvertLogDto request)
        {
            List<Domain.Entities.Logs.ConverterLog> converter = new List<Domain.Entities.Logs.ConverterLog>();
            foreach (var item in request.OtherDatas)
            {
                Domain.Entities.Logs.ConverterLog convert = new Domain.Entities.Logs.ConverterLog
                {
                    FileInputName = item.FileInputName,
                    FileInputSize = item.FileInputSize,
                    FileOutName = request.FileOutName,
                    Type = request.Type,
                    InsertTime = System.DateTime.Now,
                    UserIp = request.UserIp,
                    IsRemoved = false,
                };
                converter.Add(convert);
            }
            try
            {
                _Context.ConverterLogs.AddRange(converter);
                _Context.SaveChanges();
                var result = _Context.ConverterLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewConvertLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewConvertLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewConvertLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewConvertLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Converting Proccess Pleas Try Again"
                };
            }
        }
    }
}
