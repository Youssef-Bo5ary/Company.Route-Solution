using Company.Route.DAL.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Company.Route.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

       
        public string? Name { get; set; }
       
        public int Age { get; set; }

        public string? Address { get; set; }

       
        public decimal Salary { get; set; }

       
        public string? Email { get; set; }
       
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

       
        public int? DeptId { get; set; }//FK
        public Department? Department { get; set; }//navigational property
        public IFormFile? Image { get; set; }
        public string? ImageName { get; set; }
    }
}
