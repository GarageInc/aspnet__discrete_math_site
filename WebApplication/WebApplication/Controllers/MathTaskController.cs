using System.Drawing;
using fmath.controls;
using Microsoft.Ajax.Utilities;

namespace WebApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WebApplication.Models;
    using Microsoft.AspNet.Identity;
    using System.Web.WebPages;

    public class MathTaskController : Controller
    {
        protected ApplicationDbContext Db { get; } = new ApplicationDbContext();

        public ActionResult Index()
        {
            IEnumerable<MathTask> allReqs = null;
            
                allReqs = Db.Requests
                    //.Where(x=>x.Checked)
                    ;

            return View(allReqs.ToList());
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            initMathML();
            var curId = HttpContext.User.Identity.GetUserId();

            // получаем текущего пользователя
            ApplicationUser user = Db.Users.FirstOrDefault(m => m.Id == curId);

            if (user != null)
            {
                SelectList mathTaskTypes = new SelectList(Db.MathTaskTypes, "Id", "Name");
                ViewBag.MathTaskTypes = mathTaskTypes;
                
                return View();
            }

            return RedirectToAction("LogOff", "Account");
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateMassControlWork()
        {
            initMathML();
            var curId = HttpContext.User.Identity.GetUserId();

            // получаем текущего пользователя
            ApplicationUser user = Db.Users.FirstOrDefault(m => m.Id == curId);

            if (user != null)
            {
                SelectList mathTaskTypes = new SelectList(Db.MathTaskTypes, "Id", "Name");
                ViewBag.MathTaskTypes = mathTaskTypes;

                SelectList studentsGroups = new SelectList(Db.StudentsGroups, "Id", "Name");
                ViewBag.StudentsGroups = studentsGroups;

                return View();
            }

            return RedirectToAction("LogOff", "Account");
        }

        
        [HttpPost]
        [Authorize]
        public ActionResult CreateMassControlWork(MathTask mathTask, HttpPostedFileBase file)
        {
            initMathML();
            var curId = HttpContext.User.Identity.GetUserId();

            // получаем текущего пользователя
            ApplicationUser user = Db.Users.FirstOrDefault(m => m.Id == curId);

            if (user == null)
            {
                return RedirectToAction("LogOff", "Account");
            }

            if (ModelState.IsValid)
            {
                TryCreate(user, mathTask, file);

                return RedirectToAction("Index");
            }

            return View(mathTask);
        }

        protected void TryCreate(ApplicationUser user, MathTask mathTask, HttpPostedFileBase file)
        {
            //получаем время открытия
            DateTime current = DateTime.Now;

            Document doc = null;

            // если получен файл
            if (file != null)
            {
                string fileName = current.ToString(user.Id.GetHashCode() + "dd/MM/yyyy H:mm:ss").Replace(":", "_").Replace("/", ".").Replace(" ", "_");
                string path = Server.MapPath("~/Files/RequestFiles/" + fileName);
                string ext = "png";

                if (!mathTask.LatexCode.IsNullOrWhiteSpace())
                {
                    Bitmap bmp = MathMLFormulaControl.generateBitmapFromLatex(mathTask.LatexCode);

                    path = path + ext;

                    bmp.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                    bmp.Dispose();
                }
                else
                {
                    doc = new Document();

                    doc.Size = file.ContentLength;

                    // Получаем расширение
                    ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    path = path + ext;

                    doc.Type = ext;
                    // сохраняем файл по определенному пути на сервере
                    file.SaveAs(path);
                    doc.Url = path;
                }
            }

            if (mathTask.StudentsGroupId != null)
            {
                var students = Db.Users.Where(x => x.Id == mathTask.StudentsGroupId.ToString());

                foreach (var student in students)
                {
                    mathTask.Executors.Add(student);
                }
            }

            // указываем автора задачи
            mathTask.Author = user;
            mathTask.AuthorId = user.Id;

            // если получен файл
            if (file != null)
            {
                mathTask.Document = doc;
                Db.Documents.Add(doc);
            }
            else
                mathTask.Document = null;

            mathTask.Status = (int)MathTaskStatus.Open;

            //Добавляем задачу с возможно приложенными документами
            Db.Requests.Add(mathTask);
            user.MathTasks.Add(mathTask);

            Db.Entry(user).State = EntityState.Modified;

            try
            {
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void initMathML()
        {

            string path = Server.MapPath("~/Service/lib_mathmlformula/");

            MathMLFormulaControl.setFolderUrlForFonts(path + "fonts");
            MathMLFormulaControl.setFolderUrlForGlyphs(path + "glyphs");
        }

        // Создание новой задачи
        [HttpPost]
        [Authorize]
        public ActionResult Create(MathTask mathTask, HttpPostedFileBase file)
        {
            initMathML();
            var curId = HttpContext.User.Identity.GetUserId();

            // получаем текущего пользователя
            ApplicationUser user = Db.Users.FirstOrDefault(m => m.Id == curId);

            if (user == null)
            {
                return RedirectToAction("LogOff", "Account");
            }

            if (ModelState.IsValid)
            {
                TryCreate(user, mathTask, file);
                
                return RedirectToAction("Index");
            }

            return View(mathTask);
        }
        

        
        /// <summary>
        /// Получение задач текущего пользователя
        /// </summary>
        /// <returns></returns>
        //[Authorize]
        public ActionResult MyIndex()
        {
            var currentId = HttpContext.User.Identity.GetUserId();
            // получаем текущего пользователя
            ApplicationUser user = Db.Users.FirstOrDefault(m => m.Id == currentId);
            IEnumerable<MathTask> allReqs = null;
                allReqs = Db.Requests
                    .Where(r => r.Author.Id == user.Id) //получаем задачи для текущего пользователя
                    .Include(r => r.Author)// добавляем данные о пользователях
                    .Include(r=>r.RightMathTaskSolution)
                    .ToList();         
            
            return View(allReqs);
        }


        /// <summary>
        /// Просмотр подробных сведений о задаче
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MyDetails(int id)
        {
            MathTask request = Db.Requests.Find(id);

            if (request != null)
            {
                //получаем категорию
                return PartialView("_Details", request);
            }
            return View("MyIndex");
        }

        //[Authorize]
        public ActionResult MyExecutor(string id)
        {
            ApplicationUser executor = Db.Users.First(m => m.Id == id);

            if (executor != null)
            {
                return PartialView("_Executor", executor);
            }
            return View("MyIndex");
        }
        
        // Удаление задачи
        //[Authorize]
        public ActionResult MyDelete(int id)
        {
            MathTask request = Db.Requests.Find(id);
            // получаем текущего пользователя
            var curId = HttpContext.User.Identity.GetUserId();
            ApplicationUser user = Db.Users.First(m => m.Id == curId);
            if (request != null && request.Author.Id == user.Id)
            {
                Db.SaveChanges();
            }
            return RedirectToAction("MyIndex");
        }

        

        /// <summary>
        /// Скачивание файла
        /// </summary>
        /// <returns></returns>
        public FileResult Download(int id)
        {
            var req = Db.Requests.Find(id);
            var reqDoc = req.Document;
            
                byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Files/RequestFiles/" + reqDoc.Url));
                string fileName = req.Id + reqDoc.Type;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        
        /// <summary>
        /// Просмотр подробных сведений о задаче
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            MathTask request = Db.Requests.Find(id);

            if (request != null)
            {
                //получаем категорию
                return PartialView("_Details", request);
            }
            return View("Index");
        }

        //[Authorize]
        public ActionResult Author(string id)
        {
            ApplicationUser executor = Db.Users.First(m => m.Id == id);

            if (executor != null)
            {
                return PartialView("_Executor", executor);
            }
            return View("Index");
        }

        //[Authorize]
        public ActionResult Executor(string id)
        {
            ApplicationUser executor = Db.Users.First(m => m.Id == id);

            if (executor != null)
            {
                return PartialView("_Executor", executor);
            }
            return View("Index");
        }

        //[Authorize]
        public ActionResult Lifecycle(int id)
        {
            return View("Index");
        }

        // Удаление задачи
        //[Authorize]
        public ActionResult Delete(int id)
        {
            MathTask request = Db.Requests.Find(id);
            var curId = HttpContext.User.Identity.GetUserId();
            // получаем текущего пользователя
            ApplicationUser user = Db.Users.First(m => m.Id == curId);
            if (request != null && request.Author.Id == user.Id)
            {
                Db.Requests.Remove(request);
                Db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Статистика
        /// </summary>
        /// <returns></returns>
        public ActionResult GetCountOfAllRequests()
        {
            string count = Db.Requests.Count().ToString();
            ViewBag.Message = count;
            return PartialView("Message");
        }

        public ActionResult GetCountOfAllUsers()
        {
            string count = Db.Users.Count().ToString();
            ViewBag.Message = count;
            return PartialView("Message");
        }
        
        [HttpPost]
        //[Authorize(Roles = "Модератор")]
        //[Authorize(Roles = "Administrator")]
        //[Authorize]
        public ActionResult MySelfDistribute(int? requestId, string executorId)
        {
            if (requestId == null && executorId.IsEmpty())// == null)
            {
                return RedirectToAction("MyIndex");
            }
            MathTask req = Db.Requests.Find(requestId);
            ApplicationUser ex = Db.Users.Find(executorId);
            if (req == null && ex == null)
            {
                return RedirectToAction("MyIndex");
            }

            req.Status = (int)MathTaskStatus.Distributed;

            Db.Entry(req).State = EntityState.Modified;
            Db.SaveChanges();

            return RedirectToAction("MyIndex");
        }
    }



}
