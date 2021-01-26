using PseudoEngine.core;
using PseudoEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace PseudoEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Engine _engine;
        private WindowInteropHelper _win;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                _win = new WindowInteropHelper(GetWindow(this));
                Left = 0 - SystemParameters.ResizeFrameVerticalBorderWidth - SystemParameters.FixedFrameVerticalBorderWidth;

                _engine = new Engine(60);
                _engine.OnUpdate += Engine_OnUpdate;
                _engine.Start();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }

        private void Engine_OnUpdate()
        {
            //Console.WriteLine("[" + string.Join(",",_engine.Keybuffer.ToList()) + "]");
            foreach(var key in _engine.Keybuffer)
            {
                switch(key)
                {
                    case Key.Q:
                        _engine.YROT -= 5;
                        break;
                    case Key.E:
                        _engine.YROT += 5;
                        break;
                    case Key.W:
                        _engine.Camera.Pos.Z += 0.05;
                        break;
                    case Key.S:
                        _engine.Camera.Pos.Z -= 0.05;
                        break;
                    case Key.A:
                        _engine.Camera.Pos.X -= 10;
                        break;
                    case Key.D:
                        _engine.Camera.Pos.X += 10;
                        break;
                    case Key.LeftShift: case Key.RightShift:
                        _engine.Camera.Pos.Y += 10;
                        break;
                    case Key.Space:
                        _engine.Camera.Pos.Y -= 10;
                        break;
                    case Key.D1:
                        _engine.PointDisplayEnabled = true;
                        _engine.WireframeDisplayEnabled = false;
                        _engine.ColorfullPolygonDisplayEnabled = false;
                        break;
                    case Key.D2:
                        _engine.PointDisplayEnabled = false;
                        _engine.WireframeDisplayEnabled = true;
                        _engine.ColorfullPolygonDisplayEnabled = false;
                        break;
                    case Key.D3:
                        _engine.PointDisplayEnabled = false;
                        _engine.WireframeDisplayEnabled = false;
                        _engine.ColorfullPolygonDisplayEnabled = true;
                        break;
                }
            }

            using (var g = System.Drawing.Graphics.FromHwnd(_win.Handle))
            {
                _engine.Draw(g);
            }
            //_engine.Clear();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _engine.Keybuffer.Add(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            _engine.Keybuffer.Remove(e.Key);
        }
    }
}
