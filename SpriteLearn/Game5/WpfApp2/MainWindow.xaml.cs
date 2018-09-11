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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer;
        double Yvel = 2;
        double Xvel = 4;
        bool left;
        bool right;
        bool jump;
        int xDir = 4;
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.IsEnabled = true;
            timer.Tick += dispatcherTimer_Tick;
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            updatePlayer();
        }

        private void updatePlayer()
        {

            double nextX = Canvas.GetLeft(sprite) + Xvel;
            
           
            //double nextY = Canvas.GetTop(sprite) + Yvel;
            //Canvas.SetTop(sprite, nextY);
            //if (nextY < 0 || nextY + sprite.ActualHeight > can.ActualHeight && Yvel > 0)
            //{
            //    Yvel = -Yvel;
            //}
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double nextX;
            
            switch (e.Key)
            {
                case Key.Left:
                    Xvel = 4;
                    nextX = Canvas.GetLeft(sprite) - Xvel;
                    Canvas.SetLeft(sprite, nextX);
                    if (nextX < 0 || nextX + sprite.ActualWidth > can.ActualWidth && Xvel > 0)
                    {

                        Xvel *= -1;
                        //MessageBox.Show("");
                    }
                    break;
                case Key.Right:
                    Xvel = 4;
                    nextX = Canvas.GetLeft(sprite) + Xvel;
                    Canvas.SetLeft(sprite, nextX);
                    if (nextX < 0 || nextX + sprite.ActualWidth > can.ActualWidth && Xvel > 0)
                    {
                        
                        Xvel  *=-1;
                        
                    }
                    break;
            }
        }
    }
}
