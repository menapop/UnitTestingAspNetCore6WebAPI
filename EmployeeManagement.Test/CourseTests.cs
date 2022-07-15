using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public  class CourseTests
    {
       
        [Fact]
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            // Arrange 
            // nothing 

            // Act 
            var course = new Course("Data Structure Using C++");

            // Assert 
            Assert.True(course.IsNew);
        }
    }
}
