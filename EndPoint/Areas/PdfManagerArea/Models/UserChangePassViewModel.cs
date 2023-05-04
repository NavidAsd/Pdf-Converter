
namespace EndPoint.Areas.PdfManagerArea.Models
{
    public class UserChangePassViewModel
    {
        public string NewPass { set; get; }
        public string RepPass { set; get; }

    }
    public class UserChangeOldPassViewModel
    {
        public string OldPassword { set; get; }
        public string NewPassword { set; get; }
        public string RepPassword { set; get; }
    }
}
