using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{   /// <summary>
    /// Classe responsável por prover uma lista de Actions em sua ordem de criação
    /// Essa classe possui uma Injeção de dependência de IInput, fazendo com que a classe saiba implementar com base no contrato da interface
    /// </summary>
    public class ActionFactory : IDisposable
    {
        private readonly IInput _input;
        public ActionFactory(IInput input)
        {
            _input = input;
        }

        /// <summary>
        /// Retorna uma lista de Actions ordenada com base no Input injetado por dependência
        /// </summary>
        public List<Action> GetActionsInOrder()
        {
            var actions = new List<Action>();

            //Utiliza regex para separar as ações
            var inputActions = Regex.Matches(_input.GetInput(), @"([NSLO]\d*)|X");


            foreach (var item in inputActions)
            {
                //Separa as Actions dos Steps e fabrica um objeto Action válido
                var regexdirectionAndSteps = new Regex("(?<Direction>[a-zA-Z]*)(?<Steps>[0-9]*)");
                var directionAndSteps = regexdirectionAndSteps.Match(item.ToString());
                var direction = directionAndSteps.Groups["Direction"].Value.ToString();
                var steps = directionAndSteps.Groups["Steps"].Value;
                if (string.IsNullOrEmpty(steps)) steps = "1";

                var action = GetAction(direction, steps);
                actions.Add(action);
            }

            return RemoveCanceledAction(actions);
        }


        private Action GetAction(string direction, string steps)
        {
            Direction enumDirection;
            var teste = Enum.TryParse(direction, true, out enumDirection);

            int stepsInt;
            var stepValid = Int32.TryParse(steps, out stepsInt);
            if (!stepValid)
                throw new System.ArgumentException();

            return new Action(enumDirection, Convert.ToInt32(steps));
        }

        /// <summary>
        /// Implementa o cancelamento de ações na fila de Actions
        /// Retorna uma lista de actions com as ações que realmente devem ser executadas
        /// </summary>
        private List<Action> RemoveCanceledAction(List<Action> actions)
        {
            int accumulatorRemove = 0;

            for (int i = actions.Count - 1; i >= 0;)
            {
                if (actions[i].Direction == Direction.X)
                {
                    if (actions.Count > 1)
                    {
                        if (actions[i - 1].Direction != Direction.X)
                        {
                            actions.RemoveRange(i - 1, 2);
                            i -= 2;
                            continue;
                        }
                        else
                        {
                            actions.RemoveAt(i);
                            accumulatorRemove += 1;
                            i--;
                            continue;
                        }
                    }
                }
                else
                {
                    if (accumulatorRemove > 0)
                    {
                        actions.RemoveAt(i);
                        accumulatorRemove--;
                    }
                }
                i--;
            }

            return actions;
        }


        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
                this.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
