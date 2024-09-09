using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class EmployeesController : Controller
    {
        // to get all data from database to view it in index
        // I have a method in department repository called GetAll()
        private readonly EmployeeRepository _repository;

        public EmployeesController(EmployeeRepository repository)//because when I make an object
                                                                    //of DepartmentController the department repository
                                                                    //be not equal to null
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var employee = _repository.GetAll();
            return View(employee);//send all data to index view
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)//match required condition I put on data in class Dep
            {
                var Count = _repository.Add(model);
                if (Count > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);

        }
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();//400 error

            var employee = _repository.Get(id.Value);
            if (employee == null) return NotFound();//404

            return View(employee);
        }
        // [HttpPost]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            var dep = _repository.Get(id.Value);
            if (dep == null)
            {
                return NotFound();
            }
            return View(dep);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, Employee model)
        {
            try
            {
                if (id != model.Id) return BadRequest();//400

                if (ModelState.IsValid)
                {
                    var result = _repository.Update(model);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            var emp = _repository.Get(id.Value);
            if (emp == null)
            {
                return NotFound();
            }
            _repository.Delete(emp);
            return RedirectToAction("Index");
        }
        //Refactoring ==> to avoid repeating in code
    }
}
