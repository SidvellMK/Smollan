using DataAccess.Models;
using FinanceReportingRegistrationAPI.IServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using FinanceReportingRegistrationAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FinanceReportingRegistrationAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext, IOptions<AppSettings> appSettings)
        {
            _dataContext = dataContext;
            _appSettings = appSettings.Value;
        }

        public async Task<User> Authenticate(Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                throw new NullReferenceException();
            }

            
            var user = await _dataContext.Users.Include("Roles").Where(x => x.Email == login.Email).SingleOrDefaultAsync();

            if (user == null)
            {
                throw new NullReferenceException();
            }

            //Lets unhash 
            var passwordHash = SaltedHash.Create(user.Salt, user.Password);
            
          

            if (!passwordHash.Verify(login.Password))
            {
                return null;
            }

            user.Token = GenerateToken(user);

            // remove password before returning
            user.Password = null;
            return user;
        }

        private string GenerateToken(User user)
        {
            var roles = new List<Role>();

            foreach (var roleItem in user.Roles)
            {
                var role = _dataContext.Roles.SingleOrDefault(r => r.Id == roleItem.RoleId);
                roles.Add(role);
            }

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, roles.First().Name),//Role or Roles :(
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<int> AddUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            var emailExist = _dataContext.Users.Any(u => u.Email.Equals(user.Email));

            if (emailExist)
            {
                return user.Id;
            }

            user.DateCreated = DateTime.UtcNow;

            var passwordHash = SaltedHash.Create(user.Password);

            user.Password = passwordHash.Hash;
            user.Salt = passwordHash.Salt;

            _dataContext.Users.Add(user);
            await _dataContext.SaveChangesAsync();

            return user.Id;
        }

        public void DeleteUser(int id)
        {
            var user = _dataContext.Users.Find(id);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            user.IsDeleted = true;

            _dataContext.Update(user);
            _dataContext.SaveChanges();
        }

        public IEnumerable<User> GetUsers()
        {
            return _dataContext.Users.ToList().Where(user => user.IsDeleted == false).Select(user =>
            {
                user.Password = null;
                return user;
            });
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _dataContext.Users.Include("Roles").FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new NullReferenceException();
            }

            user.Password = null;
            return user;
        }

        public async Task<int> UpdateUser(User user)
        {
            if (user == null)
            {
                throw new NullReferenceException();
            }

            var existingUser = await _dataContext.Users.SingleOrDefaultAsync(u => u.Id == user.Id);

            if (existingUser == null)
            {
                throw new NullReferenceException();
            }

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                var passwordHash = SaltedHash.Create(user.Password);
                existingUser.Password = passwordHash.Hash;
                existingUser.Salt = passwordHash.Salt;
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.PhoneNumber = user.PhoneNumber;

            if (user.Roles.Count > 0)
            {
                var allUserRoles = _dataContext.UserRoles.Where(x => x.UserId == user.Id).ToList();

                if (allUserRoles.Count() > 0)
                {
                    foreach (var roleItem in allUserRoles)
                    {
                        _dataContext.UserRoles.Remove(roleItem);
                    }
                    await _dataContext.SaveChangesAsync();
                }

                AddUserRoles(user.Id, user.Roles);
            }

            _dataContext.Update(existingUser);
            await _dataContext.SaveChangesAsync();

            return existingUser.Id;
        }

        private void AddUserRoles(int id, List<UserRole> roles)
        {
            List<UserRole> userRoles = new List<UserRole>();

            foreach (var role in roles)
            {
                userRoles.Add(new UserRole
                {
                    RoleId = role.RoleId,
                    UserId = id
                });
            }

            foreach (var userRole in userRoles)
            {
                _dataContext.UserRoles.Add(userRole);
                _dataContext.SaveChanges();
            }            
        }
    }
}
