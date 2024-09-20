using AutoMapper;
using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Models;
using Company.Route.PL.Helpers;
using Company.Route.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Collections.ObjectModel;

namespace Company.Route.PL.Controllers
{
    public class EmployeesController : Controller
    {
        // to get all data from database to view it in index
        // I have a method in department repository called GetAll()
        //private readonly EmployeeRepository _repository;
        //private readonly DepartmentRepository _repos;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(
            //EmployeeRepository repository 
            //,DepartmentRepository repos
             IUnitOfWork unitOfWork,
             IMapper mapper)//because when I make an object
                                                                    //of DepartmentController the department repository
                                                                    //be not equal to null
        {
            //_repository = repository;
            //_repos = repos;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string searchInput)
        {
            var employee = Enumerable.Empty<Employee>();
           
            if (string.IsNullOrEmpty(searchInput))
            { employee =_unitOfWork.EmployeeRepository.GetAll(); }
            else { employee = _unitOfWork.EmployeeRepository.GetByName(searchInput); }

          var Result =  _mapper.Map<IEnumerable<EmployeeViewModel>>(employee);//automatic mapping

            #region View Dictionary 
            //string Message = "Hello World";
            ////view's Dictionary :[Extra Information] Transfer Data from Action to view [one way]
            //// 1. ViewData: property Inherited from controller - Dictionary

            //ViewData["ziko"] = Message+ "from View Data";

            ////2. View Bag: Property INHERITED FROM Controller - Dictionary
            //ViewBag.Hamada = Message + "from view Bag";

            //// 3. TempData : property INherited from controller - Dictionary
            ////transfer for the data from request to another

            //TempData["Message01"] = Message + "From TempData"; 
            #endregion
            return View(Result);//send all data to index view

        }

        public IActionResult Create()
        {
           var department = _unitOfWork.DepartmentRepository.GetAll();//extra information
                                                                      //after I want to Send Message from this action to create view by ViewData
                                                                      //View Dictionary
            ViewData["Department"] = department;
            return View();

        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)//match required condition I put on data in class Dep
            {
                //to upload Image
                model.ImageName = DocumentSetting.UploadFile(model.Image, "images");


                // Casting : EmployeeViewModel => Employee
                //Manual Mapping
                #region Manual Mapping 
                //Employee employee = new Employee()
                //{
                //    Id = model.Id,
                //    Name = model.Name,
                //    Age = model.Age,
                //    Address = model.Address,
                //    Salary = model.Salary,
                //    PhoneNumber = model.PhoneNumber,
                //    Email = model.Email,
                //    IsActive = model.IsActive,
                //    IsDeleted = model.IsDeleted,
                //    DateOfCreation = model.DateOfCreation,
                //    HiringDate = model.HiringDate,
                //    DeptId= model.DeptId,
                //    Department = model.Department
                //}; 
                #endregion

                //Auto Mapping
                var employee = _mapper.Map<Employee>(model);

                var Count = _unitOfWork.EmployeeRepository.Add(employee);
                if (Count > 0)
                {
                   
                    TempData["Message"] = "Employee is created successfully";
                   
                }
                else 
                {
                    TempData["Message"] = "Employee isnot created ";

                }
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public IActionResult Details(int? id)
        {
            if (id is null) return BadRequest();//400 error

            var employee = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee == null) return NotFound();//404

            var Result = _mapper.Map<EmployeeViewModel>(employee);
            return View(Result);
        }
        // [HttpPost]
        public IActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            
            var dep = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (dep == null)
            {
                return NotFound();
            }
            var Result = _mapper.Map<EmployeeViewModel>(dep);
            var department = _unitOfWork.DepartmentRepository.GetAll();//extra information
            //after I want to Send Message from this action to create view by ViewData
            //View Dictionary
            ViewData["Department"] = department;
            
            return View(Result);
        }


       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, EmployeeViewModel model)
        {
            try
            {
               


                if (id != model.Id) return BadRequest();//400
               
                if (ModelState.IsValid)
                {
                    if (model.ImageName is not null)
                    {
                        DocumentSetting.DeleteFile(model.ImageName, "images");
                    }
                    model.ImageName = DocumentSetting.UploadFile(model.Image, "images");

                    var employee = _mapper.Map<Employee>(model);
                    var result = _unitOfWork.EmployeeRepository.Update(employee);
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
            var emp = _unitOfWork.EmployeeRepository.Get(id.Value);
            if (emp == null)
            {
                return NotFound();
            }
            _unitOfWork.EmployeeRepository.Delete(emp);
            return RedirectToAction("Index");
        }
        //Refactoring ==> to avoid repeating in code
    }
}
