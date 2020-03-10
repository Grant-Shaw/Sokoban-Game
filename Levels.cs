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


namespace Sokoban
{
    class Levels
    {
        private MainAppPage Window { get; set; }

        public Action[] levels;







        public Levels(MainAppPage window)
        {
            this.Window = window;
            levels = new Action[3];
            levels[0] = level1;
            levels[1] = level2;
            levels[2] = level3;
    }

        public void drawContents(string uriLocation, int row, int column)
        {

            Image img = new Image() { Source = new BitmapImage(new Uri(uriLocation, UriKind.Relative)) };
            Window.AppGrid.Children.Add(img);
            Grid.SetRow(img, row);
            Grid.SetColumn(img, column);
        }

        public void drawContents (string uriLocation, Coordinate coord)
        {
            int row;
            int column;
            row = coord.Row;
            column = coord.Column;
            Image img = new Image() { Source = new BitmapImage(new Uri(uriLocation, UriKind.Relative)) };
            
            Window.AppGrid.Children.Add(img);
            Grid.SetRow(img, row);
            Grid.SetColumn(img, column);
        }

        

        private void level1()
        {
            //fill the grid with blank squares
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    drawContents("Images\\path.bmp", x, y);
                }
            }

            //initiating objects
            //placing wullie in row 0 , colum 0 initially and box in (2,2)
            
            
            Window.box = new Box();
            Window.wullie = new Wullie();
            Window.winLocation = new Coordinate(9, 9);

            Window.wullie.WullieLocation = new Coordinate(0,0);
            Window.wullie.TargetLocation = new Coordinate();

            Window.box.BoxLocation = new Coordinate(2, 2);
            
           
            //draw contents on grid
            drawContents("Images\\Wullie.bmp", Window.wullie.WullieLocation);
            drawContents("Images\\bin1.BMP", 10, 10);

            drawContents("Images\\union.bmp", Window.box.BoxLocation.Row, Window.box.BoxLocation.Row);




            System.Media.SoundPlayer player1;
            player1 = new System.Media.SoundPlayer("Sound\\Scotland.wav");
            player1.Play();
   
          //adds obstacles to a list

                    
            Window.obstacles.Add(new Coordinate(7, 9));
            Window.obstacles.Add(new Coordinate(7,4));
            Window.obstacles.Add(new Coordinate(7,5));
            Window.obstacles.Add(new Coordinate(1, 0));
            Window.obstacles.Add(new Coordinate(5, 1));
            Window.obstacles.Add(new Coordinate(9, 2));
            Window.obstacles.Add(new Coordinate(9, 0));
            Window.obstacles.Add(new Coordinate(7, 2));
            Window.obstacles.Add(new Coordinate(4, 1));
            Window.obstacles.Add(new Coordinate(7, 7));

            for (int i = 4; i < 7; i++)
            {
                Window.obstacles.Add(new Coordinate(9, i));
            }

            for (int i = 2; i < 5; i ++)
            {
                Window.obstacles.Add(new Coordinate(i, 6));
            }

            for (int i = 2; i < 5; i++)
            {
                Window.obstacles.Add(new Coordinate(i, 3));
            }

            for (int i = 6; i < 10; i++)
            {
                Window.obstacles.Add(new Coordinate(0, i));
            }

          


            //draws the obstacles contained in list on map
            foreach (Coordinate coord in Window.obstacles)
            {
                this.drawContents("Images\\wall.Bmp", coord);      
            }

