using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnTotalUseAvg
{
    public interface IReturnTotalUseAvgService
    {
        ResultMessage<ResultReturnTotalUseAvgDto> Execute();
    }
    public class ResultReturnTotalUseAvgDto
    {
        public long Total { set; get; }
    }
    public class ReturnTotalUseAvgService : IReturnTotalUseAvgService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnTotalUseAvgService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnTotalUseAvgDto> IReturnTotalUseAvgService.Execute()
        {
            var Features = _Context.FeaturesDetails.Sum(s=>s.CountUse);
            /*long sum = 0;
            foreach (var item in Features)
            {
                sum += item.CountUse;
            }*/
            if (Features > 0 )
            {
                return new ResultMessage<ResultReturnTotalUseAvgDto>
                {
                    Success = true,
                    Enything = new ResultReturnTotalUseAvgDto
                    {
                        Total = Features,
                    }
                };
            }
            return new ResultMessage<ResultReturnTotalUseAvgDto>
            {
                Success = false,
                Message = "No Item Found"
            };
        }
    }
}
