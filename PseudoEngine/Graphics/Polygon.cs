using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Polygon
    {
        public int Vertex1 { get; set; }
        public int Vertex2 { get; set; }
        public int Vertex3 { get; set; }

        public Polygon(int vertex1, int vertex2, int vertex3 )
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }

    }
}
