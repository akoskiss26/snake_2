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

        public Arena(MainWindow view)
        {
            this.View = view;

            // A játék kezdetén megjelenítjük a játékszabályokat
            View.GameplayTextBlock.Visibility = System.Windows.Visibility.Visible;

            //taktjeladó
            pendulumForPlayTime = new DispatcherTimer(TimeSpan.FromSeconds(1),DispatcherPriority.Normal, CountPlayTime, Dispatcher.CurrentDispatcher);
            pendulumForPlayTime.Start();


        }

        private void CountPlayTime(object sender, EventArgs e)
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
                    View.GameplayTextBlock.Visibility = System.Windows.Visibility.Hidden;
                    View.NumberOfMeals.Visibility = System.Windows.Visibility.Visible;
                    View.ArenaGrid.Visibility = System.Windows.Visibility.Visible;
                    Console.WriteLine(e.Key);
                    Console.WriteLine(playTime);
                    View.NumberOfMeals.Text = Convert.ToString(playTime);
                    break;
                
            }


        }



    }
}
