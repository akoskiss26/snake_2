using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2.Model
{
    class Snake
    {
        private int RowPosition;
        private int ColumnPosition;

        public Snake(int row, int column)
        {
            this.RowPosition = row;
            this.ColumnPosition = column;
        }

        public SnakeHeadDirectionEnum HeadDirection { get; set; }

        public ArenaPosition HeadPosition { get; set; }



    }
    
       
    
}
