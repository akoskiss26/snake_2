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
        internal void KeyDown(KeyEventArgs e)
        {
            // a játék kezdéshez vmelyik arrow-t kell lenyomni
            switch (e.Key)
            {
                
                case Key.Left:
                case Key.Up:
                case Key.Right:
                case Key.Down:
                    Console.WriteLine(e.Key);
                    break;
                
            }


        }
    }
}
