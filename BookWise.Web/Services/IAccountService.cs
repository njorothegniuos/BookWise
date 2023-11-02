using BookWise.Web.Models;
using BookWise.Web.Pages.Account;

namespace BookWise.Web.Services
{
    public interface IAccountService
    {
        User User { get; }
        Task Initialize();
        Task Login(UserModel model);
        Task Logout();
        Task<IList<User>> GetAll();
        Task<User> GetById(string id);
        Task Delete(string id);
    }
}
