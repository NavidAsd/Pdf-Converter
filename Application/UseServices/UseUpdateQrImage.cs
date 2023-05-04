using Application.Interface.FacadPattern;
using Common;
using Domain.Entities.Logs;

namespace Application.UseServices
{
    public class UseUpdateQrImage
    {
        public ResultMessage Use(RequestUpdateQrImageDto request, IFeaturesDetailsFacad _FeatureDetails)
        {
            if (request.LogService == AllServicesLog.ConverterLog)
            {
                return _FeatureDetails.UpdateConverterLogShortLinkService.UpdateQrImage(new RequestUpdateQrImageDto
                {
                    Id = request.Id,
                    QrImageName = request.QrImageName
                });
            }
            else if (request.LogService == AllServicesLog.OptimizersLog)
            {
                return _FeatureDetails.UpdateOptimizeLogShortLinkService.UpdateQrImage(new RequestUpdateQrImageDto
                {
                    Id = request.Id,
                    QrImageName = request.QrImageName
                });
            }
            else if (request.LogService == AllServicesLog.OrganizersLog)
            {
                return _FeatureDetails.UpdateOrganizeLogShortLinkService.UpdateQrImage(new RequestUpdateQrImageDto
                {
                    Id = request.Id,
                    QrImageName = request.QrImageName
                });
            }
            else if (request.LogService == AllServicesLog.SecurityLog)
            {
                return _FeatureDetails.UpdateSecurityLogShortLinkService.UpdateQrImage(new RequestUpdateQrImageDto
                {
                    Id = request.Id,
                    QrImageName = request.QrImageName
                });
            }
            else if (request.LogService == AllServicesLog.OtherFeaturesLog)
            {
                return _FeatureDetails.UpdateOtherFeaturesLogShortLinkService.UpdateQrImage(new RequestUpdateQrImageDto
                {
                    Id = request.Id,
                    QrImageName = request.QrImageName
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
    public class RequestUpdateQrImageDto
    {
        public long Id { set; get; }
        public string QrImageName { set; get; }
        public AllServicesLog LogService { set; get; }
    }

}
