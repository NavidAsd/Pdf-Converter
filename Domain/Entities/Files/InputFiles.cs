using Domain.Entities.Commons;

namespace Domain.Entities.Files
{
    public class InputFiles : BaseEntity
    {
        public string FileName { set; get; }
        public string FIleSize { set; get; }
        public string UserIp { set; get; }
        public bool FileDeleted { set; get; }
    }
}
