using Application.Interface;
using Common;
namespace Application.Services.Command.ViewContext.UpdateSocialNetworks
{
    public interface IUpdateSocialNetworksService
    {
        ResultMessage Execute(RequestUpdateSocialNetworksDto request);
    }
    public class RequestUpdateSocialNetworksDto
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
    }
    public class UpdateSocialNetworksService : IUpdateSocialNetworksService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateSocialNetworksService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateSocialNetworksService.Execute(RequestUpdateSocialNetworksDto request)
        {
            try
            {
                var result = _Context.SocialNetworks.Find(request.Id);
                if (result != null)
                {
                    result.Reddit = request.Reddit;
                    result.Medium = request.Medium;
                    result.Pinterest = request.Pinterest;
                    result.VK = request.VK;
                    result.Tumblr = request.Tumblr;
                    result.Okru = request.Okru;
                    result.Facebook = request.Facebook;
                    result.Twitter = request.Twitter;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                    return new ResultMessage
                    {
                        Success = true,
                        Message = "Accounts SuccesFully Updeted"
                    };
                }
                Domain.Entities.OtherContext.SocialNetworks socialAccounts = new Domain.Entities.OtherContext.SocialNetworks
                {
                    Reddit = request.Reddit,
                    Medium = request.Medium,
                    Pinterest = request.Pinterest,
                    VK = request.VK,
                    Tumblr = request.Tumblr,
                    Okru = request.Okru,
                    Facebook = request.Facebook,
                    Twitter = request.Twitter,

                    InsertTime = System.DateTime.Now,
                    LastUpdate = System.DateTime.Now,
                    IsRemoved = false,
                };
                _Context.SocialNetworks.Add(socialAccounts);
                _Context.SaveChanges();
                return new ResultMessage
                {
                    Success = true,
                    Message = "Accounts SuccesFully Updeted"
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
