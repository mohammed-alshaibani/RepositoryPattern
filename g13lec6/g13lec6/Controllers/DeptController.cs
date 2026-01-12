using g13lec6.Models;
using g13lec6.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace g13lec6.Controllers
{
    public class DeptController : Controller
    {
        private readonly Repositories.IRepository<Dept> repository;

        public DeptController( IRepository<Dept> repository)
        {
            this.repository = repository;
        }
        // GET: DeptController
        public ActionResult Index()
        {
            var depts = repository.GetAll();
            return View(depts);
        }

        // GET: DeptController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeptController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeptController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dept dept)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(dept);
                }
                else
                {
                    var res = repository.Add(dept);
                    
                    TempData["msg"] = "تمت الاضافة بنجاح";
                    return RedirectToAction("Create");
                    //return RedirectToAction("Index", "Dept");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"=====Exp In Edit Dept Action");
                Console.WriteLine($"{ex.Message}");
                TempData["msg"] = "خطأ غير متوقع";
                return View(dept);
            }
        }

        // GET: DeptController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeptController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DeptController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeptController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
