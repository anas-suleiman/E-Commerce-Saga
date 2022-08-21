using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Saga.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Email field is requiered")]
        [MinLength(3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is requiered")]
        [MinLength(1)]
        public string Password { get; set; }

        [Required(ErrorMessage = "ShopName field is requiered")]
        [MinLength(1)]
        public string ShopName { get; set; }

        [Required(ErrorMessage = "ProductName field is requiered")]
        [MinLength(1)]
        public string ProductName { get; set; }
    }
}
