using Common;
using Application.UseServices;
using Application.Interface;

namespace Application.Services.Command.UpdateShortLink.UpdateOptimizeLogShortLink
{
    public interface IUpdateOptimizeLogShortLinkService
    {
        ResultMessage Execute(RequestUpdateFileLogShortLinkDto request);
        ResultMessage UpdateQrImage(RequestUpdateQrImageDto request);
    }
    public class UpdateOptimizeLogShortLinkService : IUpdateOptimizeLogShortLinkService
    {
        private readonly IPdfConverterContext _Context;
        public UpdateOptimizeLogShortLinkService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IUpdateOptimizeLogShortLinkService.Execute(RequestUpdateFileLogShortLinkDto request)
        {
            var result = _Context.OptimizersLogs.Find(request.Id);
            if (result != null)
            {
                result.ShortLink = request.ShortLink;
                result.LastUpdate = System.DateTime.Now;
                _Context.SaveChanges();
                return new ResultMessage { Success = true, Message = "New Link Added" };
            }
            return new ResultMessage { Success = false, Message = "File Log Not Found" };
        }
        ResultMessage IUpdateOptimizeLogShortLinkService.UpdateQrImage(RequestUpdateQrImageDto request)
        {
            var result = _Context.OptimizersLogs.Find(request.Id);
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
