using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GeometricLayouts.Models
{
    /// <summary>
    /// A triangle consists of 3 vertices V1 (right angle), V2 (top left) and V3 (bottom right). Each vertex relates to a specific position.
    /// </summary>
    public class Triangle : IEquatable<Triangle>
    {
        /// <summary>
        /// The vertex of the right angle.
        /// </summary>
        [Required]
        public Vertex V1 { get; set; }

        /// <summary>
        /// The top left vertex.
        /// </summary>
        [Required]
        public Vertex V2 { get; set; }

        /// <summary>
        /// The bottom right vertex.
        /// </summary>
        [Required]
        public Vertex V3 { get; set; }

        public bool Equals(Triangle other)
        {
            return this.V1.Equals(other.V1) && this.V2.Equals(other.V2) && this.V3.Equals(other.V3);
        }

        public override string ToString()
        {
            return string.Format("[V1: {0}; V2: {1}; V3: {2}]", this.V1, this.V2, this.V3);
        }
    }
}
