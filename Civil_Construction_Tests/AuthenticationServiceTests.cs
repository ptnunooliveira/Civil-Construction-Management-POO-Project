using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Services;
using Moq;

namespace Civil_Construction_Tests
{
    public class AuthenticationServiceTests
    {

        private Mock<IUserRepository> _mockUserRepository;
        private AuthenticationService _authenticationService;

        [SetUp]
        public void Setup()
        {

            _mockUserRepository = new Mock<IUserRepository>();
            _authenticationService = new AuthenticationService(_mockUserRepository.Object);
        }


        #region UserExists_Test

        [Test]
        public void UserExists_ValidCredentials_ReturnsTrue()
        {

            // Arrange
            User user = new()
            {
                Username = "Teste",
                Password = "12345"
            };

            SetupUserMock(user, "Teste");


            // Act
            bool result = _authenticationService.UserExists("Teste", "12345");


            // Assert
            Assert.IsTrue(result, "UserExists should return true for correct username and password");
        }

        [Test]
        public void UserExists_InvalidCredentials_ReturnsFalse()
        {

            // Arrange
            User user = new()
            {
                Username = "Teste",
                Password = "AdoroBacalhau"
            };

            SetupUserMock(user, "Teste");


            // Act
            bool result = _authenticationService.UserExists("Teste", "OdeioBacalhau");

            // Assert
            Assert.IsFalse(result, "UserExists should return false for invalid username or password");
        }

        [Test]
        public void UserExists_EmptyCredentials_ThrowsException()
        {

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _authenticationService.UserExists("", ""));

            Assert.That(e.Message, Is.EqualTo("username or password can't be null"));
        }

        #endregion


        #region CreateUser_Test

        [Test]
        public void CreateUser_ValidCredentials_ReturnsTrue()
        {

            // Arrange
            User user = new()
            {
                Username = "Nunoooo",
                Password = "AAAAAAAAAAAA",
                PasswordConfirmation = "AAAAAAAAAAAA"
            };

            SetupUserMock(user);

            // Act
            bool success = _authenticationService.CreateUser(user);

            // Assert
            Assert.IsTrue(success, "CreateUser should return true for valid credentials");
        }

        [Test]
        public void CreateUser_DifferentPassword_ThrowsException()
        {

            // Arrange
            User user = new()
            {
                Username = "fml",
                Password = "12345",
                PasswordConfirmation = "54321"
            };

            SetupUserMock(user);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _authenticationService.CreateUser(user));

            Assert.That(e.Message, Is.EqualTo("The passwords must be the same"));
        }

        [Test]
        public void CreateUser_InvalidUsername_ThrowsException()
        {

            // Arrange
            User user = new()
            {
                Username = "Nuno",
                Password = "12345",
                PasswordConfirmation = "12345"
            };

            SetupUserMock(user, "Nuno");

            // Act & Assert 
            var e = Assert.Throws<ArgumentException>(() => _authenticationService.CreateUser(user));

            Assert.That(e.Message, Is.EqualTo("Username already exists"));
        }

        [Test]
        public void CreateUser_UsernameLenght_ThrowsException()
        {

            // Arrange
            User user = new()
            {
                Username = "EsteUsernameVaiTerMaisDeVinteCaracteresParaQuePossaTestarAPorcariaDaException",
                Password = "12345",
                PasswordConfirmation = "12345"
            };

            SetupUserMock(user);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _authenticationService.CreateUser(user));

            Assert.That(e.Message, Is.EqualTo("Username is too long. Must be 20 characters or less"));
        }

        [Test]
        public void CreateUser_PasswordLenght_ThrowsException()
        {

            // Arrange
            User user = new()
            {
                Username = "Nuno",
                Password = "1234",
                PasswordConfirmation = "1234"
            };

            SetupUserMock(user);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _authenticationService.CreateUser(user));

            Assert.That(e.Message, Is.EqualTo("Password must be at least 5 characters long"));
        }

        #endregion


        private void SetupUserMock(User? user, string username)
        {

            _mockUserRepository.Setup(repo => repo.GetUserByUsername(username)).Returns(user);
        }

        private void SetupUserMock(User? user)
        {

            _mockUserRepository.Setup(repo => repo.AddUser(user)).Returns(true);
        }
    }
}