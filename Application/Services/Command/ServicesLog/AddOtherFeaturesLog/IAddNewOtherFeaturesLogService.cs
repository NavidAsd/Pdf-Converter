using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Command.ServicesLog.AddOtherFeaturesLog
{
    public interface IAddNewOtherFeaturesLogService
    {
        ResultMessage<ResultAddNewOtherFeaturesLogDto> Execute(RequestAddNewOtherFeaturesLogDto request);
        ResultMessage<ResultAddNewOtherFeaturesLogDto> AddLogList(RequesetAddRangeNewOtherFeaturesLogDto request);
    }
    public class ResultAddNewOtherFeaturesLogDto
    {
        public long Id { set; get; }
        public string OutFileName { set; get; }
    }
    public class RequestAddNewOtherFeaturesLogDto
    {
        public string UserIp { set; get; }
        public int Type { set; get; }
        public string FileOutName { set; get; }
        public string FileInputName { set; get; }
        public string FileInputSize { set; get; }
    }
    public class RequesetAddRangeNewOtherFeaturesLogDto
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
    public class AddNewOtherFeaturesLogService : IAddNewOtherFeaturesLogService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewOtherFeaturesLogService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultAddNewOtherFeaturesLogDto> IAddNewOtherFeaturesLogService.Execute(RequestAddNewOtherFeaturesLogDto request)
        {
            Domain.Entities.Logs.OtherFeaturesLog OtherFeatureser = new Domain.Entities.Logs.OtherFeaturesLog()
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
                _Context.OtherFeaturesLogs.Add(OtherFeatureser);
                _Context.SaveChanges();
                var result = _Context.OtherFeaturesLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewOtherFeaturesLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewOtherFeaturesLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewOtherFeaturesLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Pleas Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewOtherFeaturesLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In OtherFeaturesing Proccess Pleas Try Again"
                };
            }
        }
        ResultMessage<ResultAddNewOtherFeaturesLogDto> IAddNewOtherFeaturesLogService.AddLogList(RequesetAddRangeNewOtherFeaturesLogDto request)
        {
            List<Domain.Entities.Logs.OtherFeaturesLog> OtherFeatureser = new List<Domain.Entities.Logs.OtherFeaturesLog>();
            foreach (var item in request.OtherDatas)
            {
                Domain.Entities.Logs.OtherFeaturesLog OtherFeatures = new Domain.Entities.Logs.OtherFeaturesLog
                {
                    FileInputName = item.FileInputName,
                    FileInputSize = item.FileInputSize,
                    FileOutName = request.FileOutName,
                    Type = request.Type,
                    InsertTime = System.DateTime.Now,
                    UserIp = request.UserIp,
                    IsRemoved = false,
                };
                OtherFeatureser.Add(OtherFeatures);
            }
            try
            {
                _Context.OtherFeaturesLogs.AddRange(OtherFeatureser);
                _Context.SaveChanges();
                var result = _Context.OtherFeaturesLogs.Where(p => p.IsRemoved == false && p.FileOutName == request.FileOutName && p.UserIp == request.UserIp).FirstOrDefault();
                if (result != null)
                {
                    return new ResultMessage<ResultAddNewOtherFeaturesLogDto>
                    {
                        Success = true,
                        Enything = new ResultAddNewOtherFeaturesLogDto { Id = result.Id, OutFileName = result.FileOutName }
                    };
                }
                return new ResultMessage<ResultAddNewOtherFeaturesLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Please Try Again"
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewOtherFeaturesLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Error In OtherFeaturesing Proccess Pleas Try Again"
                };
            }
        }
    }
}
