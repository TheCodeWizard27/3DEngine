using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    class Matrix
    {
       
        Vertice[,] matrix;
        public Matrix(Mesh mesh)
        {
            matrix = new Vertice[mesh.meshPolygons.Length, 3];
        }
    }
}
