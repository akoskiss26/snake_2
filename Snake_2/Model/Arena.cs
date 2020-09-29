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
        }

        private void ItsTimeToDisplay(object sender, EventArgs e)
        {
            CountPlayTime();


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
                    //elindul a játék, eltüntetjük a játékszabályokat, mutatjuk az eredményt
                    View.GamePlayBorder.Visibility = System.Windows.Visibility.Hidden;
                    View.NumberOfMeals.Visibility = System.Windows.Visibility.Visible;
                    View.ArenaGrid.Visibility = System.Windows.Visibility.Visible;
                    Console.WriteLine(e.Key);
                    Console.WriteLine(playTime);
                    View.NumberOfMeals.Text = Convert.ToString(playTime);

                    //kígyófej megjelenítése a Children gyűjteménnyel
                    var cell = View.ArenaGrid.Children[snake.HeadPosition.RowPosition  + snake.HeadPosition.ColumnPositon * 20];
                    //mivel egy általános element típust   kaptunk vissza, azt konvertálni kell:

                    var image = (FontAwesome.WPF.ImageAwesome)cell;

                    // ennek már el tudom érni az icon tulajdonságait
                    image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;

                    break;
                
            }


        }



    }
}
