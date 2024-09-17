using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.DAL.Models
{
    //Model
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="name is Required")]
        public string? Name { get; set; }
        [Range(25, 60, ErrorMessage = "Age between 25 and 60")]
        public int Age { get; set; }
       
        public string? Address { get; set; }

        [DataType(DataType.Currency)]//=====> $100
        public decimal Salary {  get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public bool IsActive {  get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfCreation { get; set; }= DateTime.Now;

        [ForeignKey("Department")]
        public int? DeptId { get; set; }//FK
        public Department? Department {  get; set; }//navigational property

    }
}
