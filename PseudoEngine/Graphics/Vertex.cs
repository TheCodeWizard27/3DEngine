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

        public void Add(double x, double y, double z)
        {
            X += x;
            Y += y;
            Z += z;
        }
        public void Add(Vertex vertex)
        {
            Add(vertex.X, vertex.Y, vertex.Z);
        }
        public void Subtract(double x, double y, double z)
        {
            X -= x;
            Y -= y;
            Z -= z;
        }
        public void Subtract(Vertex vertex)
        {
            Subtract(vertex.X, vertex.Y, vertex.Z);
        }
        public void Multiply(double x, double y, double z)
        {
            X *= x;
            Y *= y;
            Z *= z;
        }
        public void Multiply(Vertex vertex)
        {
            Multiply(vertex.X, vertex.Y, vertex.Z);
        }

        public Vertex Clone()
        {
            return new Vertex(X, Y, Z);
        }

        #endregion

    }
}
