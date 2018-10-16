using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using StuffForSale.Models;

namespace StuffForSale.ViewModels
{
  public class UserProfile
  {
    public UserProfile(User user, IEnumerable<Product> myProducts)
    {
      User = user;
      MyProducts = myProducts;
    }

    public User User { get; set; }
    public IEnumerable<Product> MyProducts { get; set; }
  }
}
