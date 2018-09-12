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
        #region declarations
        System.Windows.Threading.DispatcherTimer timer;
        double Yvel = 10;
        double Xvel = 4; 
        bool stMovLeft = false;
        bool stMovRight= false;
        bool stjump = false;
        double F = -10;
        double G = 4;
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.IsEnabled = false;
            timer.Tick += dispatcherTimer_Tick;
            Xvel = 4;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            updatePlayer();
        }

        private void updatePlayer()
        {
            MovLeft(stMovLeft);
            MovRight(stMovRight);
            MovGrav();
            jump(stjump);
        }

       


        #region event handeling


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (can.Visibility == Visibility.Visible) {
                
                
                switch (e.Key)
                {
                    case Key.Left:
                        stMovLeft = true;
                        break;

                    case Key.Right:
                        stMovRight = true;
                        break; 

                    case Key.Space:
                        stjump = true;
                        break;

                    case Key.Q:
                        can.Visibility = Visibility.Visible;
                        btnStart.Visibility = Visibility.Hidden;
                        break;
                }
                
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (can.Visibility == Visibility.Visible)
            {
                double nextX;

                switch (e.Key)
                {
                    case Key.Left:
                        stMovLeft = false;
                        break;

                    case Key.Right:
                        stMovRight = false;
                        break;

                }

            }
        }
        #endregion


        #region movement
        private void MovLeft(bool st)
        {
            if (st == true)
            {
                double nextX;
                nextX = Canvas.GetLeft(sprite) - Xvel;
                Canvas.SetLeft(sprite, nextX);
                if (nextX < 0)
                {
                    Canvas.SetLeft(sprite, -4);
                }
            }
        }

        private void MovRight(bool st)
        {
            if (st == true)
            {
                double nextX;
                nextX = Canvas.GetLeft(sprite) + Xvel;
                Canvas.SetLeft(sprite, nextX);
                if (nextX + sprite.ActualWidth > can.ActualWidth)
                {
                    Canvas.SetLeft(sprite, can.ActualWidth - sprite.ActualWidth - 12);
                }
            }
        }

        private void MovGrav()
        {
            if(Canvas.GetBottom(sprite)<can.ActualHeight)
            {
                Canvas.SetTop(sprite, Canvas.GetTop(sprite) +G);
            }
        }

        private void jump(bool st)
        {
            if (st == true) { 
                double nextY;
                nextY = Canvas.GetTop(sprite) - F;
                Canvas.SetTop(sprite, nextY);
             }
            if(F>10)
            {
                stjump = false;
                F = -10;
            }
            else
            {
                F += 1;
            }
        }
        #endregion

        #region btnStart
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            can.Visibility = Visibility.Visible;
            btnStart.Visibility = Visibility.Hidden;
            timer.IsEnabled = true;
        }
        #endregion
      
    }
}
