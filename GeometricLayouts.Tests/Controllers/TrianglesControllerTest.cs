using GeometricLayouts.Controllers;
using GeometricLayouts.Interfaces;
using GeometricLayouts.Models;
using GeometricLayouts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GeometricLayouts.Tests.Controllers
{
    public class TrianglesControllerTest
    {
        private readonly TrianglesController _triangleController;
        private Mock<ITriangleService> _mockTriangleService = new Mock<ITriangleService>();

        public TrianglesControllerTest()
        {
            Mock<ILogger<TrianglesController>> mockLogger = new Mock<ILogger<TrianglesController>>();
            _triangleController = new TrianglesController(_mockTriangleService.Object, mockLogger.Object);
        }

        [Fact]
        public void GetTriangle_ServiceReturnsNotNull()
        {
            string requested = "B5";
            Triangle expected = new Triangle()
            {
                V1 = new Vertex(20, 20),
                V2 = new Vertex(20, 10),
                V3 = new Vertex(30, 20)
            };
            _mockTriangleService.Setup(service => service.GetTriangle(requested)).Returns(expected);

            ActionResult<Triangle> result = _triangleController.GetTriangle(requested);

            Assert.Equal(expected, result.Value);
        }

        [Fact]
        public void GetTriangle_ServiceReturnsNull()
        {
            string requested = "G1";
            _mockTriangleService.Setup(service => service.GetTriangle(requested)).Returns((Triangle) null);

            ActionResult<Triangle> result = _triangleController.GetTriangle(requested);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetName_ServiceReturnsNotNull()
        {
            Triangle requested = new Triangle()
            {
                V1 = new Vertex(20, 20),
                V2 = new Vertex(20, 10),
                V3 = new Vertex(30, 20)
            };
            string expectedName = "B5";
            _mockTriangleService.Setup(service => service.GetName(requested)).Returns(expectedName);

            ActionResult<GetTriangleNameResponse> result = _triangleController.GetName(requested);

            Assert.Equal(expectedName, result.Value.Name);
        }

        [Fact]
        public void GetName_ServiceReturnsNull()
        {
            Triangle requested = new Triangle();
            _mockTriangleService.Setup(service => service.GetName(requested)).Returns((string) null);

            ActionResult<GetTriangleNameResponse> result = _triangleController.GetName(requested);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
