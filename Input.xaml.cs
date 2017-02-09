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
using System.Windows.Shapes;

namespace MyGUI
{
    /// <summary>
    /// Interaction logic for Input.xaml
    /// </summary>
    public partial class Input : Window
    {
        public Input()
        {
            InitializeComponent();
        }

        public void addedInfoHandler(object sender, RoutedEventArgs e)
        {

            if (IsAlphabeticString(textBox2.Text))
            {
                MessageBox.Show("Please enter your age as numbers", "Age cannot be a string");
            }
            else if (!IsAlphabeticString(textBox1.Text))
            {
                MessageBox.Show("Please enter your name as a string", "Name cannot be a number");
            }
            
            else 
            {
                MainWindow.items.Add(new User() { Name = textBox1.Text, Age = textBox2.Text, Mail = textBox3.Text });
                CollectionViewSource.GetDefaultView(MainWindow.items).Refresh();
                this.Close();
            }
        }
            
        bool IsAlphabeticString(object value)
        {
            string str = value as string;
            return str != null && IsAllAlphabetic(str);
        }
        bool IsAllAlphabetic(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

    }
}
