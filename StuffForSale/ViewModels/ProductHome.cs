using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffForSale.ViewModels
{
  public class ProductHome
  {
    public int ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public double Price { get; set; }

    public int Quantity { get; set; }

    public DateTime DateAdded { get; set; }

    public int TagId { get; set; }

    public string Tag { get; set; }

    public string SellerId { get; set; }

    public string Seller { get; set; }

    public string UserId { get; set; }
  }
}
