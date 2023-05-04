using Quartz;
using Common;
using System.Threading.Tasks;
using Application.Interface.FacadPattern;

namespace Application.Services.QuartzTasks.RemoveLogs
{
    [DisallowConcurrentExecution]
    public class RemoveLog : IJob
    {
        private readonly IQuartzServicesFacad _Services;
        public RemoveLog(IQuartzServicesFacad services)
        {
            _Services = services;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _Services.RemoveConvertLogsService.DeleteAllLogs(GetPath.GetDeletLogsDay());
            
            _Services.RemoveInputFilesService.RemoveInputFilesDetail(GetPath.GetDeletLogsDay()); // Delete Log InputFile

            _Services.RemoveEmailSenderLogs.Execute(GetPath.GetDeletLogsDay());// Delete EmailSender Logs

            _Services.RemoveOutFilesService.DeleteAllFiles(GetPath.GetDeletLogsDay());// Delete All OutFiles

            _Services.RemoveOutFilesService.DeleteQrImages(GetPath.GetDeletLogsDay());// Delete All QrImages
            return Task.CompletedTask;
        }
    }
}
