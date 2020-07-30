using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public class ActionFactory
    {
        private readonly IInput _input;

        public ActionFactory(IInput input)
        {
            _input = input;
        }

        public List<Action> GetActionsInOrder()
        {
            var actions = new List<Action>();

            //UTILIZA UMA REGEX PARA SEPARAR AS AÇÕES A SE FAZER
            //ACHEI REGEX MELHOR FORMA DE SE EXTRAIR O DADO EM FORMA DE FILA
            var inputActions = Regex.Matches(_input.GetInput(), @"([NSLO]\d*)|X");

            //PERCORRE AS AÇÕES
            foreach (var item in inputActions)
            {
                //NESTE PONTO É REALIZADO MAIS UMA REGEX PARA SEPARAR AS ACTIONS DOS STEPS
                //ASSIM FACILITANDO A CRIAÇÃO DA LISTA DE ACTIONS
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

    }
}
