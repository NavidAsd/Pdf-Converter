using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.EditServiceDetails
{
    public interface IEditFeatureDetailsService
    {
        ResultMessage<ResultEditFeatureDetailsDto> Execute(RequestEditFeatureDetailsDto request);
    }
    public class ResultEditFeatureDetailsDto
    {
        public int Service { set; get; }
    }
    public class RequestEditFeatureDetailsDto
    {
        public int Service { set; get; }
        public string HelpContext { set; get; }
        public string Description { set; get; }
        public string FirstParagraph { set; get; }
        public string SecendParagraph { set; get; }

    }
    public class EditFeatureDetailsService : IEditFeatureDetailsService
    {
        private readonly IPdfConverterContext _Context;
        public EditFeatureDetailsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultEditFeatureDetailsDto> IEditFeatureDetailsService.Execute(RequestEditFeatureDetailsDto request)
        {
            var result = _Context.FeaturesDetails.IgnoreQueryFilters().Where(p => p.Service == request.Service).FirstOrDefault();
            if (result != null)
            {
                result.HelpContext = request.HelpContext;
                result.Description = request.Description;
                result.Paragraph1 = request.FirstParagraph;
                result.Paragraph2 = request.SecendParagraph;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage<ResultEditFeatureDetailsDto>
                {
                    Success = true,
                    Message="Item Successfully Edited",
                    Enything = new ResultEditFeatureDetailsDto { Service = request.Service }
                };
            }
            return new ResultMessage<ResultEditFeatureDetailsDto>
            {
                Success = false,
                Enything = null,
                Message = "Service Not Found!"
            };
        }
    }
}
