using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    class Polygon
    {
        public Vertice verticeX;
        public Vertice verticeY;
        public Vertice verticeZ;
        public Polygon(Vertice verticeX, Vertice verticeY, Vertice verticeZ )
        {
            this.verticeX = verticeX;
            this.verticeY = verticeY;
            this.verticeZ = verticeZ;
        }
    }
}
