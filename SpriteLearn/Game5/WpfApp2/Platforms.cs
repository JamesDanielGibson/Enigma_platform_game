using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Platforms
    {
        public int platTop = 0;
        public int platLeft = 0;
        public int platRight = 0;
        private int platBottom =0;
        public void platForm(int platTop, int platBottom, int platLeft, int platRight)
        {
            this.platTop = platTop;
            this.platBottom = platBottom;
            this.platLeft = platLeft;
            this.platRight = platRight;
        }
        public int[] platformChecker(int BottomSprite)
        {

            

            return [0];
        }

    }
    
}
