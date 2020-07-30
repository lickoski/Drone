using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public interface IInput
    {
        bool IsValid();

        string GetCoordinateError();

        string GetInput();
    }
}
