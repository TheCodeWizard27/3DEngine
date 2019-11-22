using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Matrix1D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double R { get; set; }

        public Matrix1D(double x, double y, double z, double r)
        {
            X = x;
            Y = y;
            Z = z;
            R = r;
        }

        public static Matrix1D From(Vertex vertex)
        {
            return new Matrix1D(vertex.X, vertex.Y, vertex.Z, 1);
        }

        public Matrix1D Multiply(Matrix4D mat)
        {
            X = X * mat.X1 + Y * mat.X2  + Z * mat.X3 + R * mat.X4;
            Y = X * mat.Y1 + Y * mat.Y2 + Z * mat.Y3 + R * mat.Y4;
            Z = X * mat.Z1 + Y * mat.Z2 + Z * mat.Z3 + R * mat.Z4;
            R = X * mat.R1 + Y * mat.R2 + Z * mat.R3 + R * mat.R4;
            return this;
        }
    }
}
