
using Application.Interface.FacadPattern;
using Quartz;
using System.Threading.Tasks;

namespace Application.Services.QuartzTasks.RemoveLogs
{
    [DisallowConcurrentExecution]
    public class DatabaseBackup : IJob
    {
        private readonly IQuartzServicesFacad _Services;
        public DatabaseBackup(IQuartzServicesFacad services)
        {
            _Services = services;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _Services.CreateDatabaseBackupService.Execute();
            return Task.CompletedTask;
        }
    }
}
