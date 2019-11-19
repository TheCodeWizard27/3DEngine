using PseudoEngine.core;
using System.Collections.Generic;
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
            InitializeComponent();
            _win = new WindowInteropHelper(GetWindow(this));
            Left = 0 - SystemParameters.ResizeFrameVerticalBorderWidth - SystemParameters.FixedFrameVerticalBorderWidth;

            _engine = new Engine(60);
            _engine.OnUpdate += Engine_OnUpdate;
            _engine.Start();
        }

        private void Engine_OnUpdate()
        {
            using (var g = System.Drawing.Graphics.FromHwnd(_win.Handle))
            {
                _engine.Draw(g);
            }
            _engine.Clear();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _engine.keybuffer.Add(e.Key);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
