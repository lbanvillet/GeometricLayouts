using System;
using System.ComponentModel.DataAnnotations;

namespace GeometricLayouts.Models
{
    /// <summary>
    /// An angular point of a polygon defined by its <i>x</i> and <i>y</i> coordinates.
    /// </summary>
    public class Vertex : IEquatable<Vertex>
    {
        public Vertex(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// The x-axis coordinate.
        /// </summary>
        [Range(0, 60)]
        public int X { get; set; }

        /// <summary>
        /// The y-axis coordinate.
        /// </summary>
        [Range(0, 60)]
        public int Y { get; set; }

        public bool Equals(Vertex other)
        {
            return this.X.Equals(other.X) && this.Y.Equals(other.Y);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }
}
