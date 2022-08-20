using MafiaHelper.Services.Services;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MafiaHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            App.Current.Shutdown();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void BtnMute_Click(object sender, RoutedEventArgs e)
        {
            Services.AudioManagementService.Mute();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = true;
        }


        private void BtnUnMute_Click(object sender, RoutedEventArgs e)
        {
            Services.AudioManagementService.UnMute();
        }

        WindowBlindFold blindFoldWindow;
        public void RenewBlindfFold()
        {
            //if blind fold already close it
            if (blindFoldWindow != null)
                blindFoldWindow.Close();

            //renew the blind-fold
            blindFoldWindow = new WindowBlindFold();
        }

        private void BtnGoToNight_Click(object sender, RoutedEventArgs e)
        {
            RenewBlindfFold();
            blindFoldWindow.Show();
        }


        private void BtnGoToDay_Click(object sender, RoutedEventArgs e)
        {
            RenewBlindfFold();
        }
    }
}
