using Application.Interface;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services.Command.Admin.AddNewAdmin
{
    public interface IAddNewAdminService
    {
        ResultMessage<ResultAddNewAdminDto> Execute(RequestAddNewAdminDto request);
    }
    public class ResultAddNewAdminDto
    {
        public long Id { set; get; }
    }
    public class RequestAddNewAdminDto
    {
        public long CurrnetAdminId { set; get; }
        public string Email { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public bool AddAdmin { set; get; }
        public bool RemoveAdmin { set; get; }
        public string AccountImage { set; get; }
    }
    public class AddNewAdminService : IAddNewAdminService
    {
        private readonly IPdfConverterContext _Context;
        public AddNewAdminService(IPdfConverterContext context)
        {
            _Context = context;
        }
        ResultMessage<ResultAddNewAdminDto> IAddNewAdminService.Execute(RequestAddNewAdminDto request)
        {
            var currentAdmin = _Context.Admins.Where(p => p.Id == request.CurrnetAdminId && p.AddAdmin == true).FirstOrDefault();
            if (currentAdmin == null)
            {
                return new ResultMessage<ResultAddNewAdminDto>
                {
                    Success = false,
                    Message = "You do not have the necessary access to perform the desired operation"
                };
            }
            try
            {
                var checkEmailUnique = _Context.Admins.IgnoreQueryFilters().Where(p => p.Email == request.Email).FirstOrDefault();
                if (checkEmailUnique != null)
                {
                    return new ResultMessage<ResultAddNewAdminDto>
                    {
                        Success = false,
                        Message = "The entered email is already registered in the system. Please enter another email"
                    };
                }
                PasswordHasher hasher = new PasswordHasher();
                Domain.Entities.Users.Admin Admin = new Domain.Entities.Users.Admin()
                {
                    AccountImage = request.AccountImage,
                    RemoveAdmin = request.RemoveAdmin,
                    AddAdmin = request.AddAdmin,
                    FullName = request.Name,
                    Email = request.Email,
                    Password = hasher.HashPassword(request.Password),
                    InsertTime = System.DateTime.Now,
                    IsRemoved = false,
                    Used = false,
                };
                _Context.Admins.Add(Admin);
                _Context.SaveChanges();
                var result = _Context.Admins.Where(p => p.Email == request.Email).FirstOrDefault();
                return new ResultMessage<ResultAddNewAdminDto>
                {
                    Success = true,
                    Message = "New Admin SuccessFully Added",
                    Enything = new ResultAddNewAdminDto { Id = result.Id },
                };
            }
            catch
            {
                return new ResultMessage<ResultAddNewAdminDto>
                {
                    Success = false,
                    Message = "Something Wrong Please Try Again"
                };
            }
        }
    }
}
