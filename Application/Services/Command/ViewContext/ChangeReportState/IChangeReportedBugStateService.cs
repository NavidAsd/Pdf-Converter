using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.ViewContext.ChangeReportState
{
    public interface IChangeReportedBugStateService
    {
        ResultMessage Execute(long Id, bool State);
    }
    public class ChangeReportedBugStateService: IChangeReportedBugStateService
    {
        private readonly IPdfConverterContext _Context;
        public ChangeReportedBugStateService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IChangeReportedBugStateService.Execute(long Id, bool State)
        {
            var result = _Context.ReportBugs.IgnoreQueryFilters().Where(p => p.Id == Id).FirstOrDefault();
            if(result != null)
            {
                if(result.IsRemoved != State)
                {
                    result.IsRemoved = State;
                    result.LastUpdate = System.DateTime.Now;
                    _Context.SaveChanges();
                }
                return new ResultMessage
                {
                    Success = true
                };
            }
            return new ResultMessage
            {
                Success = false,
                Message="Something Wrong Please Try Again"
            };
        }
    }
}
