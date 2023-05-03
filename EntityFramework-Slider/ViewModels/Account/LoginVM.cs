using System.ComponentModel.DataAnnotations;

namespace EntityFramework_Slider.ViewModels.Account
{
    public class LoginVM
    {
        [Required]
        public string EmailorUsername { get; set; }
        [Required]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string Password { get; set; }
    }
}
