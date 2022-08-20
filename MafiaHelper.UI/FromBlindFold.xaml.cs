using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MafiaHelper
{
    /// <summary>
    /// Interaction logic for FromBlindFold.xaml
    /// </summary>
    public partial class WindowBlindFold : Window
    {
        public WindowBlindFold()
        {
            InitializeComponent();
        }
        private bool _inStateChange;
        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Maximized && !_inStateChange)
            {
                _inStateChange = true;
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                ResizeMode = ResizeMode.NoResize;
                _inStateChange = false;
            }
            base.OnStateChanged(e);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int nWidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int nHieght = (int)System.Windows.SystemParameters.PrimaryScreenHeight;

            this.LayoutTransform = new ScaleTransform(nWidth*2 , nHieght*2 );

            this.WindowStartupLocation = WindowStartupLocation.Manual;
        }
    }
}
