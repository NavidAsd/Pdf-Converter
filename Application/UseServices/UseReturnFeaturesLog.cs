using Application.Interface.FacadPattern;
using Common;
using Domain.Entities.Logs;

namespace Application.UseServices
{
    public class UseReturnFeaturesLog
    {
        public ResultMessage<ResultReturnFeaturesFileLogDto> ReturnSerivceLog (RequestReturnFeaturesFileLogDto request, IConvertLogFacad _Converter , IOptimizersLogFacad _Optimizers 
            , IOrganizersLogFacad _Organizers ,ISecurityLogFacad _Security, IOtherFeaturesLogService _OtherFeatures)
        {
            if(request.LogService == AllServicesLog.ConverterLog)
            {
                return _Converter.ReturnConvertedFileLogService.Execute(new Services.Query.ReturnConvertedFileLog.RequestReturnConvertedFileLogDto
                {
                    Id = request.Id,
                    OutFileName = request.OutFileName
                });
            }
            else if(request.LogService == AllServicesLog.OptimizersLog)
            {
                return _Optimizers.ReturnOptimizedFileLogService.Execute(new Services.Query.ReturnOptimizedFileLog.RequestReturnOptimizedFileLogDto
                {
                    Id = request.Id,
                    OutFileName = request.OutFileName
                });
            }
            else if (request.LogService == AllServicesLog.OrganizersLog)
            {
                return _Organizers.ReturnOrganizedFileLogService.Execute(new Services.Query.ReturnOrganizedFileLog.RequestReturnOrganizedFileLogDto
                {
                    Id = request.Id,
                    OutFileName = request.OutFileName
                });
            }
            else if(request.LogService == AllServicesLog.SecurityLog)
            {
                return _Security.ReturnSecurityFileLogService.Execute(new Services.Query.ReturnSecurityFileLog.RequestReturnSecurityFileLogDto
                {
                    Id = request.Id,
                    OutFileName = request.OutFileName
                });
            }
            else if (request.LogService == AllServicesLog.OtherFeaturesLog)
            {
                return _OtherFeatures.ReturnOtherFileLogService.Execute(new Services.Query.ReturnOtherFileLog.RequestReturnOtherFileLogDto
                {
                    Id = request.Id,
                    OutFileName = request.OutFileName,
                });
            }
            else
            {
                return new ResultMessage<ResultReturnFeaturesFileLogDto>
                {
                    Success = false,
                    Enything = null,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }

    }
    public class RequestReturnFeaturesFileLogDto
    {
        public string OutFileName { set; get; }
        public long Id { set; get; }
        public AllServicesLog LogService { set; get; }
    }

    public class ResultReturnFeaturesFileLogDto
    {
        public string OutFileName { set; get; }
        public string UserIp { set; get; }
        public string QrImage { set; get; }
        public string ShortLink { set; get; }
    }
}
