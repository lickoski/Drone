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

        /// <summary>
        /// Verifica o estado do objeto e retorna se é válido ou não
        /// A validação da string de input é realizada por Regex, usei Regex para ter uma melhor performance e não necessitar fazer iteração na string 
        /// </summary>
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

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            this.Dispose();
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
    }
}
