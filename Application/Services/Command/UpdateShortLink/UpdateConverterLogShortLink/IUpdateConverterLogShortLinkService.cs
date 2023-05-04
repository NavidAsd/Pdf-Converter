using Application.Interface;
using Application.UseServices;
using Common;

namespace Application.Services.Command.UpdateShortLink.UpdateConverterLogShortLink
{
    public interface IUpdateConverterLogShortLinkService
    {
        ResultMessage Execute(RequestUpdateFileLogShortLinkDto request);
        ResultMessage UpdateQrImage(RequestUpdateQrImageDto request);
    }
    public class UpdateConverterLogShortLinkService : IUpdateConverterLogShortLinkService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateConverterLogShortLinkService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateConverterLogShortLinkService.Execute(RequestUpdateFileLogShortLinkDto request)
        {
            var result = _Context.ConverterLogs.Find(request.Id);
            if (result != null)
            {
                result.ShortLink = request.ShortLink;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Link Added" };
            }
            return new ResultMessage { Success = false, Message = "File Log Not Found" };
        }
        ResultMessage IUpdateConverterLogShortLinkService.UpdateQrImage(Application.UseServices.RequestUpdateQrImageDto request)
        {
            var result = _Context.ConverterLogs.Find(request.Id);
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
