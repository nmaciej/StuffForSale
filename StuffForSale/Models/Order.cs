using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StuffForSale.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    [EnumDataType(typeof(OrderStateEnum))]
    public OrderStateEnum State { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string PostCode { get; set; }

    [Required]
    public string City { get; set; }

    //Foreign keys
    [Required]
    public string BuyerId { get; set; }

    [Required]
    public string SellerId { get; set; }

    //Relations
    [ForeignKey("BuyerId")]
    public User UserBuyer { get; set; }

    [ForeignKey("SellerId")]
    public User UserSeller { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; }
  }

  public enum OrderStateEnum
  {
    Completed = 0,
    Active = 1,
    Canceled = 2
  }
}
