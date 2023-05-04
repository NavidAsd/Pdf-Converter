using Domain.Entities.Commons;

namespace Domain.Entities.Seo
{
    public class Keywords:BaseEntity
    {
        public long MetaId { set; get; }
        public string Key { set; get; }
    }
}
