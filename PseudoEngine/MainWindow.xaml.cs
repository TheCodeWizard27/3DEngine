using PseudoEngine.core;
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
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
