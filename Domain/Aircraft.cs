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

    }
}
