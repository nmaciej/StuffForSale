using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StuffForSale.Models;

namespace StuffForSale.ViewModels
{
  public class OrderSummary
  {
    public Order Order { get; set; }
    public List<OrderDetailSummary> OrderDetailsSummaryList { get; set; }
  }
}
