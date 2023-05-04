using Application.Service.Command.Admin.ChangeAdminPass;
using Application.Service.Command.Admin.EditAdmin;
using Application.Services.Command.Admin.AddNewAdmin;
using Application.Services.Command.Admin.UpdateAdmin;
using Application.Services.Command.Admin.UserRecoveryPass;
using Application.Services.Query.Admin.LoginAdmin;
using Application.Services.Query.Admin.ReturnAdminDetails;

namespace Application.Interface.FacadPattern
{
    public interface IAdminFacad
    {
        ILoginAdminService LoginAdminService { get; }
        IEditAdminDataService editAdminDataService { get; }
        IChangeAdminPasswordService changeAdminPassService { get; }
        IUserPassRecoveryService UserPassRecoveryService { get; }
        IReturnAdminDetailsService ReturnAdminDetailsService { get; }
        IAddNewAdminService AddNewAdminService { get; }
        IUpdateAdminService UpdateAdminService { get; }
    }
}