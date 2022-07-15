using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using AutoMapper;
using EmployeeManagement.MapperProfiles;

namespace EmployeeManagement.Test
{
    public class InternalEmployeeControllerTests
    {
        private readonly InternalEmployeesController _InternalEmployeesController;
        private readonly InternalEmployee _firstEmployee;

        public InternalEmployeeControllerTests()
        {
            var employeeServiceMock = new Mock<IEmployeeService>();
            _firstEmployee = new InternalEmployee("Megan", "Jones", 2, 3000, false, 2);
            employeeServiceMock.Setup(m => m.FetchInternalEmployeesAsync())
                .ReturnsAsync(new List<InternalEmployee>()
                {
                    _firstEmployee,
                    new InternalEmployee("Jaimy", "Johnson", 3, 3400, true, 1),
                    new InternalEmployee("Anne", "Adams", 3, 4000, false, 3)
                });
            //var mapperMock = new Mock<IMapper>();
            //mapperMock.Setup(m =>
            //     m.Map<InternalEmployee, InternalEmployeeDto>
            //     (It.IsAny<InternalEmployee>()))
            //     .Returns(new InternalEmployeeDto());

            var mapperConfiguration = new MapperConfiguration(c => c.AddProfile<EmployeeProfile>());

            var mapper = new Mapper(mapperConfiguration);

            _InternalEmployeesController = new InternalEmployeesController(employeeServiceMock.Object, mapper);
        }
        [Fact]
        public async Task GetInternalEmployees_GetAction_MustReturnOkObjectResult()
        {
            // Arrange 


            // Act 
            var result = await _InternalEmployeesController.GetInternalEmployees();

            // Assert 

            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result);

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }


        [Fact]
        public async Task GetInternalEmployees_GetAction_MustReturnIEnumerableOfInternalEmployeeDtoAsModelType()
        {
            // Arrange 


            // Act 
            var result = await _InternalEmployeesController.GetInternalEmployees();

            // Assert 

            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result);

            Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(((OkObjectResult)actionResult.Result).Value);


        }

        [Fact]
        public async Task GetInternalEmployees_GetAction_MustReturnNumberOfInputtedInternalEmployees()
        {
            // Arrange 


            // Act 
            var result = await _InternalEmployeesController.GetInternalEmployees();

            // Assert 

            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result);

            Assert.Equal(3,
                ((IEnumerable<InternalEmployeeDto>)((OkObjectResult)actionResult.Result).Value).Count()
                );
        }

        [Fact]
        public async Task GetInternalEmployees_GetAction_ReturnsOkObjectResultWithCorrectAmountOfInternalEmployees()
        {
            // Act 
            var result = await _InternalEmployeesController.GetInternalEmployees();

            // Assert 
            var actionResult = Assert.IsType<ActionResult<IEnumerable<InternalEmployeeDto>>>(result);

            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);

            var dtos = Assert.IsAssignableFrom<IEnumerable<InternalEmployeeDto>>(okObjectResult.Value);

            var firstEmployee = dtos.First();
            Assert.Equal(_firstEmployee.Id, firstEmployee.Id);
            Assert.Equal(_firstEmployee.FirstName, firstEmployee.FirstName);
            Assert.Equal(_firstEmployee.LastName, firstEmployee.LastName);
            Assert.Equal(_firstEmployee.Salary, firstEmployee.Salary);
            Assert.Equal(_firstEmployee.SuggestedBonus, firstEmployee.SuggestedBonus);
            Assert.Equal(_firstEmployee.YearsInService, firstEmployee.YearsInService);

        }
    }
}
