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
using System.Windows.Shapes;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Username;
        public string[] Lines;
        public MainWindow()
        {
            string[] y = { "Deaths.txt", "Passed.txt", "Stats.txt", "HighScore.txt" };



            for (int i = 0; i < y.Length; i++)
            {
                try
                {
                    StreamReader x = new StreamReader(y[i]);
                    x.Close();
                }
                catch (Exception)
                {
                    StreamWriter x = new StreamWriter(y[i]);
                    x.Close();
                }

            }




            InitializeComponent();


            

            





        }
        private void btnStart_Click(Object sender, RoutedEventArgs e)
        {
            if (!txtUsername.Text.Equals(""))
            {
                Username = txtUsername.Text;
                StreamWriter deathsFile = new StreamWriter(/*"C:\\Deaths.txt"*/"Deaths.txt");

                deathsFile.WriteLine(Username);
                deathsFile.WriteLine("0");
                
                deathsFile.Close();

                StreamWriter passFile = new StreamWriter(/*"J:\\Passed.txt"*/"Passed.txt");
                passFile.WriteLine("0");

                passFile.Close();

                SecondWindow mW = new SecondWindow();
                mW.Show();
                mW.retUser(/*Username*/"james");
                Close();
               }
        }

        private void btnInst_Click(object sender, RoutedEventArgs e)
        {
            Instructions mW = new Instructions();
            mW.Show();
            Close();
            
        }
        private void btnCallHighScore_Click(object sender, RoutedEventArgs e)
        {
            AddingToHighScore();
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter x = new StreamWriter("Stats.txt");
            x.Flush();
            x.Close();
            StreamWriter xy = new StreamWriter("HighScore.txt");
            xy.Flush();
            xy.Close();
            StreamWriter xz = new StreamWriter("Deaths.txt");
            xz.Flush();
            xz.Close();
            StreamWriter y = new StreamWriter("Passed.txt");
            y.Flush();
            y.Close();
            txtScoreblock.Content = "High Scores:\n";

        }


        private void AddingToHighScore()
        {
            
            txtScoreblock.Content = "High Scores:\n";
            StreamReader reader = new StreamReader("HighScore.txt");
            string x = reader.ReadToEnd();
            x.Trim();
            string[] arr = x.Split();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!(arr[i].Equals(null)|| arr[i].Equals("")|| arr[i].Equals("\r") || arr[i].Equals("\n")))
                {
                    str.Append(arr[i]+"," );
                }
            }
            //str.ToString().Remove()
            x = str.ToString();
            reader.Close();
            //for (int i = 0; i < x.Length; i = i+4)
            //{
            //    x = x + x[4];
            //}
            string[] gtest = x.Split(',');
            MessageBox.Show(x);
            
            List<List<string>> HS = new List<List<string>>();
            List<string> Saver = new List<string>(2);

            for (int i = 0; i < gtest.Length; i++)
            {
                
                if (i % 2 == 1) {
                    Saver.Add(gtest[i]);
                    HS.Add(Saver);
                    Saver = new List<string>(2);
                }
                else if (i % 2 == 0)
                {
                    Saver.Add(gtest[i]);
                    
                }
            }

            StringBuilder str1 = new StringBuilder();
            
            List<List<string>> Copy  = new List<List<string>>();
            List<List<string>> Modify = new List<List<string>>();
            List<List<string>> Results = new List<List<string>>();

            for (int i = 0; i < HS.Count; i++)
            {
                Results.Add(HS[i]);
            }
            
            for (int i = 0; i < HS.Count; i++)
            {
                Modify.Add(HS[i]);
            }
            //MessageBox.Show("" + Modify.Count);

            //if (Modify.Count >= 2)
            //{
            while (0 < Modify.Count)
            {
                int location = 0;
                int Checker = -100;
                
                for (int i = 0; i < Modify.Count; i++)
                {
                    if (Checker < int.Parse(Modify[i][1]))
                    {
                        Checker = int.Parse(Modify[i][1]);
                        location = i;
                    }
                }
                //if (location != -1)
                //{
                Copy.Add((Modify[location]));
                Modify.Remove(Modify[location]);
                //}

            }

            //MessageBox.Show(Copy[0][1] + " WHY\n" + Copy[1][1] + " WHY\n" + Copy[2][1] + " WHY\n" + Copy[3][1] + " WHY\n");
                
            for (int i = 0; i < Copy.Count; i++)
            {
                StringBuilder str2 = new StringBuilder();           
                str2.Append(Copy[i][0] + ": " + Copy[i][1]);
                        
                txtScoreblock.Content += (Convert.ToString(str2)+"\n");
            }
            MessageBox.Show(Convert.ToString(txtScoreblock.Content));
                

            //}



            //for (int j = 0; j < HS.Count; j++)
            //{ 
            //    for (int i = 0; i < HS.Count; i++)
            //    {
            //        if (int.Parse(HS[i][1]) > int.Parse(HS[j][1]))
            //        {

            //            temp = HS[i] ;
            //            HS[i] = HS[j];
            //            HS[j] = temp;
            //        }
            //    }
            //}

            //StringBuilder str = new StringBuilder();
            //for (int i = 0; i < HS.Count; i++)
            //{
            //    str.Append(HS[i][0] + " " + HS[i][1]);
            //}
            //MessageBox.Show(str.ToString());


        }
    }
}
