using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Command.UpdateFeatureDetails
{
    public interface IUpdateFeatureDetailsService
    {
        ResultMessage UpdateAvgRate(RequestUpdateFeatureDetailsDto request);
        ResultMessage PlusCountUse(int ServiceType);
        ResultMessage UpdateImageFormat(RequestUpdateServiceImageDetailsDto request);
    }
    public class RequestUpdateServiceImageDetailsDto
    {
        public string ServiceName { set; get; }
        public string ImageFormat { set; get; }
        public string ImageAlt { set; get; }
        public string ImageTitle { set; get; }
    }
    public class RequestUpdateFeatureDetailsDto
    {
        public int ServiceType { set; get; }
        public double AvgRate { set; get; }
    }
    public class UpdateFeatureDetailsService : IUpdateFeatureDetailsService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateFeatureDetailsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateFeatureDetailsService.UpdateAvgRate(RequestUpdateFeatureDetailsDto request)
        {
            var service = _Context.FeaturesDetails.Where(p => p.IsRemoved == false && p.Service == request.ServiceType).FirstOrDefault();
            if (service != null)
            {
                service.Rate = request.AvgRate;
                _Context.SaveChanges();
                return new ResultMessage { Success = true };
            }
            return new ResultMessage { Success = false };
        }

        ResultMessage IUpdateFeatureDetailsService.PlusCountUse(int ServiceType)
        {
            var service = _Context.FeaturesDetails.Where(p => p.IsRemoved == false && p.Service == ServiceType).FirstOrDefault();
            if (service != null)
            {
                service.CountUse += 1;
                _Context.SaveChanges();
                return new ResultMessage { Success = true };
            }
            return new ResultMessage { Success = false };
        }
        ResultMessage IUpdateFeatureDetailsService.UpdateImageFormat(RequestUpdateServiceImageDetailsDto request)
        {
            var service = _Context.FeaturesDetails.Where(p => p.Name == request.ServiceName).FirstOrDefault();
            if (service != null)
            {
                service.ImageFormat = request.ImageFormat;
                service.ImageAlt = request.ImageAlt;
                service.ImageTitle = request.ImageTitle;
                _Context.SaveChanges();
                return new ResultMessage { Success = true };
            }
            return new ResultMessage { Success = false };
        }
    }
}
