using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{   
    public enum Direction
    {
        Norte = 'N',
        Sul = 'S',
        Leste = 'L',
        Oeste = 'O',
        Cancelar = 'X'
    }
   public class Action
    {   
        public Direction Direction { get; private set; }

        public int Steps { get; private set; }

        public Action(Direction direction, int steps)
        {
            Direction = Direction;
            Steps = steps;
        }
    }
}
