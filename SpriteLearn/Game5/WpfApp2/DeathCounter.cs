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
        public DeathCounter()
        {
            
            StreamReader deathsFileRead = new StreamReader(/*"J:\\*/"Deaths.txt");

            string y = deathsFileRead.ReadLine();
            string x = deathsFileRead.ReadLine();
            
            int number = 0;
            if (!(x == null))
            {
                number = Convert.ToInt32(x);
            }
            
            deathsFileRead.Close();
            
            StreamWriter deathsFile = new StreamWriter(/*"J:\\*/"Deaths.txt");
            deathsFile.WriteLine(y);
            deathsFile.WriteLine((number + 1));
            
            //deathsFile.WriteLine((number + 1));
            
            deathsFile.Close();
        }

       
        
    }
}
