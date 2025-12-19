using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Services;
using Moq;

namespace Civil_Construction_Tests
{
    [TestFixture]
    public class ManagerProjectTests
    {
        private Mock<IProjectRepository> _mockProjectRepository;
        private ManagerProject _managerProject;

        [SetUp]
        public void Setup()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            _managerProject = new ManagerProject(_mockProjectRepository.Object);
        }

        #region Project_Tests

        [Test]
        public void AddProject_ValidData_ReturnsTrue()
        {
            // Arrange
            Project p = new Project("pro", "local", "ongoing");

            SetupProjectMock(p, true);

            // Act
            bool result = _managerProject.AddProject(p);

            // Assert
            Assert.IsTrue(result, "AddProject deve retornar true para um projeto válido.");
        }

        [Test]
        public void AddProject_ClientNameTooLong_ThrowsException()
        {
            // Arrange
            Project p = new Project("This_Client_Name_Will_Be_Soooooooo_Long_That_Will_Exceed_30_charaters", "LLLLL", "PPPPP");
            
            // Act & Assert 
            var e = Assert.Throws<ArgumentException>(() => _managerProject.AddProject(p));
            Assert.That(e.Message, Is.EqualTo("Client Name is too long. Must be 30 characters or less"));
        }

        [Test]
        public void AddProject_NullProject_ThrowsException()
        {

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerProject.AddProject(null));
            Assert.That(e.Message, Is.EqualTo("Project can't be null."));
        }

        [Test]
        public void DeleteProject_Valid_ReturnsTrue()
        {
            // Arrange
            Project p = new Project("Trash", "Trash", "Trash");

            SetupDeleteProjectMock(p, true);

            // Act
            bool success = _managerProject.DeleteProject(p);

            // Assert
            Assert.IsTrue(success, "DeleteProject should return true if project is deleted");
        }

        #endregion

        #region Project_Material_Tests

        [Test]
        public void AddMaterialToProject_ValidData_ReturnsTrue()
        {
            // Arrange
            Material m = new Material("AHHHHH", 100, 0.5);
            int projectID = 1;

            SetupProjectMock(projectID, m, true);

            // Act
            bool success = _managerProject.AddMaterialToProject(projectID, m);

            // Assert
            Assert.IsTrue(success, "AddMaterialToProject should return true if the Data is valid");
        }

        [Test]
        public void AddMaterialToProject_QuantityZero_ThrowsException()
        {
            // Arrange
            Material m = new Material("Brick", 0, 0.5);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _managerProject.AddMaterialToProject(1, m));
            Assert.That(ex.Message, Is.EqualTo("Material's quantity must be at least one unit"));
        }

        [Test]
        public void AddMaterialToProject_PriceZero_ThrowsException()
        {
            // Arrange
            Material m = new Material("Sand", 10, 0);

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _managerProject.AddMaterialToProject(1, m));
            Assert.That(ex.Message, Is.EqualTo("Material's unit price must be positive."));
        }

        #endregion

        #region Project_Service_Tests

        [Test]
        public void AddServiceToProject_ValidData_ReturnsTrue()
        {
            // Arrange
            Service s = new Service("SSSSSS", 1, "SSSSSSSS", DateTime.Now, DateTime.Now.AddHours(5));
            int projectID = 1;

            SetupProjectMock(projectID, s, true);

            // Act
            bool success = _managerProject.AddServiceToProject(projectID, s);

            // Assert
            Assert.IsTrue(success, "AddServiceToProject should return true if data is valid");
        }

        [Test]
        public void AddServiceToProject_InvalidDate_ThrowsException()
        {
            // Arrange
            Service s = new Service("SSSSS", 1, "SSSSS", DateTime.Now, DateTime.Now.AddDays(-5));

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerProject.AddServiceToProject(1, s));
            Assert.That(e.Message, Is.EqualTo("End date must end after the start date"));
        }

        #endregion

        #region SetupProjectMock

        private void SetupProjectMock(Project p, bool returns)
        {
            _mockProjectRepository.Setup(repo => repo.AddProject(p)).Returns(returns);
        }

        private void SetupDeleteProjectMock(Project p, bool returns)
        {
            _mockProjectRepository.Setup(repo => repo.DeleteProject(p)).Returns(returns);
        }

        private void SetupProjectMock(int id, Material m, bool returns)
        {
            _mockProjectRepository.Setup(repo => repo.AddMaterialToProject(id, m)).Returns(returns);
        }

        private void SetupProjectMock(int id, Service s, bool returns)
        {
            _mockProjectRepository.Setup(repo => repo.AddServiceToProject(id, s)).Returns(returns);
        }

        #endregion
    }
}