using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.ChangeServiceState
{
    public interface IChangeFeatureStateService
    {
        ResultMessage Execute(RequestChangeFeatureStateDto request);
    }
    public class RequestChangeFeatureStateDto
    {
        public int Service { set; get; }
        public bool State { set; get; }
    }
    public class ChangeFeatureStateService : IChangeFeatureStateService
    {
        private readonly IPdfConverterContext _Context;
        public ChangeFeatureStateService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IChangeFeatureStateService.Execute(RequestChangeFeatureStateDto request)
        {
            var result = _Context.FeaturesDetails.IgnoreQueryFilters().Where(p => p.Service == request.Service).FirstOrDefault();
            if (result != null)
            {
                if (result.IsRemoved == request.State)
                {
                    result.IsRemoved = !request.State;
                    if (!request.State)
                        result.RemoveTime = System.DateTime.Now;
                    _Context.SaveChanges();
                }
                return new ResultMessage { Success = true, Message = "Service State SuccssFully Changed" };
            }
            return new ResultMessage { Success = false, Message = "Service Not Found!" };
        }
    }
}
