using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class User
    {
        public String Name { get; set; }
        public String Age { get; set; }
        public String Mail { get; set; }
    }
  

    public partial class MainWindow : Window
    {
        public static List<User> items = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
            list1.ItemsSource = items;
        }

        GridViewColumnHeader lastHC = null;
        ListSortDirection lastDir = ListSortDirection.Ascending;
        string userInput;
        Input myInput;
        

        void ButtonHandler(object sender, RoutedEventArgs re)
        {
            myInput = new Input();
            myInput.Show();
            Button btn = new Button();

        }

        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs re)
        {
            GridViewColumnHeader headerClicked = re.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != lastHC)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (lastDir == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    Sort(header, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    if (lastHC != null && lastHC != headerClicked)
                    {
                        lastHC.Column.HeaderTemplate = null;
                    }

                    lastHC = headerClicked;
                    lastDir = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(list1.ItemsSource);
            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        
       

    }

    

}
