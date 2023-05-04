using Domain.Entities.Commons;

namespace Domain.Entities.Details
{
    public class UserMessages:BaseEntity
    {
        public string Email { set; get; }
        public string Message { set; get; }
    }
}
