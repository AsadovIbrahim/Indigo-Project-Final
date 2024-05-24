using System.ComponentModel.DataAnnotations;

namespace Indigo_Web_Project.ViewModels
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
