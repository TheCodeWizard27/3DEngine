﻿using System;
using System.Collections.Generic;
using System.IO;
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

        public static Mesh CreateMeshByObj(string path)
        {
            using (var sr = File.OpenText(path))
            {
                string line;
                var readVertices = new List<Vertex>();
                var readFaces = new List<Polygon>();

                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "") continue;

                    if (line[0] == 'v')
                    {
                        var items = line.Split(' ');
                        var v = new Vertex(
                            float.Parse(items[1]),
                            float.Parse(items[2]),
                            float.Parse(items[3])
                        );
                        readVertices.Add(v);
                    }
                    else if (line[0] == 'f')
                    {
                        var items = line.Replace("/","").Split(' ');
                        var p = new Polygon(
                            int.Parse(items[1]) - 1,
                            int.Parse(items[2]) - 1,
                            int.Parse(items[3]) - 1
                        );
                        readFaces.Add(p);
                    }
                }

                return new Mesh(readVertices.ToArray(), readFaces.ToArray());
            }
        }
    }
}
