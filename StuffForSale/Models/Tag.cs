using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StuffForSale.Models
{
  public class Tag
  {
    [Key]
    public int TagId { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
  }
}
