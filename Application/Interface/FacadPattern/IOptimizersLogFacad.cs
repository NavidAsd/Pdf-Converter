using Application.Services.Command.ServicesLog.AddNewOptimizeLog;
using Application.Services.Query.ReturnOptimizedFileLog;

namespace Application.Interface.FacadPattern
{
    public interface IOptimizersLogFacad
    {
        IReturnOptimizedFileLogService ReturnOptimizedFileLogService { get; }
        IAddNewOptimizeLogService AddNewOptimizeLogService { get; }
    }
}
