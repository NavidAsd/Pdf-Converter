using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Command.ServicesLog.AddNewOptimizeLog
{
    public interface IAddNewOptimizeLogService
    {
        ResultMessage<ResultAddNewOptimizeLogDto> Execute(RequestAddNewOptimizeLogDto request);
        ResultMessage<ResultAddNewOptimizeLogDto> AddLogList(RequesetAddRangeNewOptimizeLogDto request);
    }
    public class ResultAddNewOptimizeLogDto
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
    }
    public class RequestAddNewOptimizeLogDto
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileOutName { set; get; }
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
    }
    public class RequesetAddRangeNewOptimizeLogDto
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
    public class AddNewOptimizeLogService : IAddNewOptimizeLogService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewOptimizeLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultAddNewOptimizeLogDto> IAddNewOptimizeLogService.Execute(RequestAddNewOptimizeLogDto request)
        {
            Domain.Entities.Logs.OptimizersLog Optimizeer = new Domain.Entities.Logs.OptimizersLog()
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
                _Context.OptimizersLogs.Add(Optimizeer);
                _Context.SaveChanges();
                var result = _Context.OptimizersLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewOptimizeLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewOptimizeLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewOptimizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewOptimizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Optimizeing Proccess Pleas Try Again"
                };
            }
        }
        ResultMessage<ResultAddNewOptimizeLogDto> IAddNewOptimizeLogService.AddLogList(RequesetAddRangeNewOptimizeLogDto request)
        {
            List<Domain.Entities.Logs.OptimizersLog> Optimizeer = new List<Domain.Entities.Logs.OptimizersLog>();
            foreach (var item in request.OtherDatas)
            {
                Domain.Entities.Logs.OptimizersLog Optimize = new Domain.Entities.Logs.OptimizersLog
                {
                    FileInputName = item.FileInputName,
                    FileInputSize = item.FileInputSize,
                    FileOutName = request.FileOutName,
                    Type = request.Type,
                    InsertTime = System.DateTime.Now,
                    UserIp = request.UserIp,
                    IsRemoved = false,
                };
                Optimizeer.Add(Optimize);
            }
            try
            {
                _Context.OptimizersLogs.AddRange(Optimizeer);
                _Context.SaveChanges();
                var result = _Context.OptimizersLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewOptimizeLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewOptimizeLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewOptimizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Please Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewOptimizeLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In Optimizeing Proccess Pleas Try Again"
                };
            }
        }
    }
}
