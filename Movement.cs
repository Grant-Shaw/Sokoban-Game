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
    class Movement
    {

        //declare variables/objects
        private MainAppPage Window { get; set; }
        private Levels PopulateGrid { get; set; }
     
        private int targetCellRow, targetCellColumn;

        private int levelCount = 0;
        
        
        //move counter
        private int MoveCount { get; set; }







        //defines the window in which it is applying movement
        public Movement(MainAppPage window)
        {

            this.Window = window;
        }


        public void moveWullie(KeyEventArgs e)
        {
            switch (e.Key)
            {
                //call appropriate movement method
                case Key.Left:
                    move("left");
                    break;
                case Key.Up:
                    move("up");
                    break;
                case Key.Right:
                    move("right");
                    break;
                case Key.Down:
                    move("down");
                    break;
                default:
                    MessageBox.Show("Wrong key , use the arrows.");
                    break;
            }
        }



        public void move(string direction)
        {

            int i = 0, j = 0;

            switch (direction)
            {
                case "left":
                    i = 0; j = -1;
                    break;
                case "up":
                    i = -1; j = 0;
                    break;
                case "right":
                    i = 0; j = 1;
                    break;
                case "down":
                    i = 1; j = 0;
                    break;
                default:
                    break;
            }

            // if mario is within the boundary
            if (boundaryCheckWullie(i, j) == true)

            {
                //assign mario a grid coordinate
                Window.wullie.TargetLocation.Row = targetCellRow;
                Window.wullie.TargetLocation.Column = targetCellColumn;
                Window.box.boxTargetLocation.Row = targetCellRow + i;
                Window.box.boxTargetLocation.Column = targetCellColumn + j;

                //checks to see if Player has won before allowing move

                if (!Window.box.BoxLocation.Equals(Window.winLocation))
                {

                    //checks to see if the target Location contains an obstacle AND that the target location is not a box location

                    if (Window.obstacles.Exists(x => x.Row == Window.wullie.TargetLocation.Row && x.Column == Window.wullie.TargetLocation.Column) == false && !Window.wullie.TargetLocation.Equals(Window.box.BoxLocation))
                    {


                        PopulateGrid = new Levels(Window);
                        //draw mario in new position
                        PopulateGrid.drawContents("Images\\Wullie.bmp", Window.wullie.TargetLocation);

                        //update the original cell where the mario was to be a blank cell
                        PopulateGrid.drawContents("Images\\path.bmp", Window.wullie.WullieLocation);
                        //redraws the winlocation each time wullie moves
                        PopulateGrid.drawContents("images\\bin1.bmp", Window.winLocation);

                        //update the location of mario to these new co-ordinates
                         Window.wullie.updateLocation();

                        MoveCount += 1;

                        Window.MoveCount.Text = Convert.ToString(MoveCount);
                        winCheck(Window.box.BoxLocation);
                    }
                    //checks to see if the target location is a box location
                    else if (Window.wullie.TargetLocation.Equals(Window.box.BoxLocation))
                    {
                        //checks if the obstacle list contains the box's target location.
                        if (Window.obstacles.Exists(x => x.Row == Window.box.boxTargetLocation.Row && x.Column == Window.box.boxTargetLocation.Column) == false)
                        {

                            if (Window.box.boxTargetLocation.Row < 10 && Window.box.boxTargetLocation.Column < 10 && Window.box.boxTargetLocation.Row >= 0 && Window.box.boxTargetLocation.Column >= 0)
                            {
                                PopulateGrid = new Levels(Window);
                                //draw mario in new position
                                PopulateGrid.drawContents("Images\\Wullie.bmp", Window.wullie.TargetLocation);
                                PopulateGrid.drawContents("images\\path.bmp", Window.wullie.WullieLocation);

                                PopulateGrid.drawContents("images\\union.bmp", Window.box.boxTargetLocation);

                                Window.moveables.Add(Window.box);
                                Window.moveables.Add(Window.wullie);
                                //uses polymorphism to update the location for each object
                                foreach(Coordinate  x in Window.moveables)
                                {
                                    x.updateLocation();
                                }
                   
                                //update move count
                                MoveCount += 1;
                                Window.MoveCount.Text = Convert.ToString(MoveCount);
                                //check if level is complete
                                winCheck(Window.box.BoxLocation);

                            }

                        }

                    }

                }


            }
        }



        //check that mario is within grid boundary
        private bool boundaryCheckWullie(int i, int j)
        {

            if (((targetCellRow = Window.wullie.WullieLocation.Row + i) < 10) &&
                    ((targetCellColumn = Window.wullie.WullieLocation.Column + j) < 10) &&
                    ((targetCellRow = Window.wullie.WullieLocation.Row + i) >= 0) &&
                    ((targetCellColumn = Window.wullie.WullieLocation.Column + j) >= 0))
            {
                return true;
            }
            return false;
        }


       
        //checks if the player has successfully moved the box to the win location.
        private void winCheck(Coordinate win)
        {
            
            if (Window.winLocation.Equals(win) == true)
            {                
                PopulateGrid.drawContents("images\\bin2.bmp", Window.winLocation);
                MoveCount = 0;
                levelCount += 1;
                
                //sets the message box title, body and creates yes/no button

                if (MessageBox.Show("WINNER! play Again?", "Congratulations", MessageBoxButton.YesNo) == MessageBoxResult.No)
                {
                    Window.MoveLabel.Text = "WINNER";
                    Window.MoveCount.Text = "Level Completed!";
                }
                else
                {
                    try
                    {
                        PopulateGrid.levels[levelCount](); 
                        Window.MoveCount.Text = Convert.ToString(MoveCount);
                    }
                    catch (Exception e)
                    {                       
                        MainWindow main = new MainWindow();
                        MessageBox.Show("No more levels");
                        Window.Close();
                        main.Show();
                    }                 
                }
                
            }

        }
    }
}
