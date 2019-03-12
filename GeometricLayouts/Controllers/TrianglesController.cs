using System.ComponentModel.DataAnnotations;
using GeometricLayouts.Interfaces;
using GeometricLayouts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeometricLayouts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrianglesController : ControllerBase
    {
        private readonly ITriangleService triangleService;
        private readonly ILogger logger;

        public TrianglesController(ITriangleService triangleService, ILogger<TrianglesController> logger)
        {
            this.triangleService = triangleService;
            this.logger = logger;
        }

        /// <summary>
        /// Retrieves the triangle coordinates for a given row and column.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/triangles/B3
        ///     
        /// </remarks>
        /// <param name="name">
        /// <para>The name of the triangle to retrieve such as:</para>
        /// <ul>
        /// <li>The first character is a letter between <i>A</i> and <i>E</i> which representing the row.</li>
        /// <li>The other one or two characters are a number between <i>1</i> and <i>12</i> representing the column.</li>
        /// </ul>
        /// </param>
        /// <returns>The triangle with its coordinates</returns>
        /// <response code="200">Returns the triangle with its coordinates</response>
        /// <response code="400">If the name does not follow the right pattern</response>
        /// <response code="404">If the triangle does not exist</response>
        [HttpGet("{name}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Triangle> GetTriangle([RegularExpression(@"^[A-F]([1-9]|1[012])$")] string name)
        {
            Triangle triangle = this.triangleService.GetTriangle(name);

            if (triangle != null)
            {
                return triangle;
            }
            else
            {
                this.logger.LogWarning("Triangle {name} not found", name);
                return this.NotFound();
            }
        }

        /// <summary>
        /// Retrieves the row and column for a given triangle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///        "v1": {"x": "20", "y": "20"},
        ///        "v2": {"x": "20", "y": "10"},
        ///        "v3": {"x": "30", "y": "20"}
        ///     }
        ///     
        /// </remarks>
        /// <param name="triangle">
        /// <para>The triangle to retrieve the row and column for.</para>
        /// <para>The vertices must be provided in the right order as defined in the request documentation.</para>
        /// </param>
        /// <returns>The triangle name</returns>
        /// <response code="200">Returns the triangle name</response>
        /// <response code="400">If the request is not a valid triangle</response>
        /// <response code="404">If the triangle does not exist</response>
        [HttpPost("name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<GetTriangleNameResponse> GetName([FromBody] Triangle triangle)
        {
            string name = this.triangleService.GetName(triangle);

            if (name != null)
            {
                return new GetTriangleNameResponse(name);
            }
            else
            {
                this.logger.LogWarning("Triangle not found: {triangle}", triangle);
                return this.NotFound();
            }
        }
    }
}