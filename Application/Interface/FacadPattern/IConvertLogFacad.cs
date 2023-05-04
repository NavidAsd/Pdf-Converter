using Application.Services.Command.ServicesLog.AddNewConvertLog;
using Application.Services.Query.ReturnConvertedFileLog;

namespace Application.Interface.FacadPattern
{
    public interface IConvertLogFacad
    {
        IAddNewConvertLogService AddNewConvertLogService { get; }
        IReturnConvertedFileLogService ReturnConvertedFileLogService { get; }
        
    }
}
