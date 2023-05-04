using Domain.Entities.Commons;

namespace Domain.Entities.OtherContext
{
    public class TermsOfUse : BaseEntity
    {
        public string Text { set; get; }
        public string AboutUs { set; get; }
        public string Dmca { set; get; }
    }
}
