using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Matrix4D
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double X4 { get; set; }

        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
        public double Y4 { get; set; }

        public double Z1 { get; set; }
        public double Z2 { get; set; }
        public double Z3 { get; set; }
        public double Z4 { get; set; }

        public double R1 { get; set; }
        public double R2 { get; set; }
        public double R3 { get; set; }
        public double R4 { get; set; }

        public Matrix4D(
            double x1, double x2, double x3, double x4
            , double y1, double y2, double y3, double y4
            , double z1, double z2, double z3, double z4
            , double r1, double r2, double r3, double r4)
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

        public Matrix4D Multiply(Matrix4D matrix3D)
        {
            X1 *= matrix3D.X1;
            Y1 *= matrix3D.Y1;
            Z1 *= matrix3D.Z1;
            R1 *= matrix3D.R1;

            X2 *= matrix3D.X2;
            Y2 *= matrix3D.Y2;
            Z2 *= matrix3D.Z2;
            R2 *= matrix3D.R2;

            X3 *= matrix3D.X3;
            Y3 *= matrix3D.Y3;
            Z3 *= matrix3D.Z3;
            R3 *= matrix3D.R3;

            X4 *= matrix3D.X4;
            Y4 *= matrix3D.Y4;
            Z4 *= matrix3D.Z4;
            R4 *= matrix3D.R4;
            return this;
        }


        public Matrix1D Multiply(Matrix1D mat)
        {
            mat.X = X1 * mat.X + X2 * mat.Y + X3 * mat.Z + X4 * mat.R;
            mat.Y = Y1 * mat.X + Y2 * mat.Y + Y3 * mat.Z + Y4 * mat.R;
            mat.Z = Z1 * mat.X + Z2 * mat.Y + Z3 * mat.Z + Z4 * mat.R;
            mat.R = R1 * mat.X + R2 * mat.Y + R3 * mat.Z + R4 * mat.R;
            return mat;
        }
    }
}
