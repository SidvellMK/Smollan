using DataAccess.Models;
using FinanceReportingRegistrationAPI.IServices;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LoginAPIUnitTests
{
    public class UserServiceTests : IClassFixture<DbFixture>
    {
        private readonly IUserService _userService;
        //private readonly DataContext dataContext;

        private ServiceProvider _serviceProvide;

        public UserServiceTests(DbFixture fixture)
        {
            _serviceProvide = fixture.ServiceProvider;
        }

        public UserServiceTests(IUserService userService)
        {
            _userService = userService;
        }

        [Fact]
        public async void ShouldCreateUser()
        {
            var user = new User()
            {
                FirstName = "Sidwell",
                LastName = "Dikote",
                Email = "sidwell@smollan.com",
                Password = "Sidwell@123",
                PhoneNumber = "011244555",
                IsDeleted = false,
                Token = "Check!Check!Check!",
            };
            var expectedResult = 1;

            var actualResult = await _userService.AddUser(user);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
