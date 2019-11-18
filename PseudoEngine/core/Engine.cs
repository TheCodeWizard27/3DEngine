using PseudoEngine.DrawApi;
using PseudoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;
using System.Windows.Threading;

namespace PseudoEngine.core
{
    public class Engine
    {
        private readonly List<Mesh> Meshes = new List<Mesh>();

        public DispatcherTimer Clock { get; private set; }
        public HashSet<Key> keybuffer = new HashSet<Key>();

        public delegate void Update();
        public event Update OnUpdate;

        public Engine(int fps)
        {
            Clock = new DispatcherTimer();
            Clock.Interval = new TimeSpan(1000 / fps);
            Clock.Tick += (_, __) => OnUpdate?.Invoke();
        }

        public void Init()
        {
            Meshes.Add(new Mesh(12)
            {
                Polygons = new Polygon[] {
                    // Front Side Pane
                    new Polygon(new Vertex(0.5, 0.5, 0.5), new Vertex(0.5,-0.5,0.5), new Vertex(-0.5, -0.5, 0.5)),
                    new Polygon(new Vertex(-0.5, 0.5, 0.5), new Vertex(0.5, 0.5, 0.5), new Vertex(-0.5, -0.5, 0.5)),
                    // Left Side Pane
                    new Polygon(new Vertex(-0.5, 0.5, 0.5), new Vertex(-0.5, -0.5, 0.5), new Vertex(-0.5, -0.5, -0.5)),
                    new Polygon(new Vertex(-0.5, 0.5, 0.5), new Vertex(-0.5, 0.5, -0.5), new Vertex(-0.5, -0.5, -0.5)),
                    // Right Side Pane
                    new Polygon(new Vertex(0.5, 0.5, 0.5), new Vertex(0.5, -0.5, 0.5), new Vertex(0.5, -0.5, -0.5)),
                    new Polygon(new Vertex(0.5, 0.5, 0.5), new Vertex(0.5, 0.5, -0.5), new Vertex(0.5, -0.5, -0.5)),
                    // Bottom Side Pane
                    new Polygon(new Vertex(-0.5, -0.5, 0.5), new Vertex(0.5, -0.5, 0.5), new Vertex(-0.5, -0.5, -0.5)),
                    new Polygon(new Vertex(-0.5, -0.5, -0.5), new Vertex(0.5, -0.5, -0.5), new Vertex(0.5, -0.5, 0.5)),
                    // Top Side Pane
                    new Polygon(new Vertex(0.5, 0.5, 0.5), new Vertex(0.5, 0.5, -0.5), new Vertex(-0.5, 0.5, -0.5)),
                    new Polygon(new Vertex(0.5, 0.5, 0.5), new Vertex(-0.5, 0.5, 0.5), new Vertex(-0.5, 0.5, -0.5)),
                    // Back Side Pane
                    new Polygon(new Vertex(0.5, 0.5, -0.5), new Vertex(-0.5, 0.5, -0.5), new Vertex(-0.5, -0.5, -0.5)),
                    new Polygon(new Vertex(0.5, 0.5, -0.5), new Vertex(0.5, -0.5, 0.5), new Vertex(-0.5, 0.5, -0.5))
                }
            });
        }

        public void Start()
        {
            Clock.Start();
            Console.WriteLine("Started Engine Loop");
            var idMatrix = new Matrix(new double[,] {
                {2,0,0},
                {0,1,0},
                {0,0,0.6666666666666667}
            });
            var someVector = new Matrix(new double[,] {
                {1},
                {2},
                {3}
            });
            idMatrix.Multiply(someVector);
            Console.WriteLine("Success");
        }
        public void Stop()
        {
            Clock.Stop();
            Console.WriteLine("Started Engine Loop");
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            var bufferedImage = new BufferedImage(800,600);

            /*foreach(var mesh in Meshes)
            {
                foreach(var polygon in mesh.Polygons)
                {
                    Vertex tmpVertex;

                    foreach (var vertex in new Vertex[] {polygon.Vertex1, polygon.Vertex2, polygon.Vertex3})
                    {
                        
                    }
                }
            }*/

            graphics.DrawImage(bufferedImage.Bitmap,0,0);
            Console.WriteLine($"<{DateTime.Now}> Finished Drawing");
        }

        public void Clear()
        {
            keybuffer.Clear();
        }

    }
}
