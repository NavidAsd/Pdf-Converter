using Application.Services.Command.ServicesLog.AddNewOptimizeLog;
using Application.Services.Query.ReturnOptimizedFileLog;

namespace Application.Interface.FacadPattern
{
    public class OptimizersLogFacad : IOptimizersLogFacad
    {
        private readonly IPdfConverterContext _Context;
        public OptimizersLogFacad(IPdfConverterContext context)
        {
            _Context = context;
        }

        private IReturnOptimizedFileLogService _returnOrganizedLog;
        public IReturnOptimizedFileLogService  ReturnOptimizedFileLogService
        {
            get
            {
                return _returnOrganizedLog = _returnOrganizedLog ?? new ReturnOptimizedFileLogService(_Context);
            }
        }
        private IAddNewOptimizeLogService _addNewOptimizeLog;
        public IAddNewOptimizeLogService  AddNewOptimizeLogService
        {
            get
            {
                return _addNewOptimizeLog = _addNewOptimizeLog ?? new AddNewOptimizeLogService(_Context);
            }
        }

    }
}
