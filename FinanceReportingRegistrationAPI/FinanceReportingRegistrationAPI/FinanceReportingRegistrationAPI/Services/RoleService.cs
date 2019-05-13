using DataAccess.Models;
using FinanceReportingRegistrationAPI.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceReportingRegistrationAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataContext _dataContext;
        public RoleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> AddRole(Role role)
        {
            if (role == null)
            {
                throw new NullReferenceException();
            }

            role.DateCreated = DateTime.UtcNow;

            _dataContext.Roles.Add(role);
            await _dataContext.SaveChangesAsync();

            return role.Id;
        }

        public void DeleteRole(int id)
        {
            var role = _dataContext.Roles.Find(id);

            if (role == null)
            {
                throw new NullReferenceException();
            }

            role.IsDeleted = true;
            _dataContext.Update(role);

            _dataContext.SaveChanges();
        }

        public IEnumerable<Role> GetAll()
        {
            return _dataContext.Roles.Where(x => x.IsDeleted == false).ToList();
        }

        public async Task<Role> GetRole(int id)
        {
            var role = await _dataContext.Roles.FindAsync(id);

            if (role == null)
            {
                throw new NullReferenceException();
            }

            return role;
        }

        public async Task<Role> UpdateRole(Role role)
        {
            if (role == null)
            {
                throw new NullReferenceException();
            }

            var existingRole = _dataContext.Roles.SingleOrDefault(r => r.Id == role.Id);
            if (existingRole == null)
            {
                throw new NullReferenceException();
            }

            existingRole.Name = role.Name;

            _dataContext.Update(existingRole);
            await _dataContext.SaveChangesAsync();

            return existingRole;
        }
    }
}
