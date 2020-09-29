using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2.Model
{
    class ArenaPosition
    {
       

        public ArenaPosition(int rowPosition, int columnPositon)
        {
            RowPosition = rowPosition;
            ColumnPositon = columnPositon;
        }

        public int RowPosition { get; set; }
        public int ColumnPositon { get; set; }
    }
    

}
