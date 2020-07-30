using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public abstract class Aircraft
    {
        public int PositionX { get; private set; } = 0;
        public int PositionY { get; private set; } = 0;

        public void Move(Action action)
        {
                if (action.Direction == Direction.N)
                    PositionY += action.Steps;

                if (action.Direction == Direction.S)
                    PositionY -= action.Steps;

                if (action.Direction == Direction.L)
                    PositionX += action.Steps;

                if (action.Direction == Direction.O)
                    PositionX -= action.Steps;

            if (!IsValid())
                throw new ArgumentException();
        }

        public bool IsValid()
        {
            if (!(PositionX >= -2147483647 && PositionX <= 2147483647)) return false;
            if (!(PositionY >= -2147483647 && PositionY <= 2147483647)) return false;

            return true;
        }
        public override string ToString()
        {
            return  $"({PositionX}, {PositionY})";
        }

    }
}
