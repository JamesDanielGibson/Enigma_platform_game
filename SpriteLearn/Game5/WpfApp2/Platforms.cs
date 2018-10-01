
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
        
        List<Rectangle> rect = new List<Rectangle>();

        //static string location = "pack://application:,,,/";
        
        public double platTop = 0;
        public double platLeft = 0;
        public double platRight = 0;
        private double platBottom =0;
        public double ActualWidth = 0;
        private double ActualHeight = 0;
        //BitmapImage image1 = new BitmapImage(new Uri(location + "Platform.bmp"));
        public Platforms(Canvas can, double a, double b, int PlatFormNumber) //Creates the platforms, Mostly speced need to random the horizontal depth/ verticle, Each time this is run it creates a new one
        { //this has to be run before program starts so the platforms need to be created before.
            //this.can = can;
            //this.can = can;
            ActualWidth = a;
            ActualHeight = b;


            Random rand = new Random();
            for (int i = 0; i < PlatFormNumber; i++)
            {
                

                //Random rand3 = new Random();
                //Random rand4 = new Random();

                double Width = 0;
                double Left = 0;
                double Top = 0;
                //double Bottom = 0;
                //double Right = 0;

                Rectangle myRect = new Rectangle();
                myRect.Fill = Brushes.White;
                myRect.Height = 15;

                    Width = rand.Next(100, 400);
                    Left = rand.Next(0, Convert.ToInt32(a));
                    Top = rand.Next(0, Convert.ToInt32(b));


                //Bottom = rand3.Next(0, Convert.ToInt32(a));
                //Right = rand4.Next(0, Convert.ToInt32(b));


                myRect.Width = Width;   //Gives it a random width

                rect.Add(myRect);   //Stores in list

                Canvas.SetLeft(rect[i], Left);
                Canvas.SetBottom(rect[i], Top);
                can.Children.Add(rect[i]);
                Thread.Sleep(2);
            }




             // Adds the rectangle to the canvas



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
            for (int i = 0; i < rect.Count; i++)
            {
                if ((spriteBot == Canvas.GetTop(rect[i])) && (spriteLeft >= Canvas.GetLeft(rect[i]) || spriteRight <= Canvas.GetRight(rect[i])))
                {
                    return true;
                }

                
            }
            return false;


        }


        //public int[] platformChecker(int BottomSprite)
        //{

            

        //    return [0];
        //}

    }
    
}
