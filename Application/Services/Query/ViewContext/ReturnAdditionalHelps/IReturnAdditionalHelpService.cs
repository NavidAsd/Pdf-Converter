using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Services.Query.ViewContext.ReturnAdditionalHelps
{
    public interface IReturnAdditionalHelpService
    {
        ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>> ReturnAllForAdmin();
        Task<ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>> ReturnWithIdAsync(long Id);
        Task<ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>> ReturnWithServiceTypeAsync(int Service);

    }
    public class ReturnAdditionalHelpService : IReturnAdditionalHelpService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnAdditionalHelpService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>> IReturnAdditionalHelpService.ReturnAllForAdmin()
        {
            var result = _Context.AdditionalHelps.Select(p => new Domain.Entities.OtherContext.AdditionalHelp
            {
                BlockTitlecenter = p.BlockTitlecenter,
                BlockTitleleft = p.BlockTitleleft,
                BlockTitleright = p.BlockTitleright,
                Textcenter = p.Textcenter,
                Textleft = p.Textleft,
                Textright = p.Textleft,
                ServiceDescription = p.ServiceDescription,
                HelpContext = p.HelpContext,
                InsertTime = p.InsertTime,
                IsRemoved = p.IsRemoved,
                LastUpdate = p.LastUpdate,
                Service = p.Service,
                ServiceType = p.ServiceType,
                Title = p.Title,
                RemoveTime = p.RemoveTime,
                Id=p.Id,
                
            }).ToList();
            if (result.Count > 0)
            {
                return new ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>>
                {
                    Success = true,
                    Enything = result,
                };
            }
            return new ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>>
            {
                Success = false,
                Message = "No Item Found"
            };
        }
        async Task<ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>> IReturnAdditionalHelpService.ReturnWithIdAsync(long Id)
        {
            var result = await _Context.AdditionalHelps.FindAsync(Id);
            if(result != null)
            {
                return new ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>
                {
                    Success = true,
                    Enything = result
                };
            }
            return new ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>
            {
                Success = false,
                Enything = null,
                Message = "Item Not Found"
            };
        }
        async Task<ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>> IReturnAdditionalHelpService.ReturnWithServiceTypeAsync(int Service)
        {
            var result = await _Context.AdditionalHelps.Where(p => p.ServiceType == Service).FirstOrDefaultAsync();
            if(result != null)
            {
                return new ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>
                {
                    Success = true,
                    Enything = result
                };
            }
            return new ResultMessage<Domain.Entities.OtherContext.AdditionalHelp>
            {
                Success = false,
                Enything = null,
                Message = "Item Not Found"
            };
        }
    }
}
