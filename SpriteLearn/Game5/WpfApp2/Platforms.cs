
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
    public class Platforms
    {
        Canvas can;
        List<Rectangle> rect = new List<Rectangle>(); 
        
        //static string location = "pack://application:,,,/";
        public double platTop = 0;
        public double platLeft = 0;
        public double platRight = 0;
        private double platBottom =0;
        public double ActualWidth = 0;
        private double ActualHeight = 0;
        //BitmapImage image1 = new BitmapImage(new Uri(location + "Platform.bmp"));
        public Platforms(Canvas can, double a, double b) //Creates the platforms, Mostly speced need to random the horizontal depth/ verticle, Each time this is run it creates a new one
        { //this has to be run before program starts so the platforms need to be created before.
            //this.can = can;
            //this.can = can;
            ActualWidth = a;
            ActualHeight = b;
            Random rand = new Random();
            Random rand1 = new Random();
            Random rand2 = new Random();
            double Width = 0;
            double Left = 0;
            double Top = 0;

            Rectangle myRect = new Rectangle();
            myRect.Fill = System.Windows.Media.Brushes.SkyBlue;
            myRect.Height = 10;
            MessageBox.Show(Convert.ToString(Convert.ToInt32(a)));
            Width = rand.Next(100, 400);
            Left = rand1.Next(0, Convert.ToInt32(a));
            Top = rand2.Next(0, Convert.ToInt32(b));



            myRect.Width = Width;   //Gives it a random width

            rect.Add(myRect);   //Stores in list
            Canvas.SetLeft(rect[0], Left);
            Canvas.SetBottom(rect[0], Top);
            can.Children.Add(rect[0]); // Adds the rectangle to the canvas



        }

        //public Platforms(int platTop, int platBottom, int platLeft, int platRight)
        //{
        //    this.platTop = platTop;
        //    this.platBottom = platBottom;
        //    this.platLeft = platLeft;
        //    this.platRight = platRight;
            
        //}
        public bool IsOn(double spriteBot, double spriteLeft, double spriteRight)
        {
            if ((spriteBot == platTop) && (spriteLeft >= platLeft || spriteRight <= platLeft ))
            {
                return true;
            }

            else return false;


        }


        //public int[] platformChecker(int BottomSprite)
        //{

            

        //    return [0];
        //}

    }
    
}
