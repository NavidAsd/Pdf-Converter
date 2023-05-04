using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Services.Command.QuartzServices.CreateDBbackup;
using Application.Services.Command.QuartzServices.RemoveAllFilesLog;
using Application.Services.Command.QuartzServices.RemoveEmailSenderLogs;
using Application.Services.Command.QuartzServices.RemoveInputFiles;
using Application.Services.Command.QuartzServices.RemoveOutFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Application.Services.FacadPattern
{
    public class QuartzServicesFacad : IQuartzServicesFacad
    {
        private readonly IPdfConverterContext _Context;
        private readonly IConfiguration _Configuration;
        private readonly IHostEnvironment _Environment;
        public QuartzServicesFacad(IPdfConverterContext context, IConfiguration configuration,IHostEnvironment environment)
        {
            _Context = context;
            _Configuration = configuration;
            _Environment = environment;
        }
        private IRemoveFilesLogService _removeConvertLog;
        public IRemoveFilesLogService RemoveConvertLogsService
        {
            get
            {
                return _removeConvertLog = _removeConvertLog ?? new RemoveFilesLogService(_Context);
            }
        }
        private IRemoveInputFilesService _removeInputFiles;
        public IRemoveInputFilesService RemoveInputFilesService
        {
            get
            {
                return _removeInputFiles = _removeInputFiles ?? new RemoveInputFilesService(_Context);
            }
        }
        private ICreateDatabaseBackupService _createDatabaseBackup;
        public ICreateDatabaseBackupService  CreateDatabaseBackupService
        {
            get
            {
                return _createDatabaseBackup = _createDatabaseBackup ?? new CreateDatabaseBackupService(_Configuration);
            }
        } 
        private IRemoveEmailSenderLogs _removeEmailSenderLogs;
        public IRemoveEmailSenderLogs   RemoveEmailSenderLogs
        {
            get
            {
                return _removeEmailSenderLogs = _removeEmailSenderLogs ?? new RemoveEmailSenderLogs(_Context);
            }
        }
        private IRemoveOutFilesService _removeOutFiles;
        public IRemoveOutFilesService   RemoveOutFilesService
        {
            get
            {
                return _removeOutFiles = _removeOutFiles ?? new RemoveOutFilesService(_Context,_Environment);
            }
        }
    }
}
