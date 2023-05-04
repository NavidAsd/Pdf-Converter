using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Query.ViewContext.ReturnSocialNetworks
{
    public interface IReturnAllSocialNetworksService
    {
        ResultMessage<ResultReturnAllSocialNetworkDto> Execute();
    }
    public class ResultReturnAllSocialNetworkDto
    {
        public long Id { set; get; }
        public string VK { set; get; }
        public string Reddit { set; get; }
        public string Medium { set; get; }
        public string Okru { set; get; }
        public string Pinterest { set; get; }
        public string Tumblr { set; get; }
        public string Facebook { set; get; }
        public string Twitter { set; get; }
        public System.DateTime? LastUpdate { set; get; }
    }
    public class ReturnAllSocialNetworksService : IReturnAllSocialNetworksService
    {
        private readonly IPdfConverterContext _Context;
        public ReturnAllSocialNetworksService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultReturnAllSocialNetworkDto> IReturnAllSocialNetworksService.Execute()
        {
            var result = _Context.SocialNetworks.FirstOrDefault();
            if (result != null)
            {
                return new ResultMessage<ResultReturnAllSocialNetworkDto>
                {
                    Success = true,
                    Enything = new ResultReturnAllSocialNetworkDto
                    {
                        VK = result.VK,
                        Pinterest = result.Pinterest,
                        Reddit = result.Reddit,
                        Medium = result.Medium,
                        Okru = result.Okru,
                        Tumblr = result.Tumblr,
                        Facebook = result.Facebook,
                        Twitter = result.Twitter,
                        LastUpdate = result.LastUpdate,
                        Id = result.Id,
                    }
                };
            }
            return new ResultMessage<ResultReturnAllSocialNetworkDto>
            {
                Success = false,
                Enything = new ResultReturnAllSocialNetworkDto
                {
                    Medium = null,
                    Pinterest = null,
                    Okru = null,
                    Reddit = null,
                    Tumblr = null,
                    Facebook = null,
                    Twitter = null,
                    VK = null,
                    Id = 0,
                },
                Message = "No Social Account Found"
            };
        }
    }
}
