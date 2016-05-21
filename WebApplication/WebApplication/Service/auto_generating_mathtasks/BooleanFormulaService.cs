using System;
using System.Drawing;
using System.Web.Helpers;
using System.Web.Mvc;
using fmath.controls;
using WebApplication.Service.lib_boolean_funcs;

namespace WebApplication.Service.auto_generating_mathtasks
{
    public class BooleanFormulaService
    {
        public static object GetRandomBooleanFormulaWithParams(int countVariables, int depthBound, int sizeBound, bool isByLatex)
        {
            BooleanFormula booleanFormula = BooleanFormula.RandomFormula(countVariables, sizeBound, depthBound);

            BooleanFunction booleanFunction = new BooleanFunction(1, 1);
            booleanFunction.SetNewBooleanFormula(booleanFormula);

            var data = new
            {
                result = isByLatex ? booleanFormula.ToLaTeXString() : CheckLatex(booleanFormula.ToLaTeXString()),

                isMonotone = booleanFunction.IsMonotone(),
                isBalanced = booleanFunction.IsBalanced(),
                isLinear = booleanFunction.IsLinear(),

                isSelfAdjoint = booleanFunction.IsSelfAdjoint(),// Самосопряженная
                isComplete = booleanFunction.IsComplete(),
                isBasis = booleanFunction.IsBasis()
            };

            return data;
        }

        public static object GetRandomBooleanFormula(int countVariables, int depthBound, int sizeBound)
        {
            BooleanFormula booleanFormula = BooleanFormula.RandomFormula(countVariables, sizeBound, depthBound);

            BooleanFunction booleanFunction = new BooleanFunction(1, 1);
            booleanFunction.SetNewBooleanFormula(booleanFormula);
            
            return  CheckLatex(booleanFormula.ToLaTeXString());
        }

        // Генерируем и возвращаем изображение // Генерируется задача в зависимости от присланного номера
        public static string CheckLatex(string code)
        {
            Bitmap bmp = MathMLFormulaControl.generateBitmapFromLatex(code);

            ImageConverter converter = new ImageConverter();
            var bytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

            return Convert.ToBase64String(bytes);
        }

        public static object GetRandomBooleanFormulaByLevel(int id, int level)
        {
            return GetRandomBooleanFormulaWithParams(level + 3, level + 3, level + 3, false);
        }
    }
}