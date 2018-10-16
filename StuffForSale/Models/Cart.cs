using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StuffForSale.Models
{
  public class Cart
  {
    public List<CartLine> CartLinesCollection = new List<CartLine>();

    public virtual void AddItem(Product newItem, int quantity)
    {
      CartLine line = CartLinesCollection.FirstOrDefault(p => p.Product.ProductId == newItem.ProductId);

      if (line == null)
      {
        if (newItem.Quantity >= quantity)
        {
          CartLinesCollection.Add(new CartLine()
          {
            Product = newItem,
            Quantity = quantity
          });
        }
        else
        {
          CartLinesCollection.Add(new CartLine()
          {
            Product = newItem,
            Quantity = newItem.Quantity
          });
        }
      }
      else
      {
        if (newItem.Quantity >= line.Quantity + quantity)
        {
          line.Quantity += quantity;
        }
        else
        {
          line.Quantity = newItem.Quantity;
        }
      }
    }

    public virtual void RemoveItem(Product delItem, int quantity)
    {
      CartLine line = CartLinesCollection.FirstOrDefault(p => p.Product.ProductId == delItem.ProductId);

      if (line != null)
      {
        if (line.Quantity - quantity <=delItem.Quantity)
        {
          if (line.Quantity - quantity > 0)
          {
            line.Quantity -= quantity;
          }
          else
          {
            RemoveLine(delItem);
          }
        }
        else
        {
          line.Quantity = delItem.Quantity;
        }
      }
    }

    public virtual void RemoveLine(Product deleteItem)
    {
      CartLinesCollection.RemoveAll(d => d.Product.ProductId == deleteItem.ProductId);
    }

    public virtual double TotalValues()
    {
      return CartLinesCollection.Sum(i => i.Quantity * i.Product.Price);
    }

    public virtual int TotalQuantities()
    {
      return CartLinesCollection.Sum(l => l.Quantity);
    }

    public virtual void Clear()
    {
      CartLinesCollection.Clear();
    }

    public virtual IEnumerable<CartLine> Lines()
    {
      return CartLinesCollection;
    }
  }
  public class CartLine
  {
    public int CartlineId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }

    public double GetPrice()
    {
      return Quantity * Product.Price;
    }
  }
}
