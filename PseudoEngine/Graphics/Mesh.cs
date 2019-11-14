using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Mesh
    {
        public Polygon[] Polygons { get; private set; }

        public Mesh(int polygonCount)
        {
            Polygons = new Polygon[polygonCount];
        }
        public Mesh(Polygon[] polygons)
        {
            Polygons = polygons;
        }

    }
}
