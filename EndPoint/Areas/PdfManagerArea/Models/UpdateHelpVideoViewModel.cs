
using Microsoft.AspNetCore.Http;

namespace EndPoint.Areas.PdfManagerArea.Models
{
    public class UpdateHelpVideoViewModel
    {
        public IFormFile File { set; get; }
        public long Id { set; get; }

    }
}
