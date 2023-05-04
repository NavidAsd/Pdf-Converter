using Application.Services.Command.ServicesLog.AddNewOrganizeLog;
using Application.Services.Query.ReturnOrganizedFileLog;

namespace Application.Interface.FacadPattern
{
    public class OrganizersLogFacad : IOrganizersLogFacad
    {
        private readonly IPdfConverterContext _Context;
        public OrganizersLogFacad(IPdfConverterContext context)
        {
            _Context = context;
        }

        private IReturnOrganizedFileLogService _returnOrganizedLog;
        public IReturnOrganizedFileLogService ReturnOrganizedFileLogService
        {
            get
            {
                return _returnOrganizedLog = _returnOrganizedLog ?? new ReturnOrganizedFileLogService(_Context);
            }
        }
        private IAddNewOrganizeLogService _addNewOrganizeLog;
        public IAddNewOrganizeLogService AddNewOrganizeLogService
        {
            get
            {
                return _addNewOrganizeLog = _addNewOrganizeLog ?? new AddNewOrganizeLogService(_Context);
            }
        }
    }
}
