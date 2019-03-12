using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GeometricLayouts.Models
{
    /// <summary>
    /// Response object containing the triangle name.
    /// </summary>
    public class GetTriangleNameResponse
    {
        public GetTriangleNameResponse(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// The triangle name.
        /// </summary>
        public string Name { get; set; }
    }
}
