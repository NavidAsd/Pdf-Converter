
using Microsoft.AspNetCore.Http;

namespace EndPoint.Areas.PdfManagerArea.Models
{
    public class CreateNewAdminViewModel
    {
        public string Email { set; get; }
        public string FullName { set; get; }
        public string Password { set; get; }
        public string RePassword { set; get; }
        public bool AddAdmin { set; get; }
        public bool RemoveAdmin { set; get; }

    }
}
