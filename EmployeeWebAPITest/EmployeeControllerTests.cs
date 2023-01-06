using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;
using Moq;
using EmployeeWebAPI.Controllers;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Repository;

namespace EmployeeWebAPITests
{
    public class EmployeeControllerTests
    {
        private readonly EmployeesController _employee;
        private Fixture _fixture;
        private readonly Mock<IEmployeeRepository> _empRepoMock = new Mock<IEmployeeRepository>();
        public EmployeeControllerTests()
        {
            _employee = new EmployeesController(_empRepoMock.Object);
            _fixture = new Fixture();
        }

        //Test using dummy data
        [Fact]
        public async Task GetStudentById_InputId_GetSpecificStudent()
        {
            //Arrange
            var employee = GetEmployeesData();
            _empRepoMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(employee[0]);

            //Act
            var actionResult = await _employee.GetEmployee(1);

            //Assert
            Assert.True(employee[0].EmployeeId == actionResult.Value.EmployeeId);
        }

        //Testing using fixtur
        [Fact]
        public async Task GetStudentById_InputId_GetSpecificStudent_UsingFixture()
        {
            //Arrange
            var employee = _fixture.Create<Employee>();
            _empRepoMock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(employee);

            //Act
            var actionResult = await _employee.GetEmployee(1);

            //Assert
            Assert.NotNull(actionResult);
            Assert.True(employee.EmployeeId == actionResult.Value.EmployeeId);
        }

        [Fact]
        public async Task Put_Student_Return_204NoContent()
        {
            var employee = _fixture.Create<Employee>();
            _empRepoMock.Setup(repo => repo.EmployeeExists(employee.EmployeeId)).ReturnsAsync(true);

            var actionResult = await _employee.UpdateEmployee(employee.EmployeeId, employee);

            var result = actionResult.Result as CreatedAtActionResult;
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Delete_Student_Return_Ok()
        {
            var employee = _fixture.Create<Employee>();
            _empRepoMock.Setup(repo => repo.GetAsync(employee.EmployeeId)).ReturnsAsync(employee);

            var actionResult = await _employee.DeleteEmployee(employee.EmployeeId);

            var result = actionResult as OkObjectResult;
            Assert.Equal(200, result.StatusCode);

        }

        [Fact]
        public async Task Post_Student_Return_BadRequest()
        {
            var employee = _fixture.Create<Employee>();
            _empRepoMock.Setup(repo => repo.CreateAsync(It.IsAny<Employee>())).Throws(new Exception());

            var actionResult = await _employee.CreateEmployee(employee);
            var result = actionResult.Result as ObjectResult;

            Assert.Equal(400, result.StatusCode);

        }

        [Fact]
        public async Task Put_Student_Return_NotFound()
        {
            var employee = _fixture.Create<Employee>();
            _empRepoMock.Setup(repo => repo.UpdateAsync(It.IsAny<Employee>())).Throws(new Exception());
            _empRepoMock.Setup(repo => repo.EmployeeExists(employee.EmployeeId)).ReturnsAsync(false);

            var actionResult = await _employee.UpdateEmployee(employee.EmployeeId, employee);
            var result = actionResult.Result as NotFoundResult;

            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task Delete_Student_Return_Success()
        {
            var employee = _fixture.Create<Employee>();
            _empRepoMock.Setup(repo => repo.DeleteAsync(It.IsAny<Employee>())).Throws(new Exception());

            var actionResult = await _employee.CreateEmployee(employee);
            var result = actionResult.Result as ObjectResult;

            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public async Task Get_Student_Return_Ok()
        {
            var employeeList = _fixture.CreateMany<Employee>(3).ToList();
            _empRepoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employeeList);

            var actionResult = await _employee.GetEmployees();

            Assert.True(employeeList[0].EmployeeId == actionResult.Value.First().EmployeeId);

        }

        private List<Employee> GetEmployeesData()
        {
            List<Employee> employeeData = new List<Employee>()
            {
                new Employee()
                {
                    EmployeeId = 1,
                    EmployeeName = "Nanda",
                    Band = "X",
                    Role = "Developer",
                    Designation = "SE",
                    Responsibilities = "Good Coding"
                },

                new Employee()
                {
                    EmployeeId = 2,
                    EmployeeName = "Nithin",
                    Band = "2X",
                    Role = "UI",
                    Designation = "SSE",
                    Responsibilities = "Designing"
                },

                new Employee()
                {
                    EmployeeId = 3,
                    EmployeeName = "Punith",
                    Band = "3X",
                    Role = "Tester",
                    Designation = "ST",
                    Responsibilities = "Testing"
                }
            };
            return employeeData;
        }
    }

    
}