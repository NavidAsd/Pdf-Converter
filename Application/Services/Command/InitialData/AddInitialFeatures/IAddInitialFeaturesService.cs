using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Command.InitialData.AddInitialFeatures
{
    public interface IAddInitialFeaturesService
    {
        ResultMessage Execute();
    }
    public class AddInitialFeaturesService : IAddInitialFeaturesService
    {
        private readonly IPdfConverterContext _Context;
        public AddInitialFeaturesService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IAddInitialFeaturesService.Execute()
        {
            _Context.FeaturesDetails.RemoveRange(_Context.FeaturesDetails.ToList());
            _Context.SaveChanges();

            Common.InitialData data = new Common.InitialData();
            for (int i = 1; i <= 23; i++)
            {
                var Service = data.ReturnServiceName(i);
                if (Service != null)
                {
                    Domain.Entities.Details.FeaturesDetails features = new Domain.Entities.Details.FeaturesDetails
                    {
                        Name = Service,
                        Service = i,
                        IsRemoved = false,
                        InsertTime = System.DateTime.Now,
                        CountUse = 1
                    };
                    _Context.FeaturesDetails.Add(features);
                }
            }
            _Context.SaveChanges();
            return new ResultMessage { Success = true };
        }
    }
}
