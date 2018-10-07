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
using System.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private Platforms x;
        private pEnemyPlayer enemy;
        #region Declarations

        System.Windows.Threading.DispatcherTimer timer;

        
        double Xvel = 0.4; 
        bool stMovLeft = false;
        bool stMovRight= false;
        bool stjump = false;
        
        public const double JS = 15;
        double F = JS;
        public const double G = 3;
        bool onFloor = false;
        //List<Platforms> Images = new List<Platforms>();
        List<pEnemyPlayer> enemies = new List<pEnemyPlayer>();

        #endregion

        #region Main methods

        public SecondWindow()
        {
            
            InitializeComponent();

            Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            Arrange(new Rect(0, 0, DesiredSize.Width, DesiredSize.Height));

            //MessageBox.Show(Convert.ToString(can.ActualHeight));
            x = new Platforms(can, 1200, 700, 10); //For some reason Window.Actual Height is 0 100 and 200 are Hardcoded values that need to be remove in the end
            Random randomed = new Random();
            int intCh = randomed.Next(0,4);

            for (int i = 0; i < 4; i++)
            {
                enemy = new pEnemyPlayer(can, x.rect, intCh, randomed);
                enemies.Add(enemy);
            }
           



            timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(0.5);
            timer.IsEnabled = true;
            timer.Tick += dispatcherTimer_Tick;
            Xvel = 4;
        }

            


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            updatePlayer();
            updateEnemy();
            update();
            
        }
        #region Update
        private void update()
        {

            if (x.KeyDetection(can, ref sprite))
            {
                timer.IsEnabled = false;
                MessageBox.Show("Congratulations you have completed the level... Prepare to die in next one!!!!!");
                SecondWindow mW = new SecondWindow();
                Close();

                mW.Show();

                //#lol
            }
            else if (x.BombDetection(can, ref sprite))
            {
                timer.IsEnabled = false;
                MessageBox.Show("You died... ");

                SecondWindow mW = new SecondWindow();
                mW.Show();
                Close();
            }

        }
        #endregion

        private void updateEnemy()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].EnemyMove();
            }
            
        }



        private void updatePlayer()
        {

            MovLeft(stMovLeft);
            //MovGrav();
            MovRight(stMovRight);// x.IsOn(ref sprite);
            //MovGrav();
            jump(stjump);
            MovGrav();
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
                        Close();                
                        break;

                    case Key.S: SecondWindow mw = new SecondWindow(); mw.Show(); this.Close(); break;

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
                //Console.WriteLine("bottom" + Canvas.GetBottom(sprite));
                //Console.WriteLine("right" +Canvas.GetRight(sprite));
                if (nextX + sprite.ActualWidth > can.ActualWidth)
                {
                    Canvas.SetLeft(sprite,  1200 - sprite.ActualWidth -30);
                }
            }
        }
        
        private void MovGrav()
        {

            //if (stjump == true) {
            //    if (x.Touch(ref sprite))
            //    {
            //        stjump = false;
            //        onFloor = false;
            //    }
            //}
            if (stjump == false)
            {
                //if ((Canvas.GetTop(sprite) + sprite.ActualHeight > Canvas.GetTop(level)) && (Canvas.GetLeft(sprite) >= Canvas.GetLeft(level) || Canvas.GetRight(sprite) > Canvas.GetLeft(level)))
                //{
                //    onFloor = true;

                //}
                //MessageBox.Show(Convert.ToString(Canvas.GetBottom(sprite)));
                //Console.WriteLine(Canvas.GetBottom(sprite));

                if ((x.IsOn(ref sprite) || ((Canvas.GetTop(sprite) - ActualHeight <= 650) && Canvas.GetTop(sprite) - ActualHeight >= 640))) //&& ((Canvas.GetTop(sprite) - ActualHeight >= 700) && Canvas.GetTop(sprite) - ActualHeight <= 690)  ) //Works exactly the same as prev except need to work out how to say any image
                {
                    onFloor = true;
                }

                //else if (Canvas.GetTop(sprite) + sprite.ActualHeight < can.ActualHeight - 5)
                //{
                //    Canvas.SetTop(sprite, Canvas.GetTop(sprite) + G);
                //    onFloor = true;
                //}
                else
                {
                    Canvas.SetTop(sprite, Canvas.GetTop(sprite) + G);
                    onFloor = false;
                }
            }

        }

        private bool Onfloor()
        {

            return true;
        }

        private void jump(bool st)
        {
            if (stjump && !onFloor)
            {
                if (st == true)
                {
                    if (F > 0)
                    {
                        double nextY;
                        nextY = Canvas.GetTop(sprite) - F;
                        Canvas.SetTop(sprite, nextY);
                        F -= 1;
                        onFloor = false;
                    }
                    else
                    {
                        F = JS;
                        stjump = false;
                    }
                }
            }
        }
        #endregion


      
    }
}
