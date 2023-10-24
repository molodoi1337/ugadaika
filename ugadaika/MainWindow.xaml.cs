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

namespace ugadaika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StarGameButton_Click(object sender, RoutedEventArgs e)
        {
            Game g = new Game();
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
            string content = (sender as RadioButton).Content.ToString();
            if (content == "Синий")
            {
                Background = Brushes.Blue;
            }
            else if (content == "Зеленый")
            {
                Background = Brushes.Green;
            }
            else
                Background = Brushes.Pink;

        }
    }
}
