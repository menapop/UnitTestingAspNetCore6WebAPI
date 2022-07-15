using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public  class EmployeeFactoryTest : IDisposable
    {
        private EmployeeFactory _employeeFactory;   
        public EmployeeFactoryTest(EmployeeFactory employeeFactory)
        {
            _employeeFactory = employeeFactory; 
        }

        public void Dispose()
        {
            // clean up test Context for unmanaged Code 
        }

        [Fact(Skip = "Skipping this one for demo reasons.")]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
           

            // Act 

            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("kevin", "Dockx");

            // Assert 
            Assert.Equal(2500, employee.Salary);
        }
        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
          
            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("kevin", "Dockx");

            // Assert
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500,
                "Salary not in acceptable range.");
        }
        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
           
            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("kevin", "Dockx");

            // Assert
            Assert.True(employee.Salary >= 2500);
            Assert.True(employee.Salary <= 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithInRange()
        {
           
            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("kevin", "Dockx");

            // Assert
            Assert.InRange(employee.Salary, 2500, 3500);
        }
        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500_PrecisionExample()
        {
           
            // Act
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("kevin", "Dockx");
            employee.Salary = 2500.13m;
            // Assert
            Assert.Equal(2500.1m, employee.Salary, 1);
        }


        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {
            
            // Act
            var employee = _employeeFactory.CreateEmployee("kevin", "Dockx","Integrant",true);
            // Assert
            Assert.IsType<ExternalEmployee>(employee);
            //Assert.IsAssignableFrom<Employee>(employee);
        }

       
    }
}
