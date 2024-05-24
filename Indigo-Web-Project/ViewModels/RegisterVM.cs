using System.ComponentModel.DataAnnotations;

namespace Indigo_Web_Project.ViewModels
{
    public class RegisterVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
        [DataType(DataType.Password),Compare(nameof(Password))]

        public string ConfirmPassword { get; set; }
    }
}
