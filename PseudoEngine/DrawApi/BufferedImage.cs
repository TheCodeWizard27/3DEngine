using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.DrawApi
{
    public class BufferedImage
    {

        public Bitmap Bitmap { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Color ClearColor { get; set; } = Color.Black;


        public BufferedImage(int width, int height)
        {
            Width = width;
            Height = height;
            Bitmap = new Bitmap(Width, Height);

            using (var g = Graphics.FromImage(Bitmap))
            {
                g.FillRectangle(new SolidBrush(ClearColor), 0, 0, Width, Height);
            }
        }

        public Graphics GetGraphics()
        {
            return Graphics.FromImage(Bitmap);
        }

        public void Clear(Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(ClearColor), 0, 0, Width, Height);
        }

        public void Clear()
        {
            using (var g = Graphics.FromImage(Bitmap))
            {
                g.FillRectangle(new SolidBrush(ClearColor), 0, 0, Width, Height);
            }
        }

    }
}
