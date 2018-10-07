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
    class pEnemyPlayer
    {
        public double GetLeft = 0;
        public double GetTop = 0;
        public int Plat = 0;
        private Rectangle plats = new Rectangle();
        public Image EnemyPlayer = new Image();
        
        //private Random randoming = new Random();
        private const double moveSpeed = 2;
        private double dir = 1;
        public pEnemyPlayer(Canvas can, List<Rectangle> rect, int counter, Random randoming)
        {

            
            
            BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/Alien.png"));
            EnemyPlayer.Source = bity;

            EnemyPlayer.Width = 32;
            EnemyPlayer.Height = 32;

            Plat = randoming.Next(1, rect.Count);
                

            double x = ((Canvas.GetLeft(rect[Plat]) + rect[Plat].Width));
            double y = (Canvas.GetLeft(rect[Plat]));


            int x1 = Convert.ToInt32(x);
            int y1 = Convert.ToInt32(y);

                int Local = randoming.Next(y1, (x1));

            if (Local > Canvas.GetLeft(rect[Plat]) + rect[Plat].ActualWidth-32)
            {
                Local = randoming.Next(y1, (x1));
            }
            Canvas.SetTop(EnemyPlayer, Canvas.GetTop(rect[Plat]) - 32);
            Canvas.SetLeft(EnemyPlayer, Local);

            GetLeft = Local;
            GetTop = Canvas.GetTop(rect[Plat]) - 32;
            plats = (rect[Plat]);
            can.Children.Add(EnemyPlayer);

        }
        public void EnemyMove()
        {
            
            if(Canvas.GetLeft(EnemyPlayer)>=Canvas.GetLeft(plats) && Canvas.GetLeft(EnemyPlayer)+EnemyPlayer.ActualWidth <= Canvas.GetLeft(plats)+plats.ActualWidth)
            {
                double nextX;
                nextX = Canvas.GetLeft(EnemyPlayer) + (dir*moveSpeed);
                Canvas.SetLeft(EnemyPlayer, nextX);

                //if (Canvas.GetLeft(EnemyPlayer) + EnemyPlayer.ActualWidth >= Canvas.GetLeft(plats) + plats.ActualWidth)
                //{

                //    dir = -1;
                //}
                //if (Canvas.GetLeft(EnemyPlayer) <= Canvas.GetLeft(plats))
                //{
                //    dir = 1;
                //}
            }
            if (Canvas.GetLeft(EnemyPlayer) + EnemyPlayer.ActualWidth >= Canvas.GetLeft(plats) + plats.ActualWidth )
            {
                Canvas.SetLeft(EnemyPlayer, Canvas.GetLeft(EnemyPlayer)-1);
                dir = -1;
            }
            if (Canvas.GetLeft(EnemyPlayer) <= Canvas.GetLeft(plats))
            {
                Canvas.SetLeft(EnemyPlayer, Canvas.GetLeft(EnemyPlayer) +  1);
                dir = 1;
            }
        }
    }

}
