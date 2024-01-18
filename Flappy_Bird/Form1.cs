using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {

        // значения по умолчанию (можно поменять) 
        int pipeSpeed = 8; // значение скорости
        int gravity = 12; // значение силы тяжести
        int score = 0; // значение балла

        bool gameOver = false;

        public Form1() // по умолчанию
        {
            InitializeComponent();
        }

        // события игрового таймера
        private void gameTimerEvent(object sender, EventArgs e) 
        {
            flappyBird.Top += gravity; // двигает птицу вниз по временной шкале

            // передвижение колонн влево 
            pipeBottom.Left -= pipeSpeed; 
            pipeTop.Left -= pipeSpeed;

            // подсчет очков
            scoreText.Text = "Score: " + score;

            // передвижение колонн с их новым появлением
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 550; // нижняя колонна
                score++; // успешное прохождение нижней колонны
            }
            if (pipeTop.Left < -160)
            {
                pipeTop.Left = 700; // верхняя колонна
                score++; // успешное прохождение верхней колонны
            }

            // проверка на столкновение с колоннами и землей 
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                    flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }

            // исключаем возможность улетать птичке вверх
            if (flappyBird.Top < -25)
            {
                endGame();
            }


            // увеличиваем скорость (усложняем игру)
            if (score > 5 & score < 20)
            {
                pipeSpeed = 12;
            }

            if (score > 20 & score < 30)
            {
                pipeSpeed = 16;
            }

            if (score > 30)
            {
                pipeSpeed = 20;
            }


        }

        private void gamekeyisdown(object sender, KeyEventArgs e) // нажатие клавиш (птичка вверх)
        {
            // проверка на свободное место 
            if (e.KeyCode == Keys.Space) // если нажать на клавишу пробела, то изменяется гравитация
            {
                gravity = -12;
            }
            
        }

        private void gamekeyisup(object sender, KeyEventArgs e) // отпускаем клавишу (птичка вниз)
        {

            if (e.KeyCode == Keys.Space) // если отпустить на клавишу пробела, то изменяется гравитация
            {
                gravity = 12;
            }

            if (e.KeyCode == Keys.F && gameOver)
            {
                // функция перезапуска игры
                RestartGame();
            }

        }


        private void endGame() // столкновение (конец игры)
        {

            gameTimer.Stop(); // остановка таймера
            scoreText.Text += " GAME OVER!!! Press F to retry ";
            gameOver = true;

        }

        private void RestartGame()
        {

            gameOver = false;

            flappyBird.Location = new Point(133, 217); // начальное положение птички
            pipeTop.Left = 700;
            pipeBottom.Left = 550;

            // возвращаем все начальные значения
            score = 0;
            pipeSpeed = 8;
            scoreText.Text = "Score: 0";
            gameTimer.Start();

        }


    }
}