            //set up the location of wullie so we can keep track of him and update
 
        }

        private void level2()
        {
            //fill the grid with blank squares
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    drawContents("Images\\path.bmp", x, y);
                }
            }
          
            Window.obstacles.Clear();
            Levels populateGrid = new Levels(Window);

            //placing mario in row 0 , colum 0 initially
            Window.box = new Box();
            Window.wullie = new Wullie();

            //initialise coordinates
            Window.winLocation = new Coordinate(9, 9);

            Window.wullie.WullieLocation = new Coordinate(0,0);
            Window.wullie.TargetLocation = new Coordinate();

            Window.box.BoxLocation = new Coordinate(1, 1);
          
            //draw contents on grid

            drawContents("Images\\Wullie.bmp", Window.wullie.WullieLocation);
            drawContents("Images\\bin1.BMP", 10, 10);

            drawContents("Images\\union.bmp", Window.box.BoxLocation.Row, Window.box.BoxLocation.Column);

            //create obstacles.
            for (int i = 7; i < 10; i++)
            { Window.obstacles.Add(new Coordinate(i, 3)); }

            for (int i = 7; i < 10; i ++)
            {for (int o = 0; o < 4; o++)
                    Window.obstacles.Add(new Coordinate(i, o));
            }

            for (int i = 1; i < 3; i++)
            {for (int o = 6; o < 10; o++)
                    Window.obstacles.Add(new Coordinate(i, o));
            }

            for (int i = 7; i < 10; i++)
            { Window.obstacles.Add(new Coordinate(8, i)); }


            Window.obstacles.Add(new Coordinate(6, 0));
            Window.obstacles.Add(new Coordinate(4, 5));
            Window.obstacles.Add(new Coordinate(2, 4));
            Window.obstacles.Add(new Coordinate(5, 2));
            Window.obstacles.Add(new Coordinate(5, 6));
            Window.obstacles.Add(new Coordinate(5, 7));
            Window.obstacles.Add(new Coordinate(1, 3));
            Window.obstacles.Add(new Coordinate(2, 3));
            Window.obstacles.Add(new Coordinate(1, 8));         
            Window.obstacles.Add(new Coordinate(3, 4));
            Window.obstacles.Add(new Coordinate(7, 5));
           


            foreach (Coordinate coord in Window.obstacles)
            {
                this.drawContents("Images\\wall.Bmp", coord);
            }

            //removing an obstacle and placing new one.
            Window.obstacles.RemoveAll(x => x.Row == 6 && x.Column == 8);
            drawContents("images\\path.bmp", 6, 8);

        }

        private void level3()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    drawContents("Images\\path.bmp", x, y);
                }
            }

            Window.obstacles.Clear();
            Levels populateGrid = new Levels(Window);

            //placing mario in row 0 , colum 0 initially
            Window.box = new Box();
            Window.wullie = new Wullie();

            //sets the win location
            Window.winLocation = new Coordinate(0, 9);
            //initialises coordinates
            Window.wullie.WullieLocation = new Coordinate(9,9);
            Window.wullie.TargetLocation = new Coordinate();
            
            Window.box.BoxLocation = new Coordinate(2, 2);
           

            Window.box.BoxLocation.Row = 8;
            Window.box.BoxLocation.Column = 1;
            //draw starting positions
            drawContents("Images\\Wullie.bmp", Window.wullie.WullieLocation);
            drawContents("Images\\bin1.BMP", 0, 9);

            drawContents("Images\\union.bmp", Window.box.BoxLocation.Row, Window.box.BoxLocation.Column);

            //create obstacles
            for (int i = 1; i < 9; i++)
            { Window.obstacles.Add(new Coordinate(i, 9)); }
            for (int i = 8; i < 10; i++)
            {Window.obstacles.Add(new Coordinate(i, 6));
                Window.obstacles.Add(new Coordinate(i, 7)); }
            for( int i = 4; i < 6; i++)
            { Window.obstacles.Add(new Coordinate(7, i));}
            for(int i = 0; i < 4; i++)
            {
                for (int o = 2; o < 5; o++)
                {
                    Window.obstacles.Add(new Coordinate(o, i));
                    Window.obstacles.Add(new Coordinate(o, i));
                    Window.obstacles.Add(new Coordinate(o, i));
                    Window.obstacles.Add(new Coordinate(o, i));
                    Window.obstacles.Add(new Coordinate(o, i));
                    Window.obstacles.Add(new Coordinate(o, i));
                    Window.obstacles.Add(new Coordinate(o, i));
                }
            }

            for( int i = 5; i < 9; i ++)
            {   Window.obstacles.Add(new Coordinate(1, i));
                Window.obstacles.Add(new Coordinate(2, i));
            }

            for(int i = 0; i < 3; i++)
            {for(int o = 0; o < 2; o++)
                { Window.obstacles.Add(new Coordinate(i, o));}
            }

            for(int i = 8; i < 10; i++)
            { Window.obstacles.Add(new Coordinate(i, 5));}

            for( int i = 0; i < 2; i++)
            {   Window.obstacles.Add(new Coordinate(6, i));
                Window.obstacles.Add(new Coordinate(9, i));
            }
            
            for (int i = 5; i < 7; i ++)
            {   Window.obstacles.Add(new Coordinate(5, i));
                Window.obstacles.Add(new Coordinate(4, i));
            }

            Window.obstacles.Add(new Coordinate(5, 3));
            Window.obstacles.Add(new Coordinate(5, 8));

            foreach (Coordinate coord in Window.obstacles)
            {this.drawContents("Images\\wall.Bmp", coord);}


        }

    }
}
