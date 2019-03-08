using GeometricLayouts.Interfaces;
using GeometricLayouts.Models;
using GeometricLayouts.Services;
using System.Collections.Generic;
using Xunit;

namespace GeometricLayouts.Tests.Services
{
    public class DefaultTriangleServiceTest
    {
        private readonly ITriangleService _triangleService;

        public DefaultTriangleServiceTest()
        {
            _triangleService = new DefaultTriangleService();
        }

        [Fact]
        public void GetTriangle_WithOddColumnNumber()
        {
            Triangle result = _triangleService.GetTriangle("B5");

            Triangle expected = new Triangle()
            {
                V1 = new Vertex(20, 20),
                V2 = new Vertex(20, 10),
                V3 = new Vertex(30, 20)
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetTriangle_WithEvenColumnNumber()
        {
            Triangle result = _triangleService.GetTriangle("E6");

            Triangle expected = new Triangle()
            {
                V1 = new Vertex(30, 40),
                V2 = new Vertex(20, 40),
                V3 = new Vertex(30, 50)
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetTriangle_DoesNotExist()
        {
            Triangle result = _triangleService.GetTriangle("G1");

            Assert.Null(result);
        }

        [Fact]
        public void GetName_WithOddColumnNumber()
        {
            Triangle requestedTriangle = new Triangle()
            {
                V1 = new Vertex(20, 20),
                V2 = new Vertex(20, 10),
                V3 = new Vertex(30, 20)
            };

            string result = _triangleService.GetName(requestedTriangle);

            Assert.Equal("B5", result);
        }

        [Fact]
        public void GetName_WithEvenColumnNumber()
        {
            Triangle requestedTriangle = new Triangle()
            {
                V1 = new Vertex(30, 40),
                V2 = new Vertex(20, 40),
                V3 = new Vertex(30, 50)
            };

            string result = _triangleService.GetName(requestedTriangle);

            Assert.Equal("E6", result);
        }

        [Fact]
        public void GetName_DoesNotExist()
        {
            Triangle requestedTriangle = new Triangle()
            {
                V1 = new Vertex(30, 40),
                V2 = new Vertex(10, 40), // E4.V2
                V3 = new Vertex(30, 50)
            };

            string result = _triangleService.GetName(requestedTriangle);

            Assert.Null(result);
        }
    }
}
