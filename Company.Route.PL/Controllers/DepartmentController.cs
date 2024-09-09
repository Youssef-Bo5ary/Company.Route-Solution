using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Route.PL.Controllers
{
    public class DepartmentController : Controller
    {
        // to get all data from database to view it in index
        // I have a method in department repository called GetAll()
        private readonly DepartmentRepository _repository;

        public DepartmentController(DepartmentRepository repository)//because when I make an object
                                                                    //of DepartmentController the department repository
                                                                    //be not equal to null
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var departments = _repository.GetAll();
            return View(departments);//send all data to index view
        }

        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Department model) 
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

             var department= _repository.Get(id.Value);
            if (department == null) return NotFound();//404

               return View(department);
        }
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
        public IActionResult Edit(int id, Department model)
        {

            if (ModelState.IsValid)
            {
                var result = _repository.Update(model);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

    }
}
