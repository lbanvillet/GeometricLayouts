using System.Collections.Generic;
using GeometricLayouts.Interfaces;
using GeometricLayouts.Models;

namespace GeometricLayouts.Services
{
    public class DefaultTriangleService : ITriangleService
    {
        private const int MaxRow = 6;
        private const int MaxColumn = 12;
        private const int LegLength = 10;
        private Dictionary<string, Triangle> triangleDictionary;

        public DefaultTriangleService()
        {
            this.InitializeTriangleDictionary();
        }

        /// <inheritdoc/>
        public Triangle GetTriangle(string name)
        {
            if (this.triangleDictionary.TryGetValue(name, out Triangle triangle))
            {
                return triangle;
            }

            return null;
        }

        /// <inheritdoc/>
        public string GetName(Triangle triangle)
        {
            foreach (KeyValuePair<string, Triangle> entry in this.triangleDictionary)
            {
                if (entry.Value.Equals(triangle))
                {
                    return entry.Key;
                }
            }

            return null;
        }

        private static Triangle CalculateTriangle(int row, int column)
        {
            int v1x, v1y, v2x, v2y, v3x, v3y;

            // Calculate top left vertex coordinates
            v2x = LegLength * (int)((column - 1) / 2);
            v2y = LegLength * (row - 1);

            // Calculate right angle vertex coordinates
            if (column % 2 == 0)
            {
                v1x = v2x + LegLength;
                v1y = v2y;
            }
            else
            {
                v1x = v2x;
                v1y = v2y + LegLength;
            }

            // Calculate bottom right vertex coordinates
            v3x = v2x + LegLength;
            v3y = v2y + LegLength;

            return new Triangle()
            {
                V1 = new Vertex(v1x, v1y),
                V2 = new Vertex(v2x, v2y),
                V3 = new Vertex(v3x, v3y)
            };
        }

        private void InitializeTriangleDictionary()
        {
            this.triangleDictionary = new Dictionary<string, Triangle>();
            const string acceptedLetters = "ABCDEF";

            for (int row = 1; row <= MaxRow; row++)
            {
                for (int column = 1; column <= MaxColumn; column++)
                {
                    string triangleName = acceptedLetters[row - 1] + column.ToString();
                    Triangle triangle = CalculateTriangle(row, column);
                    this.triangleDictionary.Add(triangleName, triangle);
                }
            }
        }
    }
}