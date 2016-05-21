

using Microsoft.Ajax.Utilities;

namespace WebApplication.Controllers
{
    using System.Drawing;
    using fmath.controls;
    using WebApplication.Service;
    using WebApplication.Service.lib_boolean_funcs;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using WebApplication.Service.auto_generating_mathtasks;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // Возвращает страничку тренажера
        public ActionResult Trenager()
        {
            ViewBag.Message = "Тренажер";

            return View();
        }
        
        public void initMathML()
        {

            string path = Server.MapPath("~/Service/lib_mathmlformula/");

            MathMLFormulaControl.setFolderUrlForFonts(path + "fonts");
            MathMLFormulaControl.setFolderUrlForGlyphs(path + "glyphs");
        }

        // Возвращает страничку тренажера
        public ActionResult LaTeX()
        {
            initMathML();

            return View();
        }

        // Генерируется задача в зависимости от присланного номера
        public ActionResult GetRequest(int id, int level)
        {
            var result = DeterminantComplexity.GenerateByLevel( id, level );
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        // Проверяется задача
        public JsonResult CheckRequest(int id, string reply, string generated)
        {
            ReturnResult result = null;
            switch (id)
            {
                case 0:
                    {
                        result = UnambiguousCodingService.CheckString01(reply,generated);
                        break;
                    }
                case 1:
                    {
                        result = PrefixCodeService.CheckString02(reply, generated);
                        break;
                    }
                case 2:
                    {
                        // Получим только первую часть(т.к. можно просто проверить на правило суффиксного/префиксного кода Фано, независимо от того, что сгенерировано справа)
                        var sub = generated.Split(new string[] { " / " }, StringSplitOptions.None);
                        result = UnambiguousCodingService.CheckString01(reply, sub[0]);
                        break;
                    }
                case 3:
                    {
                        result = HaffmaneService.CheckString04(reply, generated);
                        break;
                    }
                case 4:
                    {
                        try
                        {
                            result = HemmingService.CheckCode(generated, Int32.Parse(reply));

                        }
                        catch (Exception er)
                        {

                            result = new ReturnResult(false, "Error: " + er.Message);
                        }
                        break;
                    }
                default:
                {
                        result = new ReturnResult(false, "Error");
                        break;
                }
            }
            return Json(new { isRight = result.isRight, result = result.Data }, JsonRequestBehavior.AllowGet);
        }

        

        

        // Генерируем и возвращаем изображение // Генерируется задача в зависимости от присланного номера
        public string CheckBooleanFormulaInput(string formula, int operation)
        {
            formula = formula.Replace("{", "(!(");
            formula = formula.Replace("}", "))");
            formula = formula.Trim();

            try
            {
                if (operation == 0)
                {

                    List<BooleanVariable> variables = new List<BooleanVariable>();
                    BooleanFormula booleanFormula = BooleanFormulaParser.Parse(formula, variables);

                    return booleanFormula.ToLaTeXString();
                } else if (operation == 1)
                {

                    List<BooleanVariable> variables = new List<BooleanVariable>();
                    BooleanFormula booleanFormula = BooleanFormulaParser.Parse(formula, variables);

                    return BooleanFormulaService.CheckLatex(booleanFormula.ToLaTeXString());
                } else if (operation == 2)
                {

                    List<BooleanVariable> variables = new List<BooleanVariable>();
                    BooleanFormula booleanFormula = BooleanFormulaParser.Parse(formula, variables);

                    return BooleanFormulaService.CheckLatex(booleanFormula.GetZhegalkinPolynomial().ToLaTeXString());
                }
                else if (operation == 3)
                {

                    List<BooleanVariable> variables = new List<BooleanVariable>();
                    BooleanFormula booleanFormula = BooleanFormulaParser.Parse(formula, variables);

                    return BooleanFormulaService.CheckLatex(BooleanFormula.PerfectCNF(booleanFormula).ToLaTeXString());
                }else if (operation == 4)
                {

                    List<BooleanVariable> variables = new List<BooleanVariable>();
                    BooleanFormula booleanFormula = BooleanFormulaParser.Parse(formula, variables);

                    return BooleanFormulaService.CheckLatex(BooleanFormula.PerfectDNF(booleanFormula).ToLaTeXString());
                }
                else if (operation == 5)
                {

                    List<BooleanVariable> variables = new List<BooleanVariable>();

                    BooleanFunction booleanFunction = new BooleanFunction(1,1);
                    booleanFunction.SetNewBooleanFormula(BooleanFormulaParser.Parse(formula, variables));

                    return BooleanFormulaService.CheckLatex(booleanFunction.ToLaTeXBooleanTable());
                }
                else
                {
                    return BooleanFormulaService.CheckLatex("Not_selected_operation");
                }
            }
            catch (Exception e)
            {
                return BooleanFormulaService.CheckLatex("Error_in_formule!"); ;
            }
        }

        public ActionResult GetRandomBooleanFormula(int countVariables, int depthBound, int sizeBound, bool isByLatex)
        {
            initMathML();

            return Json(BooleanFormulaService.GetRandomBooleanFormulaWithParams(countVariables,depthBound,sizeBound,isByLatex), JsonRequestBehavior.AllowGet);
        }

    }
}