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
using System.IO;

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
        public string username;
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
            //StreamWriter passed = new StreamWriter("J:\\Passed.txt");
            //passed.Close();
            StreamReader passes = new StreamReader(/*"J:\\*/"Passed.txt");
            string pss = passes.ReadLine();
            passes.Close();
            lblSuccess.Content = "Level:  " +pss;

            //StreamWriter deathst = new StreamWriter("J:\\Deaths.txt");
            //deathst.Close();
            StreamReader deaths = new StreamReader(/*"J:\\Deaths.txt"*/"Deaths.txt" );
            deaths.ReadLine();
            string dth = deaths.ReadLine();

            deaths.Close();
            lblDeaths.Content = ("Deaths: " + dth);


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
                Success x = new Success(username);
                SecondWindow mW = new SecondWindow();
                Close();

                mW.Show();

                //#lol
            }
            else if (x.BombDetection(can, ref sprite))
            {
                timer.IsEnabled = false;
                MessageBox.Show("You died... TO A BOMB");

                DeathCounter x = new DeathCounter();

                SecondWindow mW = new SecondWindow();

                mW.Show();
                Close();
            }
            else if (EnemyDetect())
            {
                timer.IsEnabled = false;
                MessageBox.Show("You died... TO AN ALIEN");

                DeathCounter x = new DeathCounter();

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
                            BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/Jump.png"));
                            sprite.Source = bity;
                        }
                        break;

                    case Key.Q:
                        HighScore();
                        MainWindow mW = new MainWindow();
                        mW.Show();
                        Close();                
                        break;

                    case Key.S: SecondWindow mw = new SecondWindow(); mw.Show(); this.Close(); DeathCounter x = new DeathCounter(); break;

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
                BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/Left1.png"));
                sprite.Source = bity;
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
                BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/Right1.png"));
                sprite.Source = bity;
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
        private bool EnemyDetect()
        {
            for (int i = 0; i < enemies.Count; i++)//each (pBomb bomb in bombs)
            {
                double TopEnemy = Canvas.GetTop(enemies[i].EnemyPlayer);
                double LeftEnemy =  Canvas.GetLeft(enemies[i].EnemyPlayer);
                double TopSprite = Canvas.GetTop(sprite);
                double LeftSprite = Canvas.GetLeft(sprite);
                //(TopSprite + 32 >= TopBomb && TopSprite <= TopBomb
                if (((LeftSprite+32 >= LeftEnemy && LeftSprite <= LeftEnemy+32)  && (TopSprite + 32 >= TopEnemy && TopSprite -10 <= TopEnemy)))
                {
                    //MessageBox.Show(LeftSprite + 32+" " + LeftEnemy+" \n" + LeftSprite+" " + (LeftEnemy+ 32));
                    return true;
                }
            }
            return false;
        }

      public void  retUser(string user)
        {
            username = user;
        }
        private void HighScore()
        {
            List<string> lines = new List<string>();

            string SecondLast = "";
            string Last = "";

            StreamReader x = new StreamReader("Stats.txt");
            string file = x.ReadToEnd();

            string[] Lines = file.Split('\n');
            lines = Lines.ToList();

            int TotalLines = lines.Count();
            if (TotalLines >= 3)
            {
                Last = lines[TotalLines - 2];
                SecondLast = lines[TotalLines - 3];
            }
            x.Close();
            StreamWriter Flusher = new StreamWriter("Stats.txt");
            Flusher.Flush();
            Flusher.Close();


            try
            {
                StreamReader read = new StreamReader("HighScore.txt");
                read.Close();
            }

            catch(Exception e)
            {
                StreamWriter tester = new StreamWriter("HighScore.txt");
                tester.Close();
            }

            List<string> saved = Save();
            StreamWriter write = new StreamWriter("HighScore.txt");
            for (int i = 0; i < saved.Count; i++)
            {
                write.WriteLine(saved[i]);
            }
            write.WriteLine(SecondLast);
            write.WriteLine(Last);
            write.Close();

        }
        private List<string> Save()
        {
            List<string> lines = new List<string>();
            StreamReader x = new StreamReader("HighScore.txt");
            string file = x.ReadToEnd();

            string[] Lines = file.Split('\n');
            lines = Lines.ToList();
            int TotalLines = lines.Count();
            x.Close();
            return lines;

        }


    }
}
