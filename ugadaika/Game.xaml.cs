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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ugadaika
{
    public partial class Game : Window
    {
        private int targetNumber;
        private int attemptsCount;

        DispatcherTimer _timer;
        TimeSpan _time;

        public Game()// закинуть таймер в функцию и сделать сброс времени после победы или поражение,добавить поражение ну и по визуалу
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(80);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Time.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) Close();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }


        private void StartNewGame()
        {
            Random random = new Random();
            targetNumber = random.Next(0, 10);
            attemptsCount = 0;
        }

        private void HandleGuess()
        {
            int userGuess;

            if (int.TryParse(guessNumberTextBox.Text, out userGuess))
            {
                attemptsCount++;

                if (userGuess == targetNumber)
                {
                    resultTextBlock.Text = $"Вы угадали число за {attemptsCount} попыток!";
                    StartNewGame();
                }
                else if (userGuess < targetNumber)
                {
                    resultTextBlock.Text = "Загаданное число больше.";
                }
                else
                {
                    resultTextBlock.Text = "Загаданное число меньше.";
                }

                guessNumberTextBox.Text = "";
            }
            else
            {
                resultTextBlock.Text = "Введите число!";
            }
        }

        private void guessButton_Click(object sender, RoutedEventArgs e)
        {
            HandleGuess();
        }

        private void guessNumberTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                HandleGuess();
            }
        }
    }
}
