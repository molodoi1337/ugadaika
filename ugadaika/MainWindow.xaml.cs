using System;
using System.Collections.Generic;
using System.Globalization;
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
using ugadaika.Properties;

namespace ugadaika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public int diff = 90;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void StarGameButton_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game(diff);
            g.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void ExitButton_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            string content = (sender as RadioButton).Name.ToString();
            if (content == "Blue")
            {
                Background = Brushes.Blue;
            }
            else if (content == "Green")
            {
                Background = Brushes.Green;
            }
            else
                Background = Brushes.Pink;

        }


        private void Difficlty(object sender, RoutedEventArgs e)
        {
            string start = (sender as RadioButton).Name.ToString();
            switch (start)
            {
                case "легко":
                    diff = 90;
                    break;
                case "средне":
                    diff = 60;
                    break;
                case "сложно":
                    diff = 30;
                    break;
                case "невозможно":
                    diff = 15;
                    break;
                default: diff = 90;
                    break;

            }
        }
    }
}
