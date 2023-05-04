using Common;
using Application.Interface;
using Application.UseServices;

namespace Application.Services.Command.UpdateShortLink.UpdateOtherFeaturesShortLink
{
    public interface IUpdateOtherFeaturesLogShortLinkService
    {
        ResultMessage Execute(RequestUpdateFileLogShortLinkDto request);
        ResultMessage UpdateQrImage(RequestUpdateQrImageDto request);
    }
    public class UpdateOtherFeaturesLogShortLinkService : IUpdateOtherFeaturesLogShortLinkService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateOtherFeaturesLogShortLinkService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateOtherFeaturesLogShortLinkService.Execute(RequestUpdateFileLogShortLinkDto request)
        {
            var result = _Context.OtherFeaturesLogs.Find(request.Id);
            if (result != null)
            {
                result.ShortLink = request.ShortLink;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Link Added" };
            }
            return new ResultMessage { Success = false, Message = "File Log Not Found" };
        }
        ResultMessage IUpdateOtherFeaturesLogShortLinkService.UpdateQrImage(RequestUpdateQrImageDto request)
        {
            var result = _Context.OtherFeaturesLogs.Find(request.Id);
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
