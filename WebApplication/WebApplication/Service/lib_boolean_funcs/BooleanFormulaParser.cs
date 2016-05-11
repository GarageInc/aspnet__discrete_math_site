using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Service.lib_boolean_funcs
{
    public class BooleanFormulaParser
    {

        // ReSharper disable once InconsistentNaming
        public const char NOT = '!';
        // ReSharper disable once InconsistentNaming
        public const char SHEFFER_STROKE = '|';
        // ReSharper disable once InconsistentNaming
        public const char PIERCE_ARROW = '#';
        // ReSharper disable once InconsistentNaming
        public const char AND = '*';
        // ReSharper disable once InconsistentNaming
        public const char OR = '+';
        // ReSharper disable once InconsistentNaming
        public const char XOR = '^';
        // ReSharper disable once InconsistentNaming
        public const char IMPLICATION = '~';
        // ReSharper disable once InconsistentNaming
        public const char IDENTITY = '%';
        // ReSharper disable once InconsistentNaming
        public const char EQUIVALENCE = '=';

        // ReSharper disable once InconsistentNaming
        public const char LEFT_PARENTHESIS = '(';
        // ReSharper disable once InconsistentNaming
        public const char RIGHT_PARENTHESIS = ')';

        // Принимается строка с уже искусственно заданными приоритетами: любые два аргумента окружены скобочками, иначе - ошибка. 
        // Унарная операция(отрицание) возможна без скобочек 
        public static BooleanFormula Parse(string formula, List<BooleanVariable> variables)
        {
            // Отдельно обрабатываем импликацию
            if (formula[0] == NOT)
            {
                // вырежем и отправим без скобочек
                if (formula[1] == LEFT_PARENTHESIS && formula[formula.Length - 1] == RIGHT_PARENTHESIS)
                    return new UnaryOperation(Parse(formula.Substring(2, formula.Length - 3), variables));
                else
                    return new UnaryOperation(Parse(formula.Substring(1, formula.Length - 1), variables));
            }
            else
            {
                // (x&x)&(x&y)
                // (x&x)&y
                // x&(x&x)
                // x&x&y - error

                // x
                if (!containsNotExecutableSymbol(formula))
                {
                    return getBooleanVariable(variables, formula);
                }
                else
                {
                    // прочитаем переменную
                    string variableName = string.Empty;
                    int i = 0;
                    while (i < formula.Length && canBeVariableSymbol(formula[i]))
                    {
                        variableName += formula[i];
                        i++;
                    }

                    BooleanFormula leftArgument;

                    if (variableName != String.Empty)
                    {
                        leftArgument = getBooleanVariable(variables, variableName);
                    }
                    else
                    {
                        int counter = 1;
                        int j = i + 1;
                        var subFormula = "";
                        while (counter != 0 && j < formula.Length)
                        {
                            if (formula[j] == LEFT_PARENTHESIS)
                                counter++;
                            else if (formula[j] == RIGHT_PARENTHESIS)
                                counter--;

                            if (counter != 0)
                                subFormula += formula[j];

                            j++;
                        }
                        leftArgument = Parse(subFormula, variables);

                        i = j;
                        // + сместили индекс i
                    }

                    char operation = formula[i++];// Прочитали символ после переменной

                    variableName = String.Empty;

                    while (i < formula.Length && canBeVariableSymbol(formula[i]))
                    {
                        if (i < formula.Length)
                        {
                            variableName += formula[i];
                            // readed;
                            i++;
                        }
                    }

                    BooleanFormula rightArgument;
                    if (variableName != String.Empty)
                    {
                        rightArgument = getBooleanVariable(variables, variableName);
                    }
                    else
                    {
                        int counter = 1;
                        int j = i + 1;
                        var subFormula = "";
                        while (counter != 0 && j < formula.Length)
                        {
                            if (formula[j] == LEFT_PARENTHESIS)
                                counter++;
                            else if (formula[j] == RIGHT_PARENTHESIS)
                                counter--;

                            if (counter != 0)
                                subFormula += formula[j];

                            j++;
                        }
                        rightArgument = Parse(subFormula, variables);
                    }

                    return new BinaryOperation(GetOperation(operation), leftArgument, rightArgument);
                }
            }
        }

        public static bool canBeVariableSymbol(char readed)
        {
            return readed != NOT && readed != SHEFFER_STROKE && readed != PIERCE_ARROW && readed != AND && readed != OR &&
                   readed != XOR && readed != IMPLICATION && readed != IDENTITY && readed != EQUIVALENCE &&
                   readed != LEFT_PARENTHESIS && readed != RIGHT_PARENTHESIS;
        }

        public static bool containsNotExecutableSymbol(string formula)
        {
            return formula.Contains(NOT) || formula.Contains(SHEFFER_STROKE) || formula.Contains(PIERCE_ARROW) || formula.Contains(AND) || formula.Contains(OR) ||
                   formula.Contains(XOR) || formula.Contains(IMPLICATION) || formula.Contains(IDENTITY) || formula.Contains(EQUIVALENCE) ||
                   formula.Contains(LEFT_PARENTHESIS) || formula.Contains(RIGHT_PARENTHESIS);
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