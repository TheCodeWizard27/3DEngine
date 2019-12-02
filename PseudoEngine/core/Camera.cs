using PseudoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoEngine.core
{
    public class Camera
    {

        #region Properties

        public Vertex Pos { get; set; } = new Vertex(0, 0, -2);
        public Vertex Rot { get; set; } = new Vertex(0, 0, 0);

        public double FovAngle { get; set; } = 90;
        public double ZNear { get; set; } = 1;
        public double ZFar { get; set; } = 1000;
        public double Ratio { get; set; } = 1;

        #endregion

        public Camera(double screenWidth, double screenHeight)
        {
            Ratio = screenWidth / screenHeight;
        }

        public Matrix4D GetTranslationMatrix()
        {
            /*var temp = new Matrix4D(
                    800/2, 0, 0, -Pos.X,
                    0, 600/2, 0, -Pos.Y,
                    0, 0, 1, -Pos.Z,
                    0, 0, 0, 1
                );*/
            return Matrix4D.GetTranslation(Pos.Clone().Reverse());

        }

        public Matrix4D GetProjectionMatrix()
        {
            var distFactor = 1 / Math.Tanh(FovAngle * 0.5 / 180 * 3.14159);

            return new Matrix4D(
                    Ratio*distFactor, 0, 0, 0,
                    0, distFactor, 0, 0,
                    0, 0, ZFar / (ZFar-ZNear), (-ZFar*ZNear)/(ZFar-ZNear),
                    0, 0, 0, 1
                );
        }

    }
}
