using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Vertex
    {
        public double x { get; private set; }
        public double y { get; private set; }
        public double z { get; private set; }

        public Vertex(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
