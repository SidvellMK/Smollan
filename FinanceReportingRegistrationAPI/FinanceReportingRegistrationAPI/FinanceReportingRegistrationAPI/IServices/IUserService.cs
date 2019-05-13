using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceReportingRegistrationAPI.IServices
{
    public interface IUserService
    {
        Task<User> Authenticate(Login login);
        IEnumerable<User> GetUsers();
        Task<User> GetUser(int id);
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User user);
        void DeleteUser(int id);
    }
}
