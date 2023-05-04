using Application.Interface.FacadPattern;
using Common;
using Domain.Entities.Logs;

namespace Application.UseServices
{
    public class UseUpdateShortLink
    {
        public ResultMessage Use(RequestUpdateFileLogShortLinkDto request, IFeaturesDetailsFacad _FeatureDetails)
        {
            if (request.LogService == AllServicesLog.ConverterLog)
            {
                return _FeatureDetails.UpdateConverterLogShortLinkService.Execute(new RequestUpdateFileLogShortLinkDto
                {
                    Id = request.Id,
                    ShortLink = request.ShortLink
                });
            }
            else if (request.LogService == AllServicesLog.OptimizersLog)
            {
                return _FeatureDetails.UpdateOptimizeLogShortLinkService.Execute(new RequestUpdateFileLogShortLinkDto
                {
                    Id = request.Id,
                    ShortLink = request.ShortLink
                });
            }
            else if (request.LogService == AllServicesLog.OrganizersLog)
            {
                return _FeatureDetails.UpdateOrganizeLogShortLinkService.Execute(new RequestUpdateFileLogShortLinkDto
                {
                    Id = request.Id,
                    ShortLink = request.ShortLink
                });
            }
            else if (request.LogService == AllServicesLog.SecurityLog)
            {
                return _FeatureDetails.UpdateSecurityLogShortLinkService.Execute(new RequestUpdateFileLogShortLinkDto
                {
                    Id = request.Id,
                    ShortLink = request.ShortLink
                });
            }
            else if (request.LogService == AllServicesLog.OtherFeaturesLog)
            {
                return _FeatureDetails.UpdateOtherFeaturesLogShortLinkService.Execute(new RequestUpdateFileLogShortLinkDto
                {
                    Id = request.Id,
                    ShortLink = request.ShortLink
                });
            }
            else
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }
    }
    public class RequestUpdateFileLogShortLinkDto
    {
        public long Id { set; get; }
        public string ShortLink { set; get; }
        public AllServicesLog LogService { set; get; }
    }

}
