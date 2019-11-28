using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Matrix1D
    {

        #region Properties

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double R { get; set; }

        #endregion

        #region Constructors

        public Matrix1D() { }

        public Matrix1D(double x, double y, double z, double r)
        {
            X = x;
            Y = y;
            Z = z;
            R = r;
        }

        #endregion

        public static Matrix1D From(Vertex vertex)
        {
            return new Matrix1D(vertex.X, vertex.Y, vertex.Z, 1);
        }

        public Matrix1D Multiply(Matrix4D mat)
        {
            X = mat.X1 * X + mat.Y1 * Y + mat.Z1 * Z + mat.R1 * R;
            Y = mat.X2 * X + mat.Y2 * Y + mat.Z2 * Z + mat.R2 * R;
            Z = mat.X3 * X + mat.Y3 * Y + mat.Z3 * Z + mat.R3 * R;
            R = mat.X4 * X + mat.Y4 * Y + mat.Z4 * Z + mat.R4 * R;
            return this;
        }
    }
}
