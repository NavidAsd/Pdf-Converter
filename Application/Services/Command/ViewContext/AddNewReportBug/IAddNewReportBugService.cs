using Application.Interface;
using Common;
using System.Linq;

namespace Application.Services.Command.ViewContext.AddNewReportBug
{
    public interface IAddNewReportBugService
    {
        ResultMessage Execute(RequestAddNewReportBugDto request);
    }
    public class RequestAddNewReportBugDto
    {
        public string Email { set; get; }
        public string Url { set; get; }
        public string Description { set; get; }
    }
    public class AddNewReportBugService : IAddNewReportBugService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewReportBugService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IAddNewReportBugService.Execute(RequestAddNewReportBugDto request)
        {
            var ReportUnique = _Context.ReportBugs.Where(p => p.Url == request.Url && p.ProblemStatement == request.Description && p.Email == request.Email).FirstOrDefault();
            if(ReportUnique != null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "You have already submitted a report with this content"
                };
            }
            Domain.Entities.OtherContext.ReportBug report = new Domain.Entities.OtherContext.ReportBug
            {
                Email = request.Email,
                Url = request.Url,
                ProblemStatement = request.Description,
                IsRemoved = false,
                InsertTime = System.DateTime.Now
            };
            _Context.ReportBugs.Add(report);
            _Context.SaveChanges();
            return new ResultMessage
            {
                Success = true,
                Message = "Your report has been successfully submitted. We will definitely try to use it to improve performance"
            };
        }
    }
}
