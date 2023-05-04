using Application.Interface;
using Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Application.Services.Query.ViewContext.ReturnAdditionalHelps
{
    public interface IReturnAdditionalHelpService
    {
        ResultMessage<List<Domain.Entities.OtherContext.AdditionalHelp>> ReturnAllForAdmin();
        ResultMessage<Domain.Entities.OtherContext.AdditionalHelp> ReturnWithId(long Id);
        ResultMessage<Domain.Entities.OtherContext.AdditionalHelp> ReturnWithServiceType(int Service);

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
        ResultMessage<Domain.Entities.OtherContext.AdditionalHelp> IReturnAdditionalHelpService.ReturnWithId(long Id)
        {
            var result = _Context.AdditionalHelps.Find(Id);
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
        ResultMessage<Domain.Entities.OtherContext.AdditionalHelp> IReturnAdditionalHelpService.ReturnWithServiceType(int Service)
        {
            var result = _Context.AdditionalHelps.Where(p => p.ServiceType == Service).FirstOrDefault();
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
