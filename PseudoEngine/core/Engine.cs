using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PseudoEngine.core
{
    public class Engine
    {

        public DispatcherTimer Clock { get; private set; }

        public Engine(int fps)
        {
            Clock = new DispatcherTimer();
            Clock.Interval = new TimeSpan(1000 / fps);
            Clock.Tick += (_, __) => OnUpdate?.Invoke();
        }

        public delegate void Update();
        public event Update OnUpdate;

        public void Start()
        {
            Clock.Start();
        }
        public void Stop()
        {
            Clock.Stop();
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(Color.Black, 1), 0, 0, 100, 100);
        }

    }
}
