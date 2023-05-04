using Common;
using Application.Interface;
using Application.UseServices;

namespace Application.Services.Command.UpdateShortLink.UpdateSecurityLogShortLink
{
    public interface IUpdateSecurityLogShortLinkService
    {
        ResultMessage Execute(RequestUpdateFileLogShortLinkDto request);
        ResultMessage UpdateQrImage(RequestUpdateQrImageDto request);
    }
    public class UpdateSecurityLogShortLinkService : IUpdateSecurityLogShortLinkService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateSecurityLogShortLinkService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateSecurityLogShortLinkService.Execute(RequestUpdateFileLogShortLinkDto request)
        {
            var result = _Context.SecurityLogs.Find(request.Id);
            if (result != null)
            {
                result.ShortLink = request.ShortLink;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Link Added" };
            }
            return new ResultMessage { Success = false, Message = "File Log Not Found" };
        }
        ResultMessage IUpdateSecurityLogShortLinkService.UpdateQrImage(RequestUpdateQrImageDto request)
        {
            var result = _Context.SecurityLogs.Find(request.Id);
            if (result != null)
            {
                result.QRImage = request.QrImageName;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Qr Added" };
            }
            return new ResultMessage { Success = false, Message = "File Log Not Found" };
        }

    }
}
