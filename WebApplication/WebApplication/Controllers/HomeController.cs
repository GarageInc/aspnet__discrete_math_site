
using System.Drawing;
using fmath.controls;

namespace WebApplication.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.WebPages;
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
        public JsonResult GetRequest(int id)
        {
            string result = "";
            switch (id)
            {
                case 0:
                    {
                        result = UnambiguousCodingService.GetRandomOneZeroString();
                        break;
                    }
                case 1:
                    {
                        result = PrefixCodeService.CheckIsDecodedByCode(1);
                        break;
                    }
                case 2:
                    {
                        result = PrefixCodeService.CheckIsDecodedByCode(2);
                        break;
                    }
                case 3:
                    {
                        result = UnambiguousDecodingService.GetDecodingCodeAndCode();
                        break;
                    }
                case 4:
                    {
                        result = HaffmaneService.GetRandomNumbersString();
                        break;
                    }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        


        // Проверяется задача
        public JsonResult CheckRequest(int id, string reply, string generated)
        {
            string result = "yes!";
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
                        result = PrefixCodeService.CheckString02(reply, generated);
                        break;
                    }
                case 3:
                    {
                        // Получим только первую часть(т.к. можно просто проверить на правило суффиксного/префиксного кода Фано, независимо от того, что сгенерировано справа)
                        var sub = generated.Split(new string[] { " / " }, StringSplitOptions.None);
                        result = UnambiguousCodingService.CheckString01(reply, sub[0]);
                        break;
                    }
                case 4:
                    {
                        result = HaffmaneService.CheckString04(reply, generated);
                        break;
                    }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        // Генерируем и возвращаем изображение // Генерируется задача в зависимости от присланного номера
        public string CheckLatex(string code)
        {
            Bitmap bmp = MathMLFormulaControl.generateBitmapFromLatex(code);
            
            ImageConverter converter = new ImageConverter();
            var bytes = (byte[])converter.ConvertTo(bmp, typeof(byte[]));
            
            return Convert.ToBase64String(bytes);
        }
    }
}