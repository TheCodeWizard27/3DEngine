using PseudoEngine.DrawApi;
using System;
using System.Drawing;
using System.Windows.Threading;

namespace PseudoEngine.core
{
    public class Engine
    {

        public DispatcherTimer Clock { get; private set; }

        public Engine(int fps)
        {
            //DebugConsole.CreateConsole();

            Clock = new DispatcherTimer();
            Clock.Interval = new TimeSpan(1000 / fps);
            Clock.Tick += (_, __) => OnUpdate?.Invoke();
            Console.WriteLine("Works");
        }

        public delegate void Update();
        public event Update OnUpdate;

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
            var bufferedImage = new BufferedImage(800,600);
            graphics.DrawImage(bufferedImage.Bitmap,0,0);
            Console.WriteLine($"<{DateTime.Now}> Finished Drawing");
        }

    }
}
