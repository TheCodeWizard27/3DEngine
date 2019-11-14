using PseudoEngine.core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            using (var g = Graphics.FromHwnd(_win.Handle))
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
