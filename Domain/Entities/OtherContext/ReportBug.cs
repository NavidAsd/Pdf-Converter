using Domain.Entities.Commons;

namespace Domain.Entities.OtherContext
{
    public class ReportBug : BaseEntity
    {
        public string Email { set; get; }
        public string Url { set; get; } //Problem From Url
        public string ProblemStatement { set; get; }
    }
}
