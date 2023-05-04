using System;
using Application.Interface;
using System.Linq;

namespace Application.Services.Command.QuartzServices.RemoveEmailSenderLogs
{
    public interface IRemoveEmailSenderLogs
    {
        bool Execute(int Day);
    }
    public class RemoveEmailSenderLogs : IRemoveEmailSenderLogs
    {
        private readonly IPdfConverterContext _Context;
        public RemoveEmailSenderLogs(IPdfConverterContext context)
        {
            _Context = context;
        }
        bool IRemoveEmailSenderLogs.Execute(int Day)
        {
            try
            {
                var Logs = _Context.EmailSenderFiles.Where(p => p.IsRemoved == true && p.InsertTime < DateTime.Now.AddDays(-Day)).ToList();
                if (Logs.Count > 0)
                {
                    foreach (var item in Logs)
                    {
                        _Context.EmailSenderFiles.Remove(item);
                    }
                    _Context.SaveChanges();
                }
                return true;
            }
            catch { return false; }
        }
    }
}
