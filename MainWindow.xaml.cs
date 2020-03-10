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
using System.Windows.Diagnostics;
using System.Diagnostics;

namespace Sokoban
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //initialises the main app page , sets the title and shows it.
        public MainWindow()
        {
            InitializeComponent();
            beginAppButton.Focus();
        }


        private void beginAppButton_Click_1(object sender, RoutedEventArgs e)
        {
            MainAppPage appPage1 = new MainAppPage("Sokoban");
            appPage1.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = "";

            string business = "grantshaw@hotmail.co.uk";  // your paypal email
            string description = "Tax free gift - Non refundable";            // '%20' represents a space. remember HTML!
            string country = "UK";                  // AU, US, etc.
            string currency = "GBP";                 // AUD, USD, etc.

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            ProcessStartInfo startInfo = new ProcessStartInfo("chrome.exe", url);
            Process.Start(startInfo);
            
        }
    }
}
