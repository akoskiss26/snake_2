using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2.Model
{
    class Snake
    {
       

        public Snake(int rowPosition, int columnPositon)
        {
            HeadPosition = new ArenaPosition(rowPosition, columnPositon);
            HeadDirection = SnakeHeadDirectionEnum.InPlace;
        }

        public SnakeHeadDirectionEnum HeadDirection { get; set; }

        public ArenaPosition HeadPosition { get; set; }


        public List<ArenaPosition> Tail { get; set; }



    }
    
       
    
}
