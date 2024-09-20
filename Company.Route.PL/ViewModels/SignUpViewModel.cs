using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.Route.PL.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="UserName is Required !")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "FirstName is Required !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName is Required !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required !")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "UserName is Required !")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required(ErrorMessage = "UserName is Required !")]
        [PasswordPropertyText]
        [Compare(nameof(Password), ErrorMessage ="Password doesnot match with first Password")]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
