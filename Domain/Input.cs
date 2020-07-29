using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public class Input
    {
        public string SringInput { get; private set; }

        private const string ERROR_INPUT = "(999, 999)";
        public Input(string input)
        {
            SringInput = input;
        }

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(SringInput)) return false;

            return Regex.IsMatch(SringInput, @"^(X*([NSLO]+\d*)+X*)*$");
        }

        public string GetCoordinateError()
        {
            return ERROR_INPUT;
        }
    }
}
