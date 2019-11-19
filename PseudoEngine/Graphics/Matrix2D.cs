using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    class Matrix2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Matrix2D(double x, double y, double z)
        {
            this.X = y;
            this.Y = y;
            this.Z = z;
        }

        public static Matrix2D From(Vertex vertex)
        {
            return new Matrix2D(vertex.X, vertex.Y, vertex.Z);
        }

        public Matrix2D Multiply2D(Matrix3D mat)
        {
            X = X * mat.X1 + Y * mat.X2  + Z * mat.X3;
            Y = X * mat.Y1 + X * mat.Y2 + Z * mat.Y3;
            Z = X * mat.Z1 + X * mat.Z2 + Z * mat.Z3;
            return this;
        }
    }
}
