using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class DeomInternalEmployeesControllerTests
    {
        [Fact]
        public async Task CreateInternalEmployee_InvalidInput_MustReturnBadRequest()
        {
            // Arrange
            var employeeServiceMock = new Mock<IEmployeeService>();
            var mapperMock = new Mock<IMapper>();
            var demoInternalEmployeesController = new DemoInternalEmployeesController(
                employeeServiceMock.Object, mapperMock.Object);
            var internalEmployeeForCreationDto = new InternalEmployeeForCreationDto();

            demoInternalEmployeesController.ModelState.AddModelError("FirstName", "Is Reaquired");

            // Act 
            var result = await demoInternalEmployeesController.CreateInternalEmployee(internalEmployeeForCreationDto);


            // Assert 

            var actionResult = Assert.IsType<ActionResult<InternalEmployeeDto>>(result);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            Assert.IsType<SerializableError>(badRequestResult.Value);
        }


        [Fact]
        public void GetProtectedInternalEmployees_GetActionForUserInAdminRole_MustRedirectToGetInternalEmployeesOnProtectedInternalEmployees()
        {
            // Arrange 
            var employeeServiceMock = new Mock<IEmployeeService>();
            var mapperMock = new Mock<IMapper>();

            var demoInternalEmployeesController = new DemoInternalEmployeesController(employeeServiceMock.Object, mapperMock.Object);

            var userClaims = new List<Claim>() {
                new Claim (ClaimTypes.Role,"Admin"),
                new Claim (ClaimTypes.Name ,"Mina")
            };

            var claimIdentity = new ClaimsIdentity(userClaims);
            var claimsPrincipal = new ClaimsPrincipal(claimIdentity);

            var httpContext = new DefaultHttpContext()
            {
                User = claimsPrincipal
            };
            demoInternalEmployeesController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext,
            };

            // Act 

            var result = demoInternalEmployeesController.GetProtectedInternalEmployees(); 

            // Assert 

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);

            var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(actionResult);


            Assert.Equal("ProtectedInternalEmployees", redirectoToActionResult.ControllerName);
            Assert.Equal("GetInternalEmployees", redirectoToActionResult.ActionName);
        }



        [Fact]
        public void GetProtectedInternalEmployees_GetActionForUserInAdminRole_MustRedirectToGetInternalEmployeesOnProtectedInternalEmployees_WithMock()
        {
            // Arrange 
            var employeeServiceMock = new Mock<IEmployeeService>();
            var mapperMock = new Mock<IMapper>();

            var demoInternalEmployeesController = new DemoInternalEmployeesController(employeeServiceMock.Object, mapperMock.Object);

            var httpContextMock =  new Mock<HttpContext>();
            httpContextMock.Setup(m=>m.User.IsInRole("Admin"))
                .Returns(true);

            demoInternalEmployeesController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContextMock.Object,
            };

            // Act 

            var result = demoInternalEmployeesController.GetProtectedInternalEmployees();

            // Assert 

            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);

            var redirectoToActionResult = Assert.IsType<RedirectToActionResult>(actionResult);


            Assert.Equal("ProtectedInternalEmployees", redirectoToActionResult.ControllerName);
            Assert.Equal("GetInternalEmployees", redirectoToActionResult.ActionName);
        }
    }

}
