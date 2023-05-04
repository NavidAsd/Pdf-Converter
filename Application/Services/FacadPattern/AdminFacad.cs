using Application.Interface;
using Application.Interface.FacadPattern;
using Application.Service.Command;
using Application.Service.Command.Admin.EditAdmin;
using Application.Services.Query.Admin.LoginAdmin;
using Application.Service.Command.Admin.ChangeAdminPass;
using Application.Services.Command.Admin.UserRecoveryPass;
using Application.Services.Query.Admin.ReturnAdminDetails;
using Application.Services.Command.Admin.AddNewAdmin;
using Application.Services.Command.Admin.UpdateAdmin;

namespace Application.Services.FacadPattern
{
    public class AdminFacad : IAdminFacad
    {
        private readonly IPdfConverterContext _Context;
        public AdminFacad(IPdfConverterContext context)
        {
            _Context = context;
        }
        private ILoginAdminService _loginAdmin;
        public ILoginAdminService LoginAdminService
        {
            get
            {
                return _loginAdmin = _loginAdmin ?? new LoginAdminService(_Context);
            }
        }
        private IEditAdminDataService _editAdminData;
        public IEditAdminDataService editAdminDataService
        {
            get
            {
                return _editAdminData = _editAdminData ?? new EditAdminDataService(_Context);
            }
        }
        private IChangeAdminPasswordService _changepass;
        public IChangeAdminPasswordService changeAdminPassService
        {
            get
            {
                return _changepass = _changepass ?? new ChangeAdminPasswordService(_Context);
            }
        }
        private IUserPassRecoveryService _userPassRecovery;
        public IUserPassRecoveryService UserPassRecoveryService
        {
            get
            {
                return _userPassRecovery = _userPassRecovery ?? new UserPassRecoveryService(_Context);
            }
        }
        private IReturnAdminDetailsService _returnAdminDetails;
        public IReturnAdminDetailsService ReturnAdminDetailsService
        {
            get
            {
                return _returnAdminDetails = _returnAdminDetails ?? new ReturnAdminDetailsService(_Context);
            }
        }
        private IAddNewAdminService _addNewAdmin;
        public IAddNewAdminService AddNewAdminService
        {
            get
            {
                return _addNewAdmin = _addNewAdmin ?? new AddNewAdminService(_Context);
            }
        }
        private IUpdateAdminService _updateAdmin;
        public IUpdateAdminService UpdateAdminService
        {
            get
            {
                return _updateAdmin = _updateAdmin ?? new UpdateAdminService(_Context);
            }
        }
    }
}
