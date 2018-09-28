
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
        public int platTop = 0;
        public int platLeft = 0;
        public int platRight = 0;
        private int platBottom =0;
        //BitmapImage image1 = new BitmapImage(new Uri(location + "Platform.bmp"));
        public Platforms(Canvas can) //Creates the platforms, Mostly speced need to random the horizontal depth/ verticle, Each time this is run it creates a new one
        { //this has to be run before program starts so the platforms need to be created before.
            this.can = can;
            //this.can = can;
            Random rand = new Random();
            int x = 0;
            Rectangle myRect = new Rectangle();
            myRect.Fill = System.Windows.Media.Brushes.SkyBlue;
            myRect.Height = 10;
            for (int i = 0; i < 1; i++)
            {
                x = rand.Next(100, 400);
            }
            myRect.Width = x;   //Gives it a random width

            rect.Add(myRect);   //Stores in list

            can.Children.Add(rect[0]); // Adds the rectangle to the canvas
            


        }

        public Platforms(int platTop, int platBottom, int platLeft, int platRight)
        {
            this.platTop = platTop;
            this.platBottom = platBottom;
            this.platLeft = platLeft;
            this.platRight = platRight;
            
        }
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
