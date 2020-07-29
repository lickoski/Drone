using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm.Logic.Domain
{
    public class ActionFactory
    {
        private readonly Input _input;
        public ActionFactory(Input input)
        {
            _input = input;
        }

        public List<Action> GetActionsInOrder()
        {
            var actions = new List<Action>();

            //UTILIZA UMA REGEX PARA SEPARAR AS AÇÕES A SE FAZER
            //ACHEI REGEX MELHOR FORMA DE SE EXTRAIR O DADO EM FORMA DE FILA
            var inputActions = Regex.Matches(_input.SringInput, @"([NSLO]\d*)|X");

            //PERCORRE AS AÇÕES
            foreach (var item  in inputActions)
            {   
                //NESTE PONTO É REALIZADO MAIS UMA REGEX PARA SEPARAR AS ACTIONS DOS STEPS
                //ASSIM FACULITANDO A CRIAÇÃO DA LISTA DE ACTIONS
                var regexdirectionAndSteps = new Regex("(?<Direction>[a-zA-Z]*)(?<Steps>[0-9]*)");
                var directionAndSteps = regexdirectionAndSteps.Match(item.ToString());
                var direction = directionAndSteps.Groups["Direction"].Value.ToString();
                var steps = directionAndSteps.Groups["Steps"].Value;

                if (string.IsNullOrEmpty(steps)) steps = "1";
                
                //FORMA DE TRABALHAR COM O CHAR DO ENUM
                Direction  enumDirection;
                var teste = Enum.TryParse(direction, true, out enumDirection);

                var action = new Action(enumDirection, Convert.ToInt32(steps));

                actions.Add(action);
            }
            
            return actions;
        }

    }
}
