using Civil_Construction_Management.Models;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModels.Services;
using Moq;

namespace Civil_Construction_Tests
{
    public class ManagerEmployeeTests
    {

        #region Private Fields

        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private ManagerEmployee _managerEmployee;

        #endregion


        #region Setup

        [SetUp]
        public void Setup()
        {

            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _managerEmployee = new ManagerEmployee(_mockEmployeeRepository.Object);
        }

        #endregion


        #region EmployeeExists_Tests

        [Test]
        public void EmployeeExists_Yes_ReturnsTrue()
        {

            // Arrange
            Employee employee = new Employee("Nuno", "123456789", "987654321", "teste@gmail.com", "CEO", 10, DateTime.Now);
            employee.ID = 1;
            SetupEmployeeMock(employee, 1);

            // Act
            bool result = _managerEmployee.EmployeeExists(employee);

            // Assert
            Assert.IsTrue(result, "EmployeeExists should return true for an existent employee");
        }

        #endregion


        #region CreateEmployee_Tests

        [Test]
        public void CreateEmployee_ValidData_ReturnsTrue()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "911232776", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act
            bool success = _managerEmployee.CreateEmployee(emp);

            // Assert
            Assert.IsTrue(success, "CreateEmployee should return true to valid data");
        }

        [Test]
        public void CreateEmployee_NameEmpty_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("", "251222111", "911232776", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's Name can't be null"));
        }

        [Test]
        public void CreateEmployee_NameLenght_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("This username lenght will be longer than 50 characters just to test the function", "251222111", "911232776", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's Name is too long. Must be 50 characters or less"));
        }

        [Test]
        public void CreateEmployee_NIFEmpty_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "", "911232776", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's NIF can't be null"));
        }

        [Test]
        public void CreateEmployee_NIFInvalidLength_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "123", "911232776", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's NIF must be 9 characters long"));
        }

        [Test]
        public void CreateEmployee_EmailEmpty_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "911232776", "", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's email can't be null"));
        }

        [Test]
        public void CreateEmployee_EmailTooLong_ThrowsException()
        {

            // Arrange
            string longEmail = "this_email_will_be_so_much_longer_than_50_characters_just_to_test_the_function_AHHHHHHHHHHHHHHH@gmail.com";
            Employee emp = new Employee("Nuno", "251222111", "911232776", longEmail, "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's email is too long. Must be 50 characters or less"));
        }

        [Test]
        public void CreateEmployee_EmailInvalidFormat_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "911232776", "nunogmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Check employee's email format"));
        }

        [Test]
        public void CreateEmployee_PhoneEmpty_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's contact can't be null"));
        }

        [Test]
        public void CreateEmployee_PhoneInvalidLength_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "123", "nuno@gmail.com", "CEO", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's contact must be 9 characters long"));
        }

        [Test]
        public void CreateEmployee_RoleEmpty_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "911232776", "nuno@gmail.com", "", 9, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's role can't be null"));
        }

        [Test]
        public void CreateEmployee_LowSalary_ThrowsException()
        {

            // Arrange
            Employee emp = new Employee("Nuno", "251222111", "911232776", "nuno@gmail.com", "CEO", 4, DateTime.Now);

            SetupEmployeeMock(emp);

            // Act & Assert
            var e = Assert.Throws<ArgumentException>(() => _managerEmployee.CreateEmployee(emp));

            Assert.That(e.Message, Is.EqualTo("Employee's salary must be at least the minimum wage"));
        }

        #endregion


        #region SetupEmployeeMocks

        private void SetupEmployeeMock(Employee? employee)
        {

            _mockEmployeeRepository.Setup(repo => repo.AddEmployee(employee)).Returns(true);
        }

        private void SetupEmployeeMock(Employee? employee, int id)
        {

            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeByID(id)).Returns(employee);
        }

        #endregion
    }
}