using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Service.lib_boolean_funcs
{
    public class BooleanFormulaGenerator
    {
        static void test()
        {

            InitRandomNumber(DateTime.Now.Millisecond);
            var variables = new List<BooleanVariable>();
            generateVariables(variables, 15);

            var function = generateRandomBooleanFunction(variables, 15);
            
        }

        static void generateVariables(List<BooleanVariable> variblesList, int count)
        {
            while (count > 0)
            {
                variblesList.Add(new BooleanVariable(((char)((int)'x' + 0)).ToString()));
                count--;
            }
        }

        private static Random random;
        private static object syncObj = new object();
        private static void InitRandomNumber(int seed)
        {
            random = new Random(seed);
        }
        private static int GenerateRandomNumber(int max)
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(max);
            }
        }

        static BooleanFormula generateRandomBooleanFunction(List<BooleanVariable> variblesList, int deep, int operationsHard = 8)
        {

            if (GenerateRandomNumber(10) % 2 == 0)
            {
                if (deep == 0)
                {
                    return new UnaryOperation(variblesList[GenerateRandomNumber(10) % variblesList.Count]);
                }
                else
                {
                    return new UnaryOperation(generateRandomBooleanFunction(variblesList, deep - 1, operationsHard));
                }
            }
            else
            {
                if (deep == 0)
                {
                    return new BinaryOperation((BooleanOperations)(GenerateRandomNumber(operationsHard) % operationsHard), variblesList[GenerateRandomNumber(10) % variblesList.Count], variblesList[GenerateRandomNumber(10) % variblesList.Count]);
                }
                else
                {
                    return new BinaryOperation((BooleanOperations)(GenerateRandomNumber(operationsHard) % operationsHard), generateRandomBooleanFunction(variblesList, deep - 1, operationsHard), generateRandomBooleanFunction(variblesList, deep - 1, operationsHard));
                }
            }
        }
    }
}