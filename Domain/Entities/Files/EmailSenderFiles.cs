
using Domain.Entities.Commons;

namespace Domain.Entities.Files
{
    public class EmailSenderFiles : BaseEntity
    {
        public string UserEmail { set; get; }
        public string FileName { set; get; }
        public int TryToSend { set; get; }
        public string UserIp { set; get; }
    }
}
