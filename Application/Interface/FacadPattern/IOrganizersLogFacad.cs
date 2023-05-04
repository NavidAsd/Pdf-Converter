using Application.Services.Command.ServicesLog.AddNewOrganizeLog;
using Application.Services.Query.ReturnOrganizedFileLog;

namespace Application.Interface.FacadPattern
{
    public interface IOrganizersLogFacad
    {
        IReturnOrganizedFileLogService ReturnOrganizedFileLogService { get; }
        IAddNewOrganizeLogService AddNewOrganizeLogService { get; }
    }
}
