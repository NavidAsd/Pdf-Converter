using Application.Services.Command.QuartzServices.CreateDBbackup;
using Application.Services.Command.QuartzServices.RemoveAllFilesLog;
using Application.Services.Command.QuartzServices.RemoveEmailSenderLogs;
using Application.Services.Command.QuartzServices.RemoveInputFiles;
using Application.Services.Command.QuartzServices.RemoveOutFiles;

namespace Application.Interface.FacadPattern
{
    public interface IQuartzServicesFacad
    {
        IRemoveFilesLogService RemoveConvertLogsService { get; }
        IRemoveInputFilesService RemoveInputFilesService { get; }
        ICreateDatabaseBackupService CreateDatabaseBackupService { get; }
        IRemoveEmailSenderLogs RemoveEmailSenderLogs { get; }
        IRemoveOutFilesService RemoveOutFilesService { get; }
    }
}
