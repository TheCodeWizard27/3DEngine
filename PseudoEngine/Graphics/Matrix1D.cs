
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

        public Matrix1D Clone()
        {
            return new Matrix1D(X, Y, Z, R);
        }

        public Matrix1D Multiply(Matrix4D mat)
        {
            
            var x = (mat.X1 * X) + (mat.Y1 * Y) + (mat.Z1 * Z) + (mat.R1 * R);
            var y = (mat.X2 * X) + (mat.Y2 * Y) + (mat.Z2 * Z) + (mat.R2 * R);
            var z = (mat.X3 * X) + (mat.Y3 * Y) + (mat.Z3 * Z) + (mat.R3 * R);
            var r = (mat.X4 * X) + (mat.Y4 * Y) + (mat.Z4 * Z) + (mat.R4 * R);
            
            /*
            var x = mat.X1 * X + mat.X2 * Y + mat.X3 * Z + mat.X4 * R;
            var y = mat.Y1 * X + mat.Y2 * Y + mat.Y3 * Z + mat.Y4 * R;
            var z = mat.Z1 * X + mat.Z2 * Y + mat.Z3 * Z + mat.Z4 * R;
            var r = mat.R1 * X + mat.R2 * Y + mat.R3 * Z + mat.R4 * R;
            */

            X = x; Y = y; Z = z; R = r;

            return this;
        }

        override public string ToString()
        {
            return $"[{X},{Y},{Z},{R}]";
        }
    }
}
