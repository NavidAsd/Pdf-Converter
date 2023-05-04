using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Query.GetAllFeaturesDetails
{
    public interface IGetAllFeaturesDetailsService
    {
        ResultMessage<ResultGetAllFeaturesDetailsDto> Execute(string Filter);
    }
    public class ResultGetAllFeaturesDetailsDto
    {
        public List<Domain.Entities.Details.FeaturesDetails> Features { set; get; }
        public string Filter { set; get; }
    }
    public class GetAllFeaturesDetailsService : IGetAllFeaturesDetailsService
    {
        private readonly IPdfConverterContext _Context;
        public GetAllFeaturesDetailsService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultGetAllFeaturesDetailsDto> IGetAllFeaturesDetailsService.Execute(string Filter)
        {

            var result = _Context.FeaturesDetails.IgnoreQueryFilters().Select(o => new Domain.Entities.Details.FeaturesDetails
            {
                Service = o.Service,
                Description = o.Description,
                CountUse = o.CountUse,
                HelpContext = o.HelpContext,
                Rate = o.Rate,
                Name = o.Name,
                IsRemoved = o.IsRemoved,
                ImageFormat = o.ImageFormat,
                ImageTitle = o.ImageTitle,
                ImageAlt = o.ImageAlt,
            }).ToList();
            if (!string.IsNullOrWhiteSpace(Filter))
                result = result.Where(p => p.Name.ToLower().Contains(Filter.ToLower())).ToList();
            if (result.Count > 0)
            {
                return new ResultMessage<ResultGetAllFeaturesDetailsDto>
                {
                    Success = true,
                    Enything = new ResultGetAllFeaturesDetailsDto
                    {
                        Features = result,
                        Filter = Filter
                    }
                };
            }
            return new ResultMessage<ResultGetAllFeaturesDetailsDto>
            {
                Success = false,
                Message = "No Service Found!",
                Enything = new ResultGetAllFeaturesDetailsDto
                {
                    Features = null,
                    Filter = Filter
                }
            };
        }
    }
}
