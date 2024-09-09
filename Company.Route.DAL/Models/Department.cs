using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Code is Required!")]
        public string code { get; set; }
        [Required(ErrorMessage = "Nmae is Required!")]
        public string Name { get; set; }
        [DisplayName("Date of Creation")] //display it in DB
        public DateTime DateOfCreation { get; set; }
    }
}
