
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
    public class Platforms
    {


        static string location = "pack://application:,,,/";
        public int platTop = 0;
        public int platLeft = 0;
        public int platRight = 0;
        private int platBottom =0;
        BitmapImage image1 = new BitmapImage(new Uri(location + "Platform.bmp"));

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
