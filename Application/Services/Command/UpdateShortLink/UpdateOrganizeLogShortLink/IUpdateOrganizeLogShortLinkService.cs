using Application.Interface;
using Application.UseServices;
using Common;
namespace Application.Services.Command.UpdateShortLink.UpdateOrganizeLogShortLink
{
    public interface IUpdateOrganizeLogShortLinkService
    {
        ResultMessage Execute(RequestUpdateFileLogShortLinkDto request);
        ResultMessage UpdateQrImage(RequestUpdateQrImageDto request);
    }
    public class UpdateOrganizeLogShortLinkService : IUpdateOrganizeLogShortLinkService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateOrganizeLogShortLinkService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateOrganizeLogShortLinkService.Execute(RequestUpdateFileLogShortLinkDto request)
        {
            var result = _Context.OrganizersLogs.Find(request.Id);
            if (result != null)
            {
                result.ShortLink = request.ShortLink;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Link Added" };
            }
            return new ResultMessage { Success = false, Message = "File Log Not Found" };
        }
        ResultMessage IUpdateOrganizeLogShortLinkService.UpdateQrImage(RequestUpdateQrImageDto request)
        {
            var result = _Context.OrganizersLogs.Find(request.Id);
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
