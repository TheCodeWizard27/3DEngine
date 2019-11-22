using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.Graphics
{
    public class Mesh
    {
        public Vertex[] Vertices { get; set; }
        public Polygon[] Faces { get; set; }

        public Mesh(int VertexCount, int FaceCount)
        {
            Faces = new Polygon[FaceCount];
            Vertices = new Vertex[VertexCount];
        }
        public Mesh(Vertex[] vertices, Polygon[] faces)
        {
            Vertices = vertices;
            Faces = faces;
        }

    }
}
