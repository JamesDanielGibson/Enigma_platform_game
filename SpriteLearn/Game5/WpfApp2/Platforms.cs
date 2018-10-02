
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
                myRect.Fill = Brushes.DeepSkyBlue;
                myRect.Height = 12;

                    Width = rand.Next(100, 400);
                    Left = rand.Next(0, Convert.ToInt32(a));
                    Top = rand.Next(0, Convert.ToInt32(b));


                //Bottom = rand3.Next(0, Convert.ToInt32(a));
                //Right = rand4.Next(0, Convert.ToInt32(b));


                myRect.Width = Width;   //Gives it a random width

                //Stores in list
                rect.Add(myRect);

                Canvas.SetLeft(rect[i], Left);
                Canvas.SetTop(rect[i], Top);
                
                can.Children.Add(rect[i]); // Adds the rectangle to the canvas
                Thread.Sleep(4);
            }      



        }

        //public Platforms(int platTop, int platBottom, int platLeft, int platRight)
        //{
        //    this.platTop = platTop;
        //    this.platBottom = platBottom;
        //    this.platLeft = platLeft;
        //    this.platRight = platRight;
            
        //}
        public bool IsOn(ref Image sprite)
        {
            for (int i = 0; i < rect.Count; i++)
            {

                //if (Canvas.GetBottom(sprite) == (Canvas.GetTop(rect[i])))
                //    MessageBox.Show("");
                ////return true;

                if ((((Canvas.GetTop(sprite))+ sprite.ActualHeight) >= (Canvas.GetTop(rect[i]))) && ((Canvas.GetLeft(sprite) >= Canvas.GetLeft(rect[i]) && (Canvas.GetLeft(sprite) + sprite.ActualWidth) <= (rect[i].ActualWidth+Canvas.GetLeft(rect[i])))))
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
