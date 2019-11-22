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
        public readonly List<Mesh> Meshes = new List<Mesh>();
        public readonly Camera Camera = new Camera(800, 600);

        public DispatcherTimer Clock { get; private set; }
        public HashSet<Key> Keybuffer = new HashSet<Key>();

        public delegate void Update();
        public event Update OnUpdate;

        public Engine(int fps)
        {
            Clock = new DispatcherTimer();
            Clock.Interval = new TimeSpan(1000 / fps);
            Clock.Tick += (_, __) => OnUpdate?.Invoke();

            Init();
        }

        public void Init()
        {
            Meshes.Add(new Mesh(
                vertices: new Vertex[]
                {
                    new Vertex(-0.5, -0.5, -0.5), new Vertex(-0.5, 0.5, -0.5),
                    new Vertex(0.5, -0.5, -0.5), new Vertex(0.5, 0.5, -0.5),
                    new Vertex(-0.5, -0.5, 0.5), new Vertex(-0.5, 0.5, 0.5),
                    new Vertex(0.5, -0.5, 0.5), new Vertex(0.5, 0.5, 0.5)
                },
                faces: new Polygon[]
                {
                    // Front Faces
                    new Polygon(0, 1, 3), new Polygon(3, 2, 0),
                    // Back Faces
                    new Polygon(4, 5, 7), new Polygon(7, 6, 4),
                    // Left Faces
                    new Polygon(4, 5, 1), new Polygon(1, 0, 4),
                    // Right Faces
                    new Polygon(2, 3, 7), new Polygon(7, 6, 2),
                    // Bottom Faces
                    new Polygon(0, 4, 6), new Polygon(6, 2, 0),
                    // Top Faces
                    new Polygon(1, 5, 7), new Polygon(7, 3, 1)
                }
                ));
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
            var whitePen = new Pen(Color.White, 1);
            var screenMid = new Vertex(800 / 2, 600 / 2, 0);
            var projectMat = Camera.GetProjectionMatrix();
            var transLationMat = Camera.GetTranslationMatrix();

            var bufferedImage = new BufferedImage(800, 600);
            var g = bufferedImage.GetGraphics();

            bufferedImage.Bitmap.SetPixel((int)screenMid.X, (int)screenMid.Y, Color.Cyan);
            g.DrawRectangle(new Pen(Color.Cyan), 0, 0, 800 - 1, 600 - 1);

            foreach (var mesh in Meshes)
            {
                foreach(var face in mesh.Faces)
                {
                    var translatedV1 = Matrix1D.From(mesh.Vertices[face.Vertex1]).Multiply(transLationMat);
                    var translatedV2 = Matrix1D.From(mesh.Vertices[face.Vertex2]).Multiply(transLationMat);
                    var translatedV3 = Matrix1D.From(mesh.Vertices[face.Vertex3]).Multiply(transLationMat);

                    translatedV1.Multiply(projectMat);
                    translatedV2.Multiply(projectMat);
                    translatedV3.Multiply(projectMat);

                    if(translatedV1.Z != 0)
                    {
                        translatedV1.X /= translatedV1.Z;
                        translatedV1.Y /= translatedV1.Z;
                    }
                    if(translatedV2.Z != 0)
                    {
                        translatedV2.X /= translatedV2.Z;
                        translatedV2.Y /= translatedV2.Z;
                    }
                    if (translatedV3.Z != 0)
                    {
                        translatedV3.X /= translatedV3.Z;
                        translatedV3.Y /= translatedV3.Z;
                    }

                    translatedV1.X += screenMid.X; translatedV1.Y += screenMid.Y;
                    translatedV2.X += screenMid.X; translatedV2.Y += screenMid.Y;
                    translatedV3.X += screenMid.X; translatedV3.Y += screenMid.Y;

                    try
                    {
                        g.DrawLine(whitePen, (float)translatedV1.X, (float)translatedV1.Y, (float)translatedV2.X, (float)translatedV2.Y);
                        g.DrawLine(whitePen, (float)translatedV2.X, (float)translatedV2.Y, (float)translatedV3.X, (float)translatedV3.Y);
                        g.DrawLine(whitePen, (float)translatedV3.X, (float)translatedV3.Y, (float)translatedV1.X, (float)translatedV1.Y);
                    }
                    catch (Exception)
                    {

                    }

                    /*
                    SetPixel(bufferedImage.Bitmap, (int)translatedV1.X, (int)translatedV1.Y);
                    SetPixel(bufferedImage.Bitmap, (int)translatedV2.X, (int)translatedV2.Y);
                    SetPixel(bufferedImage.Bitmap, (int)translatedV3.X, (int)translatedV3.Y);
                    */
                }
            }

            g.Dispose();
            graphics.DrawImage(bufferedImage.Bitmap, 0, 0);
        }

        public void SetPixel(Bitmap bitmap, int x, int y)
        {
            if (x < 0 || y < 0 || x > 799 || y > 599) return;
            bitmap.SetPixel(x, y, Color.White);
        }

        public void Clear()
        {
            Keybuffer.Clear();
        }

    }
}
