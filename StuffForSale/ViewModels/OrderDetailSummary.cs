using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using StuffForSale.Models;

namespace StuffForSale.ViewModels
{
  public class OrderDetailSummary
  {
    [Key]
    public int OrderDetailId { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    //Foreign keys
    [Required]
    public int OrderId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; }

    [Required]
    public string SellerId { get; set; }
    
    [Required]
    public string SellerName { get; set; }

  }
}
