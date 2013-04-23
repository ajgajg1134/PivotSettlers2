using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace PivotSettlers2
{
    public partial class MainPage : PhoneApplicationPage
    {
        Controller c;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            c = new Controller();

            //Run this last as it can lag
            this.ErrorMsg.Text = c.TryConnection();
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //if (!App.ViewModel.IsDataLoaded)
            //{
            //    App.ViewModel.LoadData();
            //}
            List<String> cards = new List<String>();
            cards.Add("Pictures/wheat.png");
            cards.Add("Pictures/brick.png");

            devCards.ItemsSource = cards;

            this.ErrorMsg.Text = c.Send("test");
        }
    }
}