using Application.Interface;
using Common;
using Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Query.ReturnFeatureDetails
{
    public interface IReturnFeatureDetailsService
    {
        Task<ResultMessage<ResultReturnFeatureDetailsDto>> ExecuteAsync(RequestReturnFeatureDetailsDto request);
        ResultMessage<ResultReturnFeatureDetailsDto> ReturnForAdmin(RequestReturnFeatureDetailsDto request);
    }
    public class ResultReturnFeatureDetailsDto
    {
        public int Service { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string HelpContext { set; get; }
        public double Rate { set; get; }
        public long CountUse { set; get; }
        public string FirstParagraph { set; get; }
        public string SecendParagraph { set; get; }


    }
    public class RequestReturnFeatureDetailsDto
    {
        public int ServiceType { set; get; }
    }
    public class ReturnFeatureDetailsService : IReturnFeatureDetailsService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnFeatureDetailsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        async Task<ResultMessage<ResultReturnFeatureDetailsDto>> IReturnFeatureDetailsService.ExecuteAsync(RequestReturnFeatureDetailsDto request)
        {
            var result = await _Context.FeaturesDetails.Where(p => p.IsRemoved == false && p.Service == request.ServiceType).FirstOrDefaultAsync();
            if (result != null)
            {
                return new ResultMessage<ResultReturnFeatureDetailsDto>
                {
                    Success = true,
                    Enything = new ResultReturnFeatureDetailsDto
                    {
                        Service = result.Service,
                        Name = result.Name,
                        CountUse = result.CountUse,
                        Description = result.Description,
                        HelpContext = result.HelpContext,
                        Rate = result.Rate,
                        FirstParagraph = result.Paragraph1,
                        SecendParagraph = result.Paragraph2
                    }
                };
            }

            return new ResultMessage<ResultReturnFeatureDetailsDto>
            {
                Success = false,
                Enything = null,
                Message = "This service is obsolete or disabled"
            };

        }

        ResultMessage<ResultReturnFeatureDetailsDto> IReturnFeatureDetailsService.ReturnForAdmin(RequestReturnFeatureDetailsDto request)
        {
            var result = _Context.FeaturesDetails.IgnoreQueryFilters().Where(p => p.Service == request.ServiceType).FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnFeatureDetailsDto>
                {
                    Success = true,
                    Enything = new ResultReturnFeatureDetailsDto
                    {
                        Service = result.Service,
                        Name = result.Name,
                        CountUse = result.CountUse,
                        Description = result.Description,
                        HelpContext = result.HelpContext,
                        Rate = result.Rate,
                        FirstParagraph= result.Paragraph1,
                        SecendParagraph= result.Paragraph2,
                    }
                };
            }

            return new ResultMessage<ResultReturnFeatureDetailsDto>
            {
                Success = false,
                Enything = null,
                Message = "This service is obsolete or disabled"
            };

        }
    }
}
