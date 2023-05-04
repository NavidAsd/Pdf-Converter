using Application.Interface;
using Common;
namespace Application.Services.Command.ViewContext.UpdateTreeStepHelp
{
    public interface IUpdateTreeStepHelpService
    {
        ResultMessage Execute(RequestUpdateTreeStepHelpDto request);
    }
    public class RequestUpdateTreeStepHelpDto
    {
        public long Id { set; get; }
        public string Step1 { set; get; }
        public string Step2 { set; get; }
        public string Step3 { set; get; }
    }
    public class UpdateTreeStepHelpService : IUpdateTreeStepHelpService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateTreeStepHelpService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateTreeStepHelpService.Execute(RequestUpdateTreeStepHelpDto request)
        {
            var result = _Context.TreeHelpSteps.Find(request.Id);
            if(result != null)
            {
                result.Step1 = request.Step1;
                result.Step2 = request.Step2;
                result.Step3 = request.Step3;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Context SuccessFully Updated"
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message = "Context Not Found"
            };
        }
    }
}
