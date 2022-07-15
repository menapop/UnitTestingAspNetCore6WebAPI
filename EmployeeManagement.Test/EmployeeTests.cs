using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public  class EmployeeTests
    {

        [Fact]

        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameIsConcatenation()
        {
            // Arrange 
            var employee = new InternalEmployee ("Mina", "Morcos", 0, 2500, false, 1);

            // Act 
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";



            // Assert 
            Assert.Equal("Lucia Shelton", employee.FullName);
        }


        [Fact]

        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameStartWithFirstName()
        {
            // Arrange 
            var employee = new InternalEmployee("Mina", "Morcos", 0, 2500, false, 1);

            // Act 
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";



            // Assert 
            Assert.StartsWith("Lucia", employee.FullName);
        }

        [Fact]

        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameEndsWithLastName()
        {
            // Arrange 
            var employee = new InternalEmployee("Mina", "Morcos", 0, 2500, false, 1);

            // Act 
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";



            // Assert 
            Assert.EndsWith("Shelton", employee.FullName);
        }

        [Fact]

        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameContainsPartOfConcatenation()
        {
            // Arrange 
            var employee = new InternalEmployee("Mina", "Morcos", 0, 2500, false, 1);

            // Act 
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";



            // Assert 
            Assert.Contains("ia Sh", employee.FullName);
        }



        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstNameAndLastName_FullNameSoundsLikeConcatenation()
        {
            // Arrange 
            var employee = new InternalEmployee("Mina", "Morcos", 0, 2500, false, 1);

            // Act 
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";



            // Assert 
            Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
        }


    }
}
