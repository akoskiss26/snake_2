using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Snake_2.Model
{
    class Arena
    {
        private MainWindow View;
        private DispatcherTimer pendulumForPlayTime;
        private int playTime = 0;
        private Snake snake;
        private bool isGameNotRunning;

        /// <summary>
        /// ez az arena konstruktor
        /// </summary>
        /// <param name="view"></param>
        public Arena(MainWindow view)  
        {
            this.View = view;

            // A játék kezdetén megjelenítjük a játékszabályokat
            View.GamePlayBorder.Visibility = System.Windows.Visibility.Visible;

            //taktjeladó
            pendulumForPlayTime = new DispatcherTimer(TimeSpan.FromSeconds(1),DispatcherPriority.Normal, ItsTimeToDisplay, Dispatcher.CurrentDispatcher);
            pendulumForPlayTime.Start();

            snake = new Snake(10,10);
            isGameNotRunning = true;
        }

        private void ItsTimeToDisplay(object sender, EventArgs e)
        {
            if (isGameNotRunning)
            {
                return;

            }
            CountPlayTime();

            //léptetjük a kígyó fejét
            var LastPosition = new ArenaPosition(snake.HeadPosition.RowPosition, snake.HeadPosition.ColumnPositon);
            switch (snake.HeadDirection)
            {
                case SnakeHeadDirectionEnum.up:
                    snake.HeadPosition.RowPosition = snake.HeadPosition.RowPosition - 1;
                    break;
                case SnakeHeadDirectionEnum.down:
                    snake.HeadPosition.RowPosition = snake.HeadPosition.RowPosition + 1;
                    break;
                case SnakeHeadDirectionEnum.right:
                    snake.HeadPosition.ColumnPositon = snake.HeadPosition.ColumnPositon + 1;
                    break;
                case SnakeHeadDirectionEnum.left:
                    snake.HeadPosition.ColumnPositon = snake.HeadPosition.ColumnPositon - 1;
                    break;
                case SnakeHeadDirectionEnum.InPlace:
                    break;
                default:
                    break;
            }

            //kígyófej megjelenítése a Children gyűjteménnyel
            var cell = View.ArenaGrid.Children[snake.HeadPosition.RowPosition + snake.HeadPosition.ColumnPositon * 20];
            //mivel egy általános element típust   kaptunk vissza, azt konvertálni kell:
            var image = (FontAwesome.WPF.ImageAwesome)cell;
            // ennek már el tudom érni az icon tulajdonságait
            image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;

            // régi fej törlése
            var cell1 = View.ArenaGrid.Children[LastPosition.RowPosition + LastPosition.ColumnPositon * 20];
            //mivel egy általános element típust   kaptunk vissza, azt konvertálni kell:
            var image1 = (FontAwesome.WPF.ImageAwesome)cell1;
            // ennek már el tudom érni az icon tulajdonságait
            image1.Icon = FontAwesome.WPF.FontAwesomeIcon.SquareOutline;
        }

        private void CountPlayTime()
        {
            playTime = playTime + 1;

        }

        internal void KeyDown(KeyEventArgs e)
        {
            // a játék kezdéshez vmelyik arrow-t kell lenyomni
            switch (e.Key)
            {

                case Key.Left:
                case Key.Up:
                case Key.Right:
                case Key.Down:

                    if (isGameNotRunning)
                    {
                    StartGame(e);


                    }

                    switch (e.Key)              //beállítjuk a fej irányát
                    {
                        case Key.Left:
                            snake.HeadDirection = SnakeHeadDirectionEnum.left;
                            break;
                        case Key.Up:
                            snake.HeadDirection = SnakeHeadDirectionEnum.up;
                            break;
                        case Key.Right:
                            snake.HeadDirection = SnakeHeadDirectionEnum.right;
                            break;
                        case Key.Down:
                            snake.HeadDirection = SnakeHeadDirectionEnum.down;
                            break;
                    }

                    Console.WriteLine(e.Key);
                    Console.WriteLine(playTime);
                    View.NumberOfMeals.Text = Convert.ToString(playTime);

                    //kígyófej megjelenítése a Children gyűjteménnyel
                    var cell2 = View.ArenaGrid.Children[snake.HeadPosition.RowPosition + snake.HeadPosition.ColumnPositon * 20];
                    //mivel egy általános element típust   kaptunk vissza, azt konvertálni kell:
                    var image2 = (FontAwesome.WPF.ImageAwesome)cell2;
                    // ennek már el tudom érni az icon tulajdonságait
                    image2.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;

                    

                    break;

            }


        }

        private void StartGame(KeyEventArgs e)
        {
            //elindul a játék, eltüntetjük a játékszabályokat, mutatjuk az eredményt
            View.GamePlayBorder.Visibility = System.Windows.Visibility.Hidden;
            View.NumberOfMeals.Visibility = System.Windows.Visibility.Visible;
            View.ArenaGrid.Visibility = System.Windows.Visibility.Visible;
            isGameNotRunning = false;
        }
    }
}
