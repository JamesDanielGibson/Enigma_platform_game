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
    public partial class SecondWindow : Window
    {
        #region Declarations

        System.Windows.Threading.DispatcherTimer timer;
        
        double Xvel = 4; 
        bool stMovLeft = false;
        bool stMovRight= false;
        bool stjump = false;
        
        public const double JS = 15;
        double F = JS;
        public const double G = 10;
        bool onFloor = false;

        #endregion

        #region Main methods

        public SecondWindow()
        {

            InitializeComponent();

            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.IsEnabled = true;
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

        #endregion



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
                        if (onFloor == true)
                        {
                            stjump = true;
                            onFloor = false;
                        }
                        break;

                    case Key.Q:
                        MainWindow mW = new MainWindow();
                        mW.Show();
                        this.Close();
                       
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


        #region Movement
        

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
            if (stjump == false)
            {
                if ((Canvas.GetTop(sprite) + sprite.ActualHeight > Canvas.GetTop(level))&& (Canvas.GetLeft(sprite)>= Canvas.GetLeft(level)|| Canvas.GetRight(sprite )>Canvas.GetLeft(level)))
                {
                    onFloor = true;
                }else if (Canvas.GetTop(sprite) + sprite.ActualHeight < can.ActualHeight-5)
                {
                    Canvas.SetTop(sprite, Canvas.GetTop(sprite) + G);
                }
                else
                {
                    onFloor = true;
                }
            }

        }

        private bool Onfloor()
        {
            return true;
        }

        private void jump(bool st)
        {
            if (st == true)
            {
                if (F > 0 )
                {
                    double nextY;
                    nextY = Canvas.GetTop(sprite) - F;
                    Canvas.SetTop(sprite, nextY);
                    F -= 1;
                }
                else
                {
                    F = JS;
                    stjump = false;
                }
            }
        }
        #endregion


      
    }
}
