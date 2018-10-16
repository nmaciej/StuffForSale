using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffForSale.ViewModels
{
  public class UserRegister
  {
    [Required]
    public string Login { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(dataType:DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(dataType:DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string RepeatPassword { get; set; }

  }
}
