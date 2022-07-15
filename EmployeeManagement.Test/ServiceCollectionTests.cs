using EmployeeManagement.DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class ServiceCollectionTests
    {
        [Fact]
        public void RegisterDataServices_Execute_DataServicesAreRegistered()
        {
            // Arrange 
            var serviceCollection = new ServiceCollection();

            // using in memory collect to mokc  configuration

            //var configuration = new ConfigurationBuilder()
            //    .AddInMemoryCollection(
            //     new Dictionary<string, string>
            //     {
            //         {"ConnectionStrings:EmployeeManagementDB", "AnyValueWillDo" }
            //     }
            //    ).Build();
            var mockConfSection = new Mock<IConfigurationSection>();
            mockConfSection.SetupGet(m => m["EmployeeManagementDB"]).Returns("connection string here");

            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(a => a.GetSection(It.Is<string>(s=>s == "ConnectionStrings"))).Returns(mockConfSection.Object);

            // Act 
            serviceCollection.RegisterDataServices(mockConfiguration.Object);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Assert 
            Assert.NotNull(serviceProvider.GetService<IEmployeeManagementRepository>());
        }
    }
    
}
