using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FinanceReportingRegistrationAPI.Helpers
{
    public class Seeding
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                // Look for any Users.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                var password = SaltedHash.Create(Constants.DefaultPassword);

                context.Users.AddRange(
                    new User
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@smollan.com",
                        PhoneNumber = "0116408000",
                        Password = password.Hash,
                        IsDeleted = false,
                        DateCreated = DateTime.UtcNow,
                        Token = null,
                        Salt = password.Salt
                    }
                );
                context.SaveChanges();

                context.Roles.AddRange(
                    new Role
                    {
                        Name = "Admin",
                        IsDeleted = false,
                        DateCreated = DateTime.UtcNow
                    }
                );
                context.SaveChanges();

                context.UserRoles.AddRange(
                    new UserRole
                    {
                        UserId = 1,
                        RoleId = 1
                    }
                 );

                context.SaveChanges();
            }
        }
    }
}
