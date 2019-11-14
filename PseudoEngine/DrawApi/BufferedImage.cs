using System.Drawing;

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

            using (var g = System.Drawing.Graphics.FromImage(Bitmap))
            {
                g.FillRectangle(new SolidBrush(ClearColor), 0, 0, Width, Height);
            }
        }

        public System.Drawing.Graphics GetGraphics()
        {
            return System.Drawing.Graphics.FromImage(Bitmap);
        }

        public void Clear(System.Drawing.Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(ClearColor), 0, 0, Width, Height);
        }

        public void Clear()
        {
            using (var g = System.Drawing.Graphics.FromImage(Bitmap))
            {
                g.FillRectangle(new SolidBrush(ClearColor), 0, 0, Width, Height);
            }
        }

    }
}
