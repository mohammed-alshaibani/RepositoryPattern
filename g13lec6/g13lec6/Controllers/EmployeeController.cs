using g13lec6.Models;
using g13lec6.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace g13lec6.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly group13Context _context;
        private readonly IRepository<Employee> repository;

        public EmployeeController( IRepository<Employee> repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(emp);
                }
                else
                {
                    var res = repository.Add(emp);
                    
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
                return View(emp);
            }
        }
    }
}
