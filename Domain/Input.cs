using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public class Input:IInput
    {
        public string _stringInput { get; private set; }

        private const string ERROR_INPUT = "(999, 999)";
        public Input(string input)
        {
            _stringInput = input;
        }

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(_stringInput)) return false;

            return Regex.IsMatch(_stringInput, @"^(X*([NSLO]+\d*)+X*)*$");
        }

        public string GetCoordinateError()
        {
            return ERROR_INPUT;
        }

        public string GetInput()
        {
            return _stringInput;
        }
    }
}
