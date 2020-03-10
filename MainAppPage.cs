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
    class MainAppPage : Window
    {

        private Canvas WindowCanvas { get; set; }
        private Button ReturnButton { get; set; }
        private TextBlock InstructionBlock { get; set; }
        private Border GridBorder { get; set; }
        public Grid AppGrid { get; set; }
        public TextBlock MoveCount { get; set; }
        public TextBlock MoveLabel { get; set; }

        private Movement Mover { get; set; }
        private Levels populateGrid { get; set; }
        
        
        public List<Coordinate> obstacles = new List<Coordinate>();
        public List<Coordinate> moveables = new List<Coordinate>();


        public Coordinate winLocation;
        public Box box;
        public Wullie wullie;



        public MainAppPage(string windowName)
        {
            this.Title = windowName;
            initializeWindow();
            

        }

        //create and position window elements
        private void initializeWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowState = WindowState.Maximized;
            WindowCanvas = new Canvas();
            createGrid();
            createSidePanel();
            AppGrid.Focus();

            populateGrid = new Levels(this);
            

            populateGrid.levels[0]();
            



            this.Content = WindowCanvas;
            Mover = new Movement(this);
            setupPageEvents();
        }

        //creates and positions the grid
        private void createGrid()
        {

            GridBorder = new Border();
            GridBorder.BorderThickness = new Thickness(11.00);
            GridBorder.BorderBrush = Brushes.Black;

            AppGrid = new Grid();
            AppGrid.Width = AppGrid.Height = 400;
            AppGrid.HorizontalAlignment = HorizontalAlignment.Left;
            AppGrid.VerticalAlignment = VerticalAlignment.Top;
            AppGrid.Focusable = true;
            GridBorder.Child = AppGrid;

            for (int i = 0; i < 10; i++)
                AppGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 10; i++)
                AppGrid.RowDefinitions.Add(new RowDefinition());

        }

        //creates side panel with buttons and instructions
        

        private void createSidePanel()
        {

            InstructionBlock = new TextBlock();
            InstructionBlock.FontSize = 25;
            InstructionBlock.Text = "Use arrow keys to move around the  screen and move the box to goal";
            MoveCount = new TextBlock();
            MoveCount.FontSize = 20;
            MoveCount.Text = Convert.ToString(0);
            MoveLabel = new TextBlock();
            MoveLabel.FontSize = 20;
            MoveLabel.Text = "Number of moves: ";


            ReturnButton = new Button();
            ReturnButton.Height = 30;
            ReturnButton.Width = 245;
            ReturnButton.FontSize = 15;
            ReturnButton.Focusable = false;
            ReturnButton.Content = "Return to start page";

            arrangeOnCanvas();
        }

        //position the elements on the canvas
        
        private void arrangeOnCanvas()
        {
            WindowCanvas.Children.Add(InstructionBlock);
            WindowCanvas.Children.Add(ReturnButton);
            WindowCanvas.Children.Add(GridBorder);
            WindowCanvas.Children.Add(MoveCount);
            WindowCanvas.Children.Add(MoveLabel);

            Canvas.SetLeft(InstructionBlock, 490);
            Canvas.SetTop(InstructionBlock, 100);

            Canvas.SetLeft(MoveCount, 800);
            Canvas.SetTop(MoveCount, 200);

            Canvas.SetLeft(MoveLabel, 600);
            Canvas.SetTop(MoveLabel, 200);

            Canvas.SetLeft(ReturnButton, 490);
            Canvas.SetTop(ReturnButton, 380);
        }

        //will create instance of welcome window , show it and then close current window
        protected void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        protected void appGrid_KeyDown(object sender, KeyEventArgs e)
        {
            Mover.moveWullie(e);

        }

        private void setupPageEvents()
        {
            ReturnButton.Click += returnButton_Click; //event for return to start page
            AppGrid.KeyDown += appGrid_KeyDown; // event for a key being pressed
        }

    }
}
