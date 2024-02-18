using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_practice.Interface;
using mvc_practice.Models;

namespace mvc_practice.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

    
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeeController/Details/5
        public ActionResult Get()
        {
            //EmployeeDetails emp1 = new EmployeeDetails();
            //List<EmployeeDetails> emp = new List<EmployeeDetails>();
            //emp = emp1.Get();
            var emp = _employeeInterface.Get();
            return View(emp);

            
        }

        public ActionResult GetById(string LoginName)
        {
            var emp1 = _employeeInterface.GetById(LoginName);
            return View(emp1);


        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeClass employee)
        {
            _employeeInterface.Insert(employee);
            //return View(employee);
            return RedirectToAction("Get");
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string LoginName)
        {
            var emp = _employeeInterface.GetById(LoginName);
            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeClass employee)
        {
            _employeeInterface.Update(employee);
            return View(employee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(string LoginName)
        {
            //EmployeeDetails emp = new EmployeeDetails();
            var emp = _employeeInterface.GetById(LoginName);
            return View(emp);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeClass employee)
        {
            _employeeInterface.Delete(employee.LoginName);
            return RedirectToAction("Get");
        }

    }
}
