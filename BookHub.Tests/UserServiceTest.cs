using BookHub.Core;
using BookHub.Core.Repository;
using BookHub.Core.Entities;
using Moq;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using User = BookHub.Core.Entities.User;

namespace BookHub.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _mockUserRepository;
        private UserService _userService;
        [TestInitialize]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }
        [TestMethod]
        public void RegisterUser_ValidUser_ReturnsTrue()
        {
            // Arrange 
            var user = new User
            {
                Email = "test@example.com",
                Password = "password123"

            };
            // Act 
            var result = _userService.RegisterUser(user);
            // Assert 
            Assert.IsTrue(result);
            _mockUserRepository.Verify(repo =>
           repo.Add(It.IsAny<Core.Entities.User>()), Times.Once);
        }
        [TestMethod]
        public void RegisterUser_InvalidEmail_ReturnsFalse()
        {
            // Arrange 
            var user = new User { Email = "", Password = "password123" };
            // Act 
            var result = _userService.RegisterUser(user);
            // Assert 
            Assert.IsFalse(result);
            _mockUserRepository.Verify(repo =>
           repo.Add(It.IsAny<User>()), Times.Never);
        }

       // [TestMethod]
       
        // More tests... 
    }
}
