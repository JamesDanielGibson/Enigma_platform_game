﻿using System;
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
            InitializeComponent();
            Score();
            AddingToHighScore();






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
        private void Score()
        {
            string CompyLineUser = "";
            string CompyLineDeaths = "";
            string CompyLinePassed = "";
            int Score = 0;
           
            
            string user = "";
            int score = 0;
            List<string> lines = new List<string>();
            
            try
            {
                

                StreamReader tesrer = new StreamReader("Stats.txt");
                tesrer.Close();

            }
            catch(Exception e)
            {
                StreamWriter x = new StreamWriter(/*"J:\\*/"Stats.txt");
                x.Close();
            }


            StreamReader reader3 = new StreamReader("Stats.txt");
            string file = reader3.ReadToEnd();
            reader3.Close();

            string[] Lines = file.Split('\n');
            lines = Lines.ToList();




            StreamReader reader = new StreamReader(/*"J:\\*/"Deaths.txt");
            CompyLineUser = reader.ReadLine();
            CompyLineDeaths = reader.ReadLine();
            reader.Close();

            StreamReader reader2 = new StreamReader(/*"J:\\*/"Passed.txt");
            CompyLinePassed = reader2.ReadLine();
            reader2.Close();

            Score = Convert.ToInt32(CompyLinePassed) - Convert.ToInt32(CompyLineDeaths);
            StreamWriter writer = new StreamWriter(/*"J:\\*/"Stats.txt");
            



            for (int i = 0; i < lines.Count; i++)
            {


                if (i % 2 == 0)
                {
                    user = lines[i];
                }
                else
                {
                    score = Convert.ToInt32(lines[i]);
                }

                writer.WriteLine(user);
                writer.WriteLine(score);
            }
            writer.WriteLine(CompyLineUser);
            writer.WriteLine(Score);
            writer.Close();



        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter x = new StreamWriter("Stats.txt");
            x.Flush();
            x.Close();
        }


        private void AddingToHighScore()
        {
            StreamReader reader = new StreamReader("HighScore.txt");
            string x = reader.ReadToEnd();
            string[] split = x.Split('\n');
            //List<string> sorting = new List<string>();
            //List<string> SortingName = new List<string>();
            string[] SE = new string[2];
            List<string []> HS = new List<string[]>();
            reader.Close();
           
            for (int i = 0; i < split.Length; i++)
            {
                if (i%3 == 0)
                {
                    //sorting.Add(split[i]);

                    
                }
                else if (i % 3 == 1)
                {
                    SE[0] = split[i];
                }
                else if (i%3 == 2)
                {
                    //SortingName.Add(split[i]);
                    SE[1] = split[i];

                    HS.Add(SE);
                }
               
            }
            StringBuilder str1 = new StringBuilder();
            for (int i = 0; i < HS.ToArray().Length; i++)
            {
                str1.Append(HS[i][0] + " " + HS[i][1]);
            }
            MessageBox.Show(str1.ToString());

            string[] temp = new string[2];
            int counter = -100;
            for (int j = 0; j < HS.Count; j++)
            { 
                for (int i = 0; i < HS.Count; i++)
                {
                    if (int.Parse(HS[i][1]) > int.Parse(HS[j][1]))
                    {

                        temp = HS[i] ;
                        HS[i] = HS[j];
                        HS[j] = temp;
                    }
                }
            }

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < HS.Count; i++)
            {
                str.Append(HS[i][0] + " " + HS[i][1]);
            }
            MessageBox.Show(str.ToString());


        }
    }
}
