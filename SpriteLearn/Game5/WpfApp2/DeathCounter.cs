using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp2
{
    class DeathCounter
    {
        private int deaths;
        public DeathCounter(string ID, int indeaths)
        {
            WriteToDeaths();
        }
        public void WriteToDeaths()
        {
            
            StreamWriter deathsFile = new StreamWriter("C:\\Deaths.txt");
            StreamReader deathsFileRead = new StreamReader("C:\\Deaths.txt");
            deat
            string x = deathsFileRead.ReadLine();
            Convert.ToInt32(x);
            deathsFile.WriteLine(x + 1);

            deathsFile.Close();
            deathsFileRead.Close();

        }
       
        
    }
}
