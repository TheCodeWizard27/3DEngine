using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        #region Constructers

        public Vertex(double x, double y, double z)
        {
            this.SetPos(x, y, z);
        }
        public Vertex(Vertex vertex)
        {
            SetPos(vertex);
        }
        public Vertex() { }

        #endregion

        #region Public Methods

        public void SetPos(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public void SetPos(Vertex vertex)
        {
            SetPos(vertex.X, vertex.Y, vertex.Z);
        }

        public Vertex Add(double x, double y, double z)
        {
            X += x;
            Y += y;
            Z += z;
            return this;
        }
        public Vertex Add(Vertex vertex)
        {
            return Add(vertex.X, vertex.Y, vertex.Z);
        }
        public Vertex Subtract(double x, double y, double z)
        {
            X -= x;
            Y -= y;
            Z -= z;
            return this;
        }
        public Vertex Subtract(Vertex vertex)
        {
            return Subtract(vertex.X, vertex.Y, vertex.Z);
        }
        public Vertex Multiply(double x, double y, double z)
        {
            X *= x;
            Y *= y;
            Z *= z;
            return this;
        }
        public Vertex Multiply(Vertex vertex)
        {
            return Multiply(vertex.X, vertex.Y, vertex.Z);
        }

        public Vertex Clone()
        {
            return new Vertex(X, Y, Z);
        }

        #endregion

    }
}
