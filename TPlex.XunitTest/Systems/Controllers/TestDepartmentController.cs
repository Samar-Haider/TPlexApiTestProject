using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPlex.Controllers;
using TPlex.Services.Interfaces;
using TPlex.XunitTest.MockData;

namespace TPlex.XunitTest.Systems.Controllers
{
    public class TestDepartmentController
    {
        private readonly ILogger<DepartmentController> _logger = null;

        [Fact]
        public void GetAllDepartments_ShouldReturn200Status()
        {
            /// Arrange
            var departmentService = new Mock<IDepartmentService>();
            departmentService.Setup(x => x.GetAllDepartments()).Returns(DepartmentMockData.GetDepartments());
            var sut = new DepartmentController(_logger, departmentService.Object);

            /// Act
            var result = (OkObjectResult) sut.GetAllDepartments();

            /// Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
    }
}
