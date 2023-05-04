using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnPrivacyPolicy
{
    public interface IReturnPrivacyPolicyService
    {
        ResultMessage<ResultReturnPrivacyPolicyDto> Execute();
    }
    public class ResultReturnPrivacyPolicyDto
    {
        public long Id { set; get; }
        public string Text { set; get; }
        public System.DateTime? LastUpdate { set; get; }
    }
    public class ReturnPrivacyPolicyService : IReturnPrivacyPolicyService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnPrivacyPolicyService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnPrivacyPolicyDto> IReturnPrivacyPolicyService.Execute()
        {
            var result = _Context.PrivacyAndPolicies.FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnPrivacyPolicyDto>
                {
                    Success = true,
                    Enything = new ResultReturnPrivacyPolicyDto
                    {
                        Id = result.Id,
                        Text = result.Text,
                        LastUpdate = result.LastUpdate,
                    }
                };
            }
            return new ResultMessage<ResultReturnPrivacyPolicyDto>
            {
                Success = false,
                Enything = new ResultReturnPrivacyPolicyDto
                {
                    Text = null,
                    Id = 0,
                },
                Message = "Nothing Found"
            };
        }
    }

}
