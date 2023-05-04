using Domain.Entities.Commons;

namespace Domain.Entities.Details
{
    public class UserComments : BaseEntity
    {
        public string UserEmail { set; get; }
        public string UserName { set; get; }
        public string Message { set; get; }
        public int? Rate { set; get; }
        public int Service { set; get; }
        public bool Accepted { set; get; } = false;
    }
}
