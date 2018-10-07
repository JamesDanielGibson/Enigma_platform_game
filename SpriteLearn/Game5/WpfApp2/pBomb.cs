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
    class pBomb
    {

        public double GetTop = 0;
        public double GetLeft = 0;

        public pBomb(Canvas can, List<Rectangle> rect, Random randoming)
        {

            Image bomb = new Image();
            BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/bombDiggety.png"));
            bomb.Source = bity;

            bomb.Width = 16;
            bomb.Height = 16;

            int Plat = randoming.Next(2, rect.Count);
            double x = ((Canvas.GetLeft(rect[Plat]) + rect[Plat].Width));
            double y = (Canvas.GetLeft(rect[Plat]));


            int x1 = Convert.ToInt32(x);
            int y1 = Convert.ToInt32(y);

            int Local = randoming.Next(y1, (x1));

            Canvas.SetTop(bomb, Canvas.GetTop(rect[Plat]) - 16);
            Canvas.SetLeft(bomb, Local);

            GetLeft = Local;
            GetTop = Canvas.GetTop(rect[Plat]) - 16;

        can.Children.Add(bomb);
        }

    }
}
