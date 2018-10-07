using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Stats
    {
        private int deaths = 0;
        public Stats(int inDeaths, int inWins, int inRageQuits)
        {

        }
            
        public int Deaths { get; set; }
        public int Wins { get; set; }
    }
}
