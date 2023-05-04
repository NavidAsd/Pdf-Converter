using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Command.ServicesLog.AddNewOrganizeLog
{
    public interface IAddNewOrganizeLogService
    {
        ResultMessage<ResultAddNewOrganizeLogDto> Execute(RequestAddNewOrganizeLogDto request);
        ResultMessage<ResultAddNewOrganizeLogDto> AddLogList(RequesetAddRangeNewOrganizeLogDto request);
    }
    public class ResultAddNewOrganizeLogDto
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
    }
    public class RequestAddNewOrganizeLogDto
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileOutName { set; get; }
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
    }
    public class RequesetAddRangeNewOrganizeLogDto
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
    public class AddNewOrganizeLogService : IAddNewOrganizeLogService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewOrganizeLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultAddNewOrganizeLogDto> IAddNewOrganizeLogService.Execute(RequestAddNewOrganizeLogDto request)
        {
            Domain.Entities.Logs.OrganizersLog Organizeer = new Domain.Entities.Logs.OrganizersLog()
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
                _Context.OrganizersLogs.Add(Organizeer);
                _Context.SaveChanges();
                var result = _Context.OrganizersLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewOrganizeLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewOrganizeLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewOrganizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewOrganizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Organizeing Proccess Pleas Try Again"
                };
            }
        }
        ResultMessage<ResultAddNewOrganizeLogDto> IAddNewOrganizeLogService.AddLogList(RequesetAddRangeNewOrganizeLogDto request)
        {
            List<Domain.Entities.Logs.OrganizersLog> Organizeer = new List<Domain.Entities.Logs.OrganizersLog>();
            foreach (var item in request.OtherDatas)
            {
                Domain.Entities.Logs.OrganizersLog Organize = new Domain.Entities.Logs.OrganizersLog
                {
                    FileInputName = item.FileInputName,
                    FileInputSize = item.FileInputSize,
                    FileOutName = request.FileOutName,
                    Type = request.Type,
                    InsertTime = System.DateTime.Now,
                    UserIp = request.UserIp,
                    IsRemoved = false,
                };
                Organizeer.Add(Organize);
            }
            try
            {
                _Context.OrganizersLogs.AddRange(Organizeer);
                _Context.SaveChanges();
                var result = _Context.OrganizersLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewOrganizeLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewOrganizeLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewOrganizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Please Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewOrganizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Organizeing Proccess Pleas Try Again"
                };
            }
        }
    }
}
