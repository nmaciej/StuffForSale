using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffForSale.Models;

namespace StuffForSale.ViewModels
{
  public class ProductAdd
  {
    public Product Product { get; set; }
    public Dictionary<int, string> Tags { get; set; }

    public ProductAdd()
    {
    }

    public ProductAdd(Product product, Dictionary<int, string> tags)
    {
      Product = product;
      Tags = tags;
    }
  }
}
