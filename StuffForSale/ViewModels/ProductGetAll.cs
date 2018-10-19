using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffForSale.Models;

namespace StuffForSale.ViewModels
{
  public class ProductGetAll
  {
    public List<Product> ProductList { get; set; }
    public string Tag { get; set; }
    public int CurrentPage { get; set; }
    public int PerPage { get; set; }
    public int Items { get; set; }
    public int Pages { get; set; }
  }
}
