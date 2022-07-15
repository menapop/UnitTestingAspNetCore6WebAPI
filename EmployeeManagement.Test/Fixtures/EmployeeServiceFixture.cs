using EmployeeManagement.Business;
using EmployeeManagement.Services.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.Fixtures
{
    public  class EmployeeServiceFixture : IDisposable
    {
        public EmployeeManagementTestDataRepository EmployeeManagementTestDataRepository { get; }
        public EmployeeService  EmployeeService { get; }   
        public EmployeeServiceFixture()
        {
            EmployeeManagementTestDataRepository = new EmployeeManagementTestDataRepository();

            EmployeeService = new EmployeeService(EmployeeManagementTestDataRepository, new EmployeeFactory());
        }

        public void Dispose()
        {
            // clean up id requird   
        }
    }
}
