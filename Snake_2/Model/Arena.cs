using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake_2.Model
{
    class Arena
    {
        private MainWindow View;

        public Arena(MainWindow view)
        {
            this.View = view;

            // A játék kezdetén megjelenítjük a játékszabályokat
            View.GameplayTextBlock.Visibility = System.Windows.Visibility.Visible;


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
                    View.GameplayTextBlock.Visibility = System.Windows.Visibility.Hidden;
                    Console.WriteLine(e.Key);
                    break;
                
            }


        }
    }
}
