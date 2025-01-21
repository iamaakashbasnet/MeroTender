using System.ComponentModel.DataAnnotations;

namespace MeroTender.Models;

public class UserLoginModel
{
    [Required(ErrorMessage = "Email or Username is required")]
    [Display(Name = "Email or Username")]
    public string EmailOrUsername { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}