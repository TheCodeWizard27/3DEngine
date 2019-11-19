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
            Init();
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
        }
        public void Stop()
        {
            Clock.Stop();
            Console.WriteLine("Started Engine Loop");
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            var screenMid = new Vertex(800 / 2, 600 / 2, 0);
            var bufferedImage = new BufferedImage(800,600);
            var g = bufferedImage.GetGraphics();

            bufferedImage.Bitmap.SetPixel((int)screenMid.X, (int)screenMid.Y, Color.Cyan);
            g.DrawRectangle(new Pen(Color.Cyan), 0, 0, 800-1, 600-1);

            foreach(var mesh in Meshes)
            {
                foreach(var polygon in mesh.Polygons)
                {
                    foreach (var vertex in new Vertex[] {polygon.Vertex1, polygon.Vertex2, polygon.Vertex3})
                    {
                        var temp = vertex.Clone().Multiply(800/2, 600/2, 0).Add(screenMid);
                        bufferedImage.Bitmap.SetPixel((int)temp.X, (int)temp.Y, Color.White);
                    }
                }
            }

            graphics.DrawImage(bufferedImage.Bitmap,0,0);
            Console.WriteLine($"<{DateTime.Now}> Finished Drawing");
        }

        public void Clear()
        {
            keybuffer.Clear();
        }

    }
}
