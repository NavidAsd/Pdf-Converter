
namespace EndPoint.Models
{
    public class NewUserMessageViewModel
    {
        public string UserEmail { set; get; }
        public string UserName { set; get; }
        public string Message { set; get; }
        public int? Rate { set; get; }
        public int Service { set; get; }
        public string Recaptcha { set; get; }
    }
}
