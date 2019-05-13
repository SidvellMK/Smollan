using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceReportingRegistrationAPI.IServices
{
    public interface IRoleService
    {
        Task<Role> GetRole(int id);
        IEnumerable<Role> GetAll();
        Task<int> AddRole(Role role);
        Task<Role> UpdateRole(Role role);
        void DeleteRole(int id);
    }
}
