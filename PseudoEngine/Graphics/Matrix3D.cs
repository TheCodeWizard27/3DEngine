using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    class Matrix3D
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }

        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }

        public double Z1 { get; set; }
        public double Z2 { get; set; }
        public double Z3 { get; set; }

        public Matrix3D(double x1, double x2, double x3, double y1, double y2, double y3, double z1, double z2, double z3)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.X3 = x3;

            this.Y1 = y1;
            this.Y2 = y2;
            this.Y3 = y3;

            this.Z1 = z1;
            this.Z2 = z2;
            this.Z3 = z3;
        }

        public Matrix3D Multiply3D(Matrix3D matrix3D)
        {
            X1 *= matrix3D.X1;
            X2 *= matrix3D.Y1;
            X3 *= matrix3D.Z1;

            Y1 *= matrix3D.X2;
            Y2 *= matrix3D.Y2;
            Y3 *= matrix3D.Z2;

            Z1 *= matrix3D.X3;
            Z2 *= matrix3D.Y3;
            Z3 *= matrix3D.Z3;
            return this;
        }


        public Matrix2D Multiply2D(Matrix2D mat)
        {
            mat.X = X1 * mat.X + X2 * mat.Y + X3 * mat.Z;
            mat.Y = Y1 * mat.X + Y2 * mat.Y + Y3 * mat.Z;
            mat.Z = Z1 * mat.X + Z2 * mat.Y + Z3 * mat.Z;
            return mat;
        }
    }
}
