using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Query.ViewContext.ReturnHomeContext
{
    public interface IReturnHomeContextService
    {
        Task<ResultMessage<ResultReturnHomeContextDto>> ExecuteAsync();
    }
    public class ResultReturnHomeContextDto
    {
        public long Id { set; get; }
        public string TopTitleText { set; get; }
        public string MainServicesH2Text { set; get; }
        public string MainServicesPText { set; get; }
        public string ServicesInfoH1Text { set; get; }
        public string ServicesInfoPText { set; get; }

        public System.DateTime LastUpdate { set; get; }
    }
    public class ReturnHomeContextService : IReturnHomeContextService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnHomeContextService(IPdfConverterContext context)
        {
            _Context = context;
        }



        async Task<ResultMessage<ResultReturnHomeContextDto>> IReturnHomeContextService.ExecuteAsync()
        {
            try
            {
                var result = await _Context.HomePageContexts.FirstOrDefaultAsync();
                if (result != null)
                {
                    return new ResultMessage<ResultReturnHomeContextDto>
                    {
                        Success = true,
                        Enything = new ResultReturnHomeContextDto
                        {
                            MainServicesH2Text = result.MainServicesH2Text,
                            MainServicesPText = result.MainServicesPText,
                            ServicesInfoH1Text = result.ServicesInfoH1Text,
                            ServicesInfoPText = result.ServicesInfoPText,
                            TopTitleText = result.TopTitleText,
                            LastUpdate = result.LastUpdate,
                            Id = result.Id,
                        }
                    };
                }
                return new ResultMessage<ResultReturnHomeContextDto>
                {
                    Success = false,
                    Enything = new ResultReturnHomeContextDto
                    {
                        MainServicesH2Text = null,
                        MainServicesPText = null,
                        ServicesInfoH1Text = null,
                        ServicesInfoPText = null,
                        TopTitleText = null,
                        Id = 0,
                    },
                    Message = "No Context Found"
                };
            }
            catch
            {
                return new ResultMessage<ResultReturnHomeContextDto> { Success = false, Message = "No FataFound" };
            }
        }
    }
}
