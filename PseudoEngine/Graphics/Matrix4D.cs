using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Matrix4D
    {

        #region Properties

        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double Z1 { get; set; }
        public double R1 { get; set; }

        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double Z2 { get; set; }
        public double R2 { get; set; }

        public double X3 { get; set; }
        public double Y3 { get; set; }
        public double Z3 { get; set; }
        public double R3 { get; set; }

        public double X4 { get; set; }
        public double Y4 { get; set; }
        public double Z4 { get; set; }
        public double R4 { get; set; }

        #endregion

        #region Constructors

        public Matrix4D() { }

        public Matrix4D(
            double x1, double y1, double z1, double r1
            , double x2, double y2, double z2, double r2
            , double x3, double y3, double z3, double r3
            , double x4, double y4, double z4, double r4)
        {
            X1 = x1;
            X2 = x2;
            X3 = x3;
            X4 = x4;

            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
            Y4 = y4;

            Z1 = z1;
            Z2 = z2;
            Z3 = z3;
            Z4 = z4;

            R1 = r1;
            R2 = r2;
            R3 = r3;
            R4 = r4;
        }

        #endregion

        #region Static Methods

        public static Matrix4D GetTranslation(Vertex vertex)
        {
            return GetTranslation(vertex.X, vertex.Y, vertex.Z);
        }
        public static Matrix4D GetTranslation(double x, double y, double z)
        {
            return new Matrix4D(
                    1, 0, 0, x,
                    0, 1, 0, y,
                    0, 0, 1, z,
                    0, 0, 0, 1
                );
        }

        public static Matrix4D GetScale(Vertex vertex)
        {
            return GetScale(vertex.X, vertex.Y, vertex.Z);
        }
        public static Matrix4D GetScale(double x, double y, double z)
        {
            return new Matrix4D(
                    x, 0, 0, 0,
                    0, y, 0, 0,
                    0, 0, z, 0,
                    0, 0, 0, 1
                );
        }

        public static Matrix4D GetXRot(double x)
        {
            var cos = Math.Cos(x);
            var sin = Math.Sin(x);

            return new Matrix4D(
                1, 0, 0, 0,
                0, cos, -sin, 0,
                0, sin, cos, 0,
                0, 0, 0, 1
                );
        }

        public static Matrix4D GetYRot(double y)
        {
            var cos = Math.Cos(y);
            var sin = Math.Sin(y);

            return new Matrix4D(
                 cos, 0, sin, 0,
                   0, 1, 0, 0,
                -sin, 0, cos, 0,
                   0, 0, 0, 1
                );
        }

        public static Matrix4D GetZRot(double z)
        {
            var cos = Math.Cos(z);
            var sin = Math.Sin(z);

            return new Matrix4D(
                cos, -sin, 0, 0,
                sin, cos, 0, 0,
                  0, 0, 1, 0,
                  0, 0, 0, 1
                );
        }

        #endregion

        #region Public Methods

        public Matrix4D Multiply(Matrix4D mat)
        {
            X1 = X1*mat.X1 + Y1*mat.X2 + Z1*mat.X3 + R1*mat.X4;
            Y1 = X1*mat.Y1 + Y1*mat.Y2 + Z1*mat.Y3 + R1*mat.Y4;
            Z1 = X1*mat.Z1 + Y1*mat.Z2 + Z1*mat.Z3 + R1*mat.Z4;
            R1 = X1*mat.R1 + Y1*mat.R2 + Z1*mat.R3 + R1*mat.R4;
                       
            X2 = X2*mat.X1 + Y2*mat.X2 + Z2*mat.X3 + R2*mat.X4;
            Y2 = X2*mat.Y1 + Y2*mat.Y2 + Z2*mat.Y3 + R2*mat.Y4;
            Z2 = X2*mat.Z1 + Y2*mat.Z2 + Z2*mat.Z3 + R2*mat.Z4;
            R2 = X2*mat.R1 + Y2*mat.R2 + Z2*mat.R3 + R2*mat.R4;
                       
            X3 = X3*mat.X1 + Y3*mat.X2 + Z3*mat.X3 + R3*mat.X4;
            Y3 = X3*mat.Y1 + Y3*mat.Y2 + Z3*mat.Y3 + R3*mat.Y4;
            Z3 = X3*mat.Z1 + Y3*mat.Z2 + Z3*mat.Z3 + R3*mat.Z4;
            R3 = X3*mat.R1 + Y3*mat.R2 + Z3*mat.R3 + R3*mat.R4;
                       
            X4 = X4*mat.X1 + Y4*mat.X2 + Z4*mat.X3 + R4*mat.X4;
            Y4 = X4*mat.Y1 + Y4*mat.Y2 + Z4*mat.Y3 + R4*mat.Y4;
            Z4 = X4*mat.Z1 + Y4*mat.Z2 + Z4*mat.Z3 + R4*mat.Z4;
            R4 = X4*mat.R1 + Y4*mat.R2 + Z4*mat.R3 + R4*mat.R4;
            return this;
        }
        
        public Matrix1D Multiply(Matrix1D mat)
        {
            mat.X = X1 * mat.X + Y1 * mat.Y + Z1 * mat.Z + R1 * mat.R;
            mat.Y = X2 * mat.X + Y2 * mat.Y + Z2 * mat.Z + R2 * mat.R;
            mat.Z = X3 * mat.X + Y3 * mat.Y + Z3 * mat.Z + R3 * mat.R;
            mat.R = X4 * mat.X + Y4 * mat.Y + Z4 * mat.Z + R4 * mat.R;
            return mat;
        }

        #endregion

    }
}
