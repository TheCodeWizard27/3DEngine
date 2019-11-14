using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    class Mesh
    {
        public Polygon[] meshPolygons;
        public Mesh(Polygon[] polygons)
        {
            this.meshPolygons = polygons;
        }
    }
}
