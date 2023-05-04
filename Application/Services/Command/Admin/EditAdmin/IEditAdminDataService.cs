using Application.Interface;
using Common;
using System.Linq;

namespace Application.Service.Command.Admin.EditAdmin
{
    public interface IEditAdminDataService
    {
        ResultMessage Execute(RequestEditAdminDataDto request);
        ResultMessage EditImage(RequestEditAdminImageDto request);
    }
    public class RequestEditAdminDataDto
    {
        public long Id { set; get; }
        public string FullName { set; get; }
        public string Email { set; get; }
    }
    public class RequestEditAdminImageDto
    {
        public long Id { set; get; }
        public string ImageName { set; get; }
        public string ImagePath { set; get; }

    }
    public class EditAdminDataService : IEditAdminDataService
    {
        private readonly IPdfConverterContext _Context;
        public EditAdminDataService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage IEditAdminDataService.Execute(RequestEditAdminDataDto request)
        {
            var uniqe = _Context.Admins.Where(p => p.Email == request.Email && p.Id != request.Id).FirstOrDefault();
            if (uniqe != null)
            {
                return new ResultMessage
                {
                    Success = false,
                    Message = "Email already registered Please enter another email"
                };
            }
            var result = _Context.Admins.Find(request.Id);
            if (result != null)
            {
                result.FullName = request.FullName;
                result.Email = request.Email;
                _Context.SaveChanges();

                return new ResultMessage()
                {
                    Success = true,
                    Message = "Update Data Successfully"
                };
            }
            else
            {
                return new ResultMessage()
                {
                    Success = false,
                    Message = "User NotFound!"
                };
            }
        }

    ResultMessage IEditAdminDataService.EditImage(RequestEditAdminImageDto request)
    {
        var result = _Context.Admins.Find(request.Id);
        try
        {
            // image saved in controller
            result.AccountImage = request.ImageName;
            _Context.SaveChanges();
            return new ResultMessage()
            {
                Success = true,
                Message = "Update Data Successfuly"
            };
        }
        catch
        {
            return new ResultMessage()
            {
                Success = false,
                Message = "The entered email is already registered in the system"
            };
        }
    }
}

}
