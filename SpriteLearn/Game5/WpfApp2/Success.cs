using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp2
{
    class Success
    {
        public Success(string user)
        {

            StreamReader deathsFileRead = new StreamReader(/*"J:\\*/"Passed.txt");

            string x = deathsFileRead.ReadLine();
            

            int number = 0;
            if (!(x == null))
            {
                number = Convert.ToInt32(x);
            }
                
            deathsFileRead.Close();

            StreamWriter deathsFile = new StreamWriter(/*"J:\\*/"Passed.txt");
            deathsFile.WriteLine(number + 1);
            
            deathsFile.Close();
        }
    }
}
