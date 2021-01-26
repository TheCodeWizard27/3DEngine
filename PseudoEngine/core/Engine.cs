using Newtonsoft.Json;
using PseudoEngine.DrawApi;
using PseudoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Input;
using System.Windows.Threading;

namespace PseudoEngine.core
{
    public class Engine
    {
        public readonly List<Mesh> Meshes = new List<Mesh>();
        public Camera Camera = new Camera(800, 800)
        {
            Pos = new Vertex()
            {
                X = 20,
                Y = -360,
                Z = -7.2499999999999
            }
        };

        public DispatcherTimer Clock { get; private set; }
        public HashSet<Key> Keybuffer = new HashSet<Key>();

        public double YROT = 0;
        public bool PointDisplayEnabled = true;
        public bool WireframeDisplayEnabled = false;
        public bool ColorfullPolygonDisplayEnabled = false;

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
            var directory = Path.GetDirectoryName(
                AppContext.BaseDirectory
                );

            try
            {
                var loadedCam = JsonConvert.DeserializeObject<Camera>(File.ReadAllText($"{directory}/camera.json"));
                
                if(loadedCam != null)
                {
                    Camera = loadedCam;
                }
            }catch(Exception ex)
            {

            }

            var file = "/Graphics/teapot.obj";
            Meshes.Add(Mesh.CreateMeshByObj($"{directory}/{file}"));
        }

        public void Start()
        {
            Clock.Start();
            Console.WriteLine("Started Engine Loop");
        }
        public void Stop()
        {
            Clock.Stop();
            Console.WriteLine("Stopped Engine Loop");
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            var rnd = new Random(15);

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
                    // Static flip
                    var rotTest = Matrix4D.GetXRot((Math.PI * 160) / 180);
                    YROT += .0001;
                    var rotTest2 = Matrix4D.GetYRot((Math.PI * (YROT)) / 180);

                    var scaleTest = Matrix4D.GetScale(600 / 2, 600 / 2, 1);

                    var temp = face.Vertex1;

                    var translatedV1 = Matrix1D.From(mesh.Vertices[face.Vertex1]);
                    var translatedV2 = Matrix1D.From(mesh.Vertices[face.Vertex2]);
                    var translatedV3 = Matrix1D.From(mesh.Vertices[face.Vertex3]);

                    translatedV1 = translatedV1.Multiply(rotTest2);
                    translatedV2 = translatedV2.Multiply(rotTest2);
                    translatedV3 = translatedV3.Multiply(rotTest2);

                    
                    translatedV1 = translatedV1.Multiply(rotTest);
                    translatedV2 = translatedV2.Multiply(rotTest);
                    translatedV3 = translatedV3.Multiply(rotTest);
                    
                    /*
                    Console.WriteLine(translatedV1);
                    Console.WriteLine(rotTest);
                    */

                    translatedV1 = translatedV1.Multiply(scaleTest);
                    translatedV2 = translatedV2.Multiply(scaleTest);
                    translatedV3 = translatedV3.Multiply(scaleTest);

                    translatedV1 = translatedV1.Multiply(transLationMat);
                    translatedV2 = translatedV2.Multiply(transLationMat);
                    translatedV3 = translatedV3.Multiply(transLationMat);
                   
                    translatedV1 = translatedV1.Multiply(projectMat);
                    translatedV2 = translatedV2.Multiply(projectMat);
                    translatedV3 = translatedV3.Multiply(projectMat);

                    var resultV1 = Vertex.From(translatedV1);
                    var resultV2 = Vertex.From(translatedV2);
                    var resultV3 = Vertex.From(translatedV3);

                    if (translatedV1.Z != 0)
                    {
                        resultV1.X /= translatedV1.Z;
                        resultV1.Y /= translatedV1.Z;
                    }
                    if(translatedV2.Z != 0)
                    {
                        resultV2.X /= translatedV2.Z;
                        resultV2.Y /= translatedV2.Z;
                    }
                    if (translatedV3.Z != 0)
                    {
                        resultV3.X /= translatedV3.Z;
                        resultV3.Y /= translatedV3.Z;
                    }

                    resultV1.X += screenMid.X; resultV1.Y += screenMid.Y;
                    resultV2.X += screenMid.X; resultV2.Y += screenMid.Y;
                    resultV3.X += screenMid.X; resultV3.Y += screenMid.Y;

                    if (resultV1.Z <= 0.1 || resultV2.Z <= 0.1 || resultV3.Z <= 0.1) continue;

                    /*
                    g.DrawString($"{Math.Round(test1.X, 3)},{Math.Round(test1.Y, 3)},{Math.Round(test1.Z, 3)}", new Font(FontFamily.GenericSansSerif, 14), Brushes.Cyan, (float)resultV1.X, (float)resultV1.Y);
                    g.DrawString($"{Math.Round(test2.X, 3)},{Math.Round(test2.Y, 3)},{Math.Round(test2.Z, 3)}", new Font(FontFamily.GenericSansSerif, 14), Brushes.Cyan, (float)resultV2.X, (float)resultV2.Y);
                    g.DrawString($"{Math.Round(test3.X, 3)},{Math.Round(test3.Y, 3)},{Math.Round(test3.Z, 3)}", new Font(FontFamily.GenericSansSerif, 14), Brushes.Cyan, (float)resultV3.X, (float)resultV3.Y);
                    */
                    
                    if(ColorfullPolygonDisplayEnabled)
                    {
                        var color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255), 255);

                        g.FillPolygon(
                            new SolidBrush(color), new PointF[]{
                        new PointF((float)resultV1.X, (float)resultV1.Y),
                        new PointF((float)resultV2.X, (float)resultV2.Y),
                        new PointF((float)resultV3.X, (float)resultV3.Y)
                        });
                    }

                    var v = resultV2.Clone().Subtract(resultV1);
                    var w = resultV3.Clone().Subtract(resultV1);
                    var n = new Vertex()
                    {
                        X = (v.Y * w.Z) - (v.Z * w.Y),
                        Y = (v.Z * w.X) - (v.X * w.Z),
                        Z = (v.X * w.Y) - (v.Y * w.X)
                    };

                    if(PointDisplayEnabled)
                    {
                        SetPixel(bufferedImage.Bitmap, (int)resultV1.X, (int)resultV1.Y);
                        SetPixel(bufferedImage.Bitmap, (int)resultV1.X, (int)resultV1.Y);
                        SetPixel(bufferedImage.Bitmap, (int)resultV1.X, (int)resultV1.Y);
                    }

                    if(WireframeDisplayEnabled)
                    {
                        g.DrawLine(whitePen, (float)resultV1.X, (float)resultV1.Y, (float)resultV2.X, (float)resultV2.Y);
                        g.DrawLine(whitePen, (float)resultV2.X, (float)resultV2.Y, (float)resultV3.X, (float)resultV3.Y);
                        g.DrawLine(whitePen, (float)resultV3.X, (float)resultV3.Y, (float)resultV1.X, (float)resultV1.Y);
                    }

                    /*
                    g.DrawPolygon(
                        new Pen(Color.FromArgb(rnd.Next(0,255),rnd.Next(0,255),rnd.Next(0,255), 255)), new Point[]{
                        new Point((int)translatedV1.X, (int)translatedV1.Y),
                        new Point((int)translatedV2.X, (int)translatedV2.Y),
                        new Point((int)translatedV3.X, (int)translatedV3.Y)
                    });
                    */
                }
            }
            Console.WriteLine($"{Camera.Pos.X},{Camera.Pos.Y},{Camera.Pos.Z}");

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
