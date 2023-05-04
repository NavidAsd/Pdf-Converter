using Quartz;
using System.Threading.Tasks;
using Application.Interface.FacadPattern;

namespace Application.Services.QuartzTasks.RemoveLogs
{
    [DisallowConcurrentExecution]
    public class RemoveInputFiles : IJob
    {
        private readonly IQuartzServicesFacad _Services;
        public RemoveInputFiles(IQuartzServicesFacad services)
        {
            _Services = services;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _Services.RemoveInputFilesService.RemoveInputFiles(2);
            return Task.CompletedTask;
        }
    }
}
