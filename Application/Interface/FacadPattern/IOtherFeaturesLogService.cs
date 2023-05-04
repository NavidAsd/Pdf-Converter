using Application.Services.Command.ServicesLog.AddOtherFeaturesLog;
using Application.Services.Query.ReturnOtherFileLog;

namespace Application.Interface.FacadPattern
{
    public interface IOtherFeaturesLogService
    {
        IReturnOtherFileLogService  ReturnOtherFileLogService { get; }
        IAddNewOtherFeaturesLogService AddNewOtherFeaturesLogService { get; }
    }
}
