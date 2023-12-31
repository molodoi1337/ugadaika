﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Game(int start)//внедрить в конец игры _timer.stop
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(start);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Time.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) Close();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
            StartNewGame();
        }


        private void StartNewGame()
        {
            Random random = new Random();
            targetNumber = random.Next(0, 10);
            attemptsCount = 0;
        }

        private void HandleGuess()
        {
            if (int.TryParse(guessNumberTextBox.Text, out int userGuess))
            {
                attemptsCount++;
                if (attemptsCount % 3 == 0)
                {
                    Surprise.Visibility = Visibility.Visible;
                    Surprise.IsEnabled = true;
                }

                if (userGuess == targetNumber)
                {
                    resultTextBlock.Text = $"Вы угадали число за {attemptsCount} попыток!";
                }
                
                guessNumberTextBox.Text = "";
            }
            else
            {
                resultTextBlock.Text = "Введите число!";
            }
        }

        private void Win()
        {
            
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
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

        private void Surprise_Click(object sender, RoutedEventArgs e)
        {
            long temp;
            if (long.TryParse(guessNumberTextBox.Text, out temp))
            {
                temp = Convert.ToInt64(guessNumberTextBox.Text);

                if (temp > targetNumber)
                {
                    resultTextBlock.Text = "нужное число меньше";
                }
                if (temp < targetNumber)
                {
                    resultTextBlock.Text = "Нужное число больше";
                }
                if (temp == targetNumber)
                    resultTextBlock.Text = "вы угадали";
                guessNumberTextBox.Text = null;

                Surprise.Visibility = Visibility.Hidden; Surprise.IsEnabled = false;

            }
        }
    }
}
