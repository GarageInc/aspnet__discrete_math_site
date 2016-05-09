using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Service.lib_boolean_funcs
{
    public class BooleanFormulaParser
    {
        /*
                    <tr><td>!</td><td>¬</td><td class="tal">Отрицание(НЕ)</td></tr>
                    <tr><td>|</td><td>|</td><td class="tal">Штрих Шеффера(И-НЕ)</td></tr>
                    <tr><td>#</td><td>↓</td><td class="tal">Стрелка Пирса (ИЛИ-НЕ)</td></tr>
                    <tr><td>*</td><td>&amp;</td><td class="tal">Конъюнкция(И)</td></tr>
                    <tr><td>+</td><td>v</td><td class="tal">Дизъюнкция(ИЛИ)</td></tr>
                    <tr><td>^</td><td>®</td><td class="tal">Исключающее ИЛИ, сумма по модулю 2 (XOR)</td></tr>
                    <tr><td>~</td><td>→</td><td class="tal">Импликация(ЕСЛИ-ТО)</td></tr>
                    <tr><td>%</td><td>←</td><td class="tal">Обратная импликация</td></tr>
                    <tr><td>=</td><td>≡</td><td class="tal">Эквивалентность(РАВНО)</td></tr>
                    */

        public const char NOT = '!';
        public const char SHEFFER_STROKE = '|';
        public const char PIERCE_ARROW = '#';
        public const char AND = '*';
        public const char OR = '+';
        public const char XOR = '^';
        public const char IMPLICATION = '~';
        public const char IDENTITY = '%';
        public const char EQUIVALENCE = '=';

        public static BooleanFormula Parse(string formula, List<BooleanVariable> variables)
        {
            if (formula[0] == NOT)
            {
                // вырежем и отправим без скобочек
                return Parse(formula.Substring(2, formula.Length - 2), variables);
            }
            else
            {
                // x&y
                // x&(x&y) 
                // (x&x)&(x&y)
                // (x&x)&y
                // x&x&y - в последнюю очередь


                // прочитаем переменную
                string variableName = string.Empty;
                char readed = formula[0];
                int i = 1;
                while (i < formula.Length && 
                       readed != NOT && readed != SHEFFER_STROKE && readed != PIERCE_ARROW && readed != AND && readed != OR &&
                       readed != XOR && readed != IMPLICATION && readed != IDENTITY && readed != EQUIVALENCE)
                {
                    variableName += readed;
                    readed = formula[i];
                    i++;
                }

                BooleanVariable booleanVariable1 = getBooleanVariable(variables, variableName);

                i++;
                readed = formula[i];
                
                variableName = string.Empty;
                while (i < formula.Length &&
                       readed != NOT && readed != SHEFFER_STROKE && readed != PIERCE_ARROW && readed != AND && readed != OR &&
                       readed != XOR && readed != IMPLICATION && readed != IDENTITY && readed != EQUIVALENCE)
                {
                    variableName += readed;
                    readed = formula[i];
                    i++;
                }

                BooleanVariable booleanVariable2 = getBooleanVariable(variables, variableName);
                
                return new BinaryOperation(GetOperation(readed), booleanVariable1, booleanVariable2);
            }
        }

        public static BooleanOperations GetOperation(char readed)
        {
            switch (readed)
            {
                case NOT:
                    {
                        return BooleanOperations.NOT;
                    }
                case SHEFFER_STROKE:
                    {
                        return BooleanOperations.SHEFFER_STROKE;
                    }
                case PIERCE_ARROW:
                    {
                        return BooleanOperations.PIERCE_ARROW;
                    }
                case AND:
                    {
                        return BooleanOperations.AND;
                    }
                case OR:
                    {
                        return BooleanOperations.OR;
                    }
                case XOR:
                    {
                        return BooleanOperations.XOR;
                    }
                case IMPLICATION:
                    {
                        return BooleanOperations.IMPLICATION;
                    }
                case EQUIVALENCE:
                    {
                        return BooleanOperations.EQUIVALENCE;
                    }
                default:
                    {
                        return BooleanOperations.IDENTITY;
                    }
            }

        }

        public static BooleanVariable getBooleanVariable(List<BooleanVariable> variables, string name)
        {
            foreach (var variable in variables)
            {
                if (variable.Name == name)
                {
                    return variable;
                }

            }

            var newBooleanVariable = new BooleanVariable(name);
            variables.Add(newBooleanVariable);

            return newBooleanVariable;
        }

    }
}