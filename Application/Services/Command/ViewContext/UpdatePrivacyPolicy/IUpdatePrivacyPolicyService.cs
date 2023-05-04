using Application.Interface;
using Common;

namespace Application.Services.Command.ViewContext.UpdatePrivacyPolicy
{
    public interface IUpdatePrivacyPolicyService
    {
        ResultMessage Execute(RequestUpdatePrivacyPolicyDto request);
    }
    public class RequestUpdatePrivacyPolicyDto
    {
        public long Id { set; get; }
        public string Text { set; get; }
    }
    public class UpdatePrivacyPolicyService : IUpdatePrivacyPolicyService
    {
        private readonly IPdfConverterContext _Context;
        public UpdatePrivacyPolicyService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdatePrivacyPolicyService.Execute(RequestUpdatePrivacyPolicyDto request)
        {
            try
            {
                var result = _Context.PrivacyAndPolicies.Find(request.Id);
                if (result != null)
                {
                    result.Text = request.Text;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Context SuccessFully Updated"
                    };
                }
                Domain.Entities.OtherContext.PrivacyAndPolicy footerContext = new Domain.Entities.OtherContext.PrivacyAndPolicy
                {
                    Text = request.Text,
                    IsRemoved = false,
                    InsertTime = System.DateTime.Now,
                };
                _Context.PrivacyAndPolicies.Add(footerContext);
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Context SuccessFully Updated"
                };
            }
            catch
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Something Worng Please Try Again"
                };
            }
        }
    }
}
