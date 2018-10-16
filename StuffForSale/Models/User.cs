using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace StuffForSale.Models
{
  public class User : IdentityUser
  {
    
    public ICollection<Product> Products { get; set; }

    [InverseProperty("UserBuyer")]
    public ICollection<Order> BuyerOrders { get; set; }

    [InverseProperty("UserSeller")]
    public ICollection<Order> SellerOrders { get; set; }
  }
}