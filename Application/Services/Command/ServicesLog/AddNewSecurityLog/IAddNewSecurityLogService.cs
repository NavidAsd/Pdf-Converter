using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Command.ServicesLog.AddNewSecurityLog
{
    public interface IAddNewSecurityLogService
    {
        ResultMessage<ResultAddNewSecurityLogDto> Execute(RequestAddNewSecurityLogDto request);
        ResultMessage<ResultAddNewSecurityLogDto> AddLogList(RequesetAddRangeNewSecurityLogDto request);
    }
    public class ResultAddNewSecurityLogDto
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
    }
    public class RequestAddNewSecurityLogDto
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileOutName { set; get; }
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
    }
    public class RequesetAddRangeNewSecurityLogDto
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
    public class AddNewSecurityLogService : IAddNewSecurityLogService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewSecurityLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultAddNewSecurityLogDto> IAddNewSecurityLogService.Execute(RequestAddNewSecurityLogDto request)
        {
            Domain.Entities.Logs.SecurityLog Securityer = new Domain.Entities.Logs.SecurityLog()
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
                _Context.SecurityLogs.Add(Securityer);
                _Context.SaveChanges();
                var result = _Context.SecurityLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewSecurityLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewSecurityLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewSecurityLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewSecurityLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Securitying Proccess Pleas Try Again"
                };
            }
        }
        ResultMessage<ResultAddNewSecurityLogDto> IAddNewSecurityLogService.AddLogList(RequesetAddRangeNewSecurityLogDto request)
        {
            List<Domain.Entities.Logs.SecurityLog> Securityer = new List<Domain.Entities.Logs.SecurityLog>();
            foreach (var item in request.OtherDatas)
            {
                Domain.Entities.Logs.SecurityLog Security = new Domain.Entities.Logs.SecurityLog
                {
                    FileInputName = item.FileInputName,
                    FileInputSize = item.FileInputSize,
                    FileOutName = request.FileOutName,
                    Type = request.Type,
                    InsertTime = System.DateTime.Now,
                    UserIp = request.UserIp,
                    IsRemoved = false,
                };
                Securityer.Add(Security);
            }
            try
            {
                _Context.SecurityLogs.AddRange(Securityer);
                _Context.SaveChanges();
                var result = _Context.SecurityLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewSecurityLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewSecurityLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewSecurityLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewSecurityLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Securitying Proccess Pleas Try Again"
                };
            }
        }
    }

}
