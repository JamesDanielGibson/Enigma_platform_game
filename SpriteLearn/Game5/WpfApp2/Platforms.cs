
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
        List<pBomb> bombs = new List<pBomb>();
        
        public Random randoming = new Random();
        public Image bomb = new Image();
        public Image aKey= new Image();
        public  List<Rectangle> rect = new List<Rectangle>();
        public double platTop = 0;
        public double platLeft = 0;
        public double platRight = 0;
        public double ActualWidth = 0;
        private double ActualHeight = 0;
        //BitmapImage image1 = new BitmapImage(new Uri(location + "Platform.bmp"));
        public Platforms(Canvas can, double a, double b, int PlatFormNumber) //Creates the platforms, Mostly speced need to random the horizontal depth/ verticle, Each time this is run it creates a new one
        { //this has to be run before program starts so the platforms need to be created before.
            ActualWidth = a;
            ActualHeight = b;
            
            double heightInterval = ActualHeight / PlatFormNumber;
            double height = ActualHeight;

            Rectangle myRect = new Rectangle();
            myRect.Fill = Brushes.Black;
            myRect.Height = 12;
            myRect.Width = 1200;
            Canvas.SetLeft(myRect, 0);
            Canvas.SetTop(myRect, ActualHeight+50);

            rect.Add(myRect);
            can.Children.Add(rect[0]);
            double Top = 0;

            Random rand = new Random();
            for (int i = 1; i < PlatFormNumber + 1; i++)
            {
                double Width = 0;
                double Left = 0;


                myRect = new Rectangle();
                myRect.Fill = Brushes.Cyan;
                myRect.Height = 12;
                Top = height - heightInterval * i + 50;
                //Width = 250;

                if (i == 10)
                {
                    Width = rand.Next(300, 500);
                }
                else
                {
                    Width = rand.Next(200, 550);
                }
                
                Left = rand.Next(0, Convert.ToInt32(a));

                myRect.Opacity = 99;
                Top = height - heightInterval * i +50;


                while (Left > 1200 - Width)
                {
                    Left = rand.Next(0, Convert.ToInt32(a));
                }
                //Top = rand.Next(0, Convert.ToInt32(b));
                
                myRect.Width = Width;

                rect.Add(myRect);

                Canvas.SetLeft(rect[i], Left);
                Canvas.SetTop(rect[i], Top);

                can.Children.Add(rect[i]); // Adds the rectangle to the canvas
                //Thread.Sleep(4);
            }
            Keys(can);
            int randomed = randoming.Next(0,5);
            for (int i = 0; i < randomed; i++)
            {
                pBomb bomb = new pBomb(can, rect, randoming);
                bombs.Add(bomb);
            }

        }
        public void Keys(Canvas can)
        {
            
            BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/key.png"));

            aKey.Source = bity;
            
            aKey.Width = 32;
            aKey.Height = 32;

            int Plat = 10;//rand.Next(9, rect.Count);
            double x = ((Canvas.GetLeft(rect[Plat]) + rect[Plat].Width - 32));
            double y = (Canvas.GetLeft(rect[Plat]));


            int x1 = Convert.ToInt32(x);
            int y1 = Convert.ToInt32(y);
            int Local = randoming.Next(y1, (x1));

            Canvas.SetTop(aKey, Canvas.GetTop(rect[Plat]) - 32);
            Canvas.SetLeft(aKey, Local);

            can.Children.Add(aKey);
            

        }
        private void Bombs(Canvas can)
        {
            BitmapImage bity = new BitmapImage(new Uri("pack://application:,,,/bombDiggety.png"));
            bomb.Source = bity;
            
            bomb.Width = 16;
            bomb.Height = 16;
            
            int Plat = randoming.Next(2, rect.Count);
            double x = ((Canvas.GetLeft(rect[Plat]) + rect[Plat].Width));
            double y = (Canvas.GetLeft(rect[Plat]));

            
            int x1 = Convert.ToInt32(x);
            int y1 = Convert.ToInt32(y);
           
            int Local = randoming.Next(y1, (x1));

            Canvas.SetTop(bomb, Canvas.GetTop(rect[Plat]) - 16);
            Canvas.SetLeft(bomb, Local);

            can.Children.Add(bomb);


        }

        public bool IsOn(ref Image sprite)
        {
            for (int i = 0; i < rect.Count; i++)
            {
                if ((Canvas.GetTop(sprite) + sprite.ActualHeight) >= Canvas.GetTop(rect[i]) && SpriteLocation(ref sprite, i) && (Canvas.GetTop(sprite) <= Canvas.GetTop(rect[i])))//((((Canvas.GetTop(sprite))+ sprite.ActualHeight) >= (Canvas.GetTop(rect[i]))) && ))
                {
                    return true;
                }
            }
            return false;
        }

        private bool SpriteLocation(ref Image sprite, int i)
        {
            if ((Canvas.GetLeft(sprite) + (sprite.ActualWidth / 2) >= Canvas.GetLeft(rect[i]) &&
                (Canvas.GetLeft(sprite) + sprite.ActualWidth / 2) <=
                (rect[i].ActualWidth + Canvas.GetLeft(rect[i]))))                                   //Works out the Sprite Location on the platform
            {
                return true;
            }
            return false;
        }

        private bool SpriteBetRectHozBounds(ref Image sprite, int i)
        {
            if ((Canvas.GetLeft(sprite) >= Canvas.GetLeft(rect[i]) & (Canvas.GetLeft(sprite) + sprite.ActualWidth <= Canvas.GetLeft(rect[i]) + rect[i].ActualWidth)))
            {
                return true;
            }
            return false;
        }

        public bool Touch(ref Image sprite)
        {

            for (int i = 1; i < rect.Count; i++)
            {
                //if (Canvas.GetTop(sprite) >= Canvas.GetTop(rect[i]) + 12 && Canvas.GetTop(sprite) <= Canvas.GetTop(rect[i]) + 8)
                //{
                //    return true;
                //}
                if ((Canvas.GetTop(sprite) - (Canvas.GetTop(rect[i])) < 14) && SpriteBetRectHozBounds(ref sprite, i))
                {
                    return true;
                }
            }


            return false;





        }
        public bool KeyDetection(Canvas can, ref Image sprite)
        {
            //MessageBox.Show(Canvas.GetTop(sprite) + " <- sprite " + Canvas.GetTop(aKey) + "<- AKey");
            double LeftSprite = Canvas.GetLeft(sprite);
            double LeftaKey = Canvas.GetLeft(aKey);
            double TopSprite = Canvas.GetTop(sprite);
            double TopAKey = Canvas.GetTop(aKey);



            if (((                 LeftSprite >= LeftaKey &&  LeftSprite <= LeftaKey+32       ))  &&
                 ((                TopSprite <= TopAKey + 5   &&  TopSprite +32 <=  TopAKey+34)))
            {
                return true;
            }
            return false;
        }

        public bool BombDetection(Canvas can, ref Image sprite)
        {
            for(int i = 0; i < bombs.Count; i++)//each (pBomb bomb in bombs)
            {
                double TopBomb = bombs[i].GetTop;
                double LeftBomb = bombs[i].GetLeft;
                double TopSprite = Canvas.GetTop(sprite);
                double LeftSprite = Canvas.GetLeft(sprite);

                if (((LeftSprite + 16 >= LeftBomb && LeftSprite -16 <= LeftBomb ) &&
                   (TopSprite + 32 >= TopBomb && TopSprite <= TopBomb
                   )))
                {
                    return true;
                }
            }
            return false; 
        }

    }
    
}
