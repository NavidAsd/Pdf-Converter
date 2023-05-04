
using Microsoft.AspNetCore.Http;

namespace EndPoint.Models
{
    public class UploadFileViewModel
    {
        public IFormFile file { set; get; }
        public int Service { set; get; }
        public int Type { set; get; }
        public string Recaptcha { set; get; }
    }
    public class UploadSecurityFileViewModel
    {
        public IFormFile file { set; get; }
        public int Service { set; get; }
        public string Recaptcha { set; get; }
        public string Password { set; get; }
        public string RePassword { set; get; }
    }
    public class DeletePdfPagesViewModel
    {
        public int[] Pages { set; get; }
        public string Recaptcha { set; get; }
        public long _Id { set; get; }
    }
}
