using Domain.Entities.Commons;

namespace Domain.Entities.OtherContext
{
    public class FrequentlyQuestions : BaseEntity
    {
        public string Title { set; get; }
        public string Question { set; get; }
        public string Answer { set; get; }
        public long? Service { set; get; }
    }
}
