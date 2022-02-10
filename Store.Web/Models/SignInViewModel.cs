using System.ComponentModel.DataAnnotations;

namespace Store.Web.Models
{
    public class SignInViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        public string PasswordAgain { get; set; }
    }
}
