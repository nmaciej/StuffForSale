using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffForSale.Models
{
  public class OrderDetail
  {
    [Key]
    public int OrderDetailId { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    //Foreign keys
    [Required]
    public int OrderId { get; set; }

    [Required]
    public int ProductId { get; set; }

    //Relations
    [ForeignKey("OrderId")]
    public Order Order { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }
  }
}
