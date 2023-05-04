
using Domain.Entities.Logs;

namespace EndPoint.Models.DownloadPart
{
    public class DownloadFileViewModel
    {
        public string Id { set; get; }
        public string OutFileName { set; get; }
        public AllServicesLog LogService { set; get; }
    }
}
