using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Command.InitialData.AddInitialThreeStepHelp
{
    public interface IAddInitialThreeStepHelpService
    {
        ResultMessage Execute();
    }
    public class AddInitialThreeStepHelpService : IAddInitialThreeStepHelpService
    {
        private readonly IPdfConverterContext _Context;
        public AddInitialThreeStepHelpService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IAddInitialThreeStepHelpService.Execute()
        {
            _Context.TreeHelpSteps.RemoveRange(_Context.TreeHelpSteps.ToList());
            _Context.SaveChanges();

            Common.InitialData data = new Common.InitialData(); 
            for (int i = 1; i <= 23; i++)
            {
                var Service = data.ReturnServiceName(i);
                if (Service != null)
                {
                    Domain.Entities.OtherContext.TreeHelpSteps features = new Domain.Entities.OtherContext.TreeHelpSteps
                    {
                        Service = Service,
                        InsertTime = System.DateTime.Now,
                        ServiceType = i,
                        IsRemoved = false,
                        LastUpdate = System.DateTime.Now,
                        Step1 = "Test Data For Step1",
                        Step2 = "Test Data For Step2",
                        Step3 = "Test Data For Step3",
                    };
                    _Context.TreeHelpSteps.Add(features);
                }
            }
            _Context.SaveChanges();
            return new ResultMessage { Success = true };
        }
    }
}
