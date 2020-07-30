using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public abstract class Aircraft
    {
        private const int MAX_NUMBER_STEPS = 2147483647;
        public int PositionX { get; private set; } = 0;
        public int PositionY { get; private set; } = 0;

        /// <summary>
        /// Movimenta um Aircraft com base em uma Action passada por parâmetro
        /// </summary>
        /// <param name="action">Instância de Action válida</param>
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
            if (!(PositionX >= MAX_NUMBER_STEPS * -1 && PositionX <= MAX_NUMBER_STEPS)) return false;
            if (!(PositionY >= MAX_NUMBER_STEPS * -1 && PositionY <= MAX_NUMBER_STEPS)) return false;

            return true;
        }
        public override string ToString()
        {
            return $"({PositionX}, {PositionY})";
        }

    }
}
