using Application.Services.Command.ServicesLog.AddNewSecurityLog;
using Application.Services.Query.ReturnSecurityFileLog;

namespace Application.Interface.FacadPattern
{
    public interface ISecurityLogFacad
    {
        IReturnSecurityFileLogService  ReturnSecurityFileLogService { get; }
        IAddNewSecurityLogService AddNewSecurityLogService { get; }
    }
}
