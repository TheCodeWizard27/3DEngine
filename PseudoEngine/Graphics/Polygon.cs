using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Polygon
    {
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }
        public Vertex Vertex3 { get; set; }

        public Polygon(Vertex vertex1, Vertex vertex2, Vertex vertex3 )
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }

    }
}
