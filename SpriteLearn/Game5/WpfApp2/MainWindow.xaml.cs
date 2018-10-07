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
        public MainWindow()
        {
            InitializeComponent();








        }
        private void btnStart_Click(Object sender, RoutedEventArgs e)
        {
            if (!txtUsername.Text.Equals(""))
            {
                Username = txtUsername.Text;
                StreamWriter deathsFile = new StreamWriter("J:\\Deaths.txt");
                deathsFile.WriteLine("0");
                deathsFile.WriteLine(Username);
                deathsFile.Close();

                StreamWriter passFile = new StreamWriter("J:\\Passed.txt");
                passFile.WriteLine("0");
                
                passFile.Close();

                SecondWindow mW = new SecondWindow();
                mW.Show();
                mW.retUser(Username);
                this.Close();
            }
        }

        private void btnInst_Click(object sender, RoutedEventArgs e)
        {
            Instructions mW = new Instructions();
            mW.Show();
            Close();
            
        }
        private void HighScore()
        {
            string CompyLineUser = "";
            string CompyLineDeaths = "";
            string CompyLinePassed = "";
            int Score = 0;
            string[] lines;
            
            string user;
            int score;
            try
            {
                

                StreamReader reader3 = new StreamReader("J:\\Stats.txt");
                string file = reader3.ReadToEnd();
                reader3.Close();

                
                lines = file.Split('\n');

                reader3.Close();


            }
            catch(FileNotFoundException e)
            {
                StreamWriter x = new StreamWriter("J:\\Stats.txt");
                x.Close();
            }


            StreamReader reader = new StreamReader("J:\\Deaths.txt");
            CompyLineUser = reader.ReadLine();
            CompyLineDeaths = reader.ReadLine();
            reader.Close();
            StreamReader reader2 = new StreamReader("J:\\Passed.txt");
            CompyLinePassed = reader.ReadLine();
            reader2.Close();
            Score = Convert.ToInt32(CompyLinePassed) - Convert.ToInt32(CompyLineDeaths);

            StreamWriter writer = new StreamWriter("J:\\Stats.txt");

            


            for (int i = 0; i < lines.Length; i += 2)
            {
                user = lines[i];
                score = Convert.ToInt32(lines[i + 1]);
                writer.WriteLine(user);
                writer.WriteLine(score);
            }
            writer.WriteLine(CompyLineUser);
            writer.WriteLine(Score);
        }
    }
}
