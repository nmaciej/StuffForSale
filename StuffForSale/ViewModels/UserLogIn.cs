using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StuffForSale.ViewModels
{
  public class UserLogIn
  {
    [Required]
    public string Login { get; set; }

    [Required]
    [DataType(dataType: DataType.Password)]
    public string Password { get; set; }

    [Required]
    public bool RememberMe { get; set; }
  }
}
