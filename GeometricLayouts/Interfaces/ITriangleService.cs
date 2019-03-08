using GeometricLayouts.Models;

namespace GeometricLayouts.Interfaces
{
    /// <summary>
    /// Interface exposing services related to triangles.
    /// </summary>
    public interface ITriangleService
    {
        /// <summary>
        /// Retrieves a <see cref="Triangle"/> for a given name.
        /// </summary>
        /// <param name="name">The triangle name.</param>
        /// <returns>The triangle with its coordinates</returns>
        Triangle GetTriangle(string name);

        /// <summary>
        /// Retrieves the name of a given <see cref="Triangle"/>.
        /// </summary>
        /// <param name="triangle">The triangle with its coordinates.</param>
        /// <returns>The triangle name</returns>
        string GetName(Triangle triangle);
    }
}