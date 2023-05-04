using Common;

namespace Application.Services.Query.Admin.LoginAdmin
{
    public interface ILoginAdminService
    {
        ResultMessage<ResultLoginAdminDto> Execute(RequestLoginAdminDto request);
        ResultMessage<ResultLoginAdminDto> LoginWithId(RequestLoginAdminWithIdDto request);
    }
    public class RequestLoginAdminWithIdDto
    {
        public long Id { set; get; }
        public string Password { set; get; }
    }
}
