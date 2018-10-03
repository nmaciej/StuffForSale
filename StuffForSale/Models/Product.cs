﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace StuffForSale.Models
{
  public class Product
  {
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    public DateTime DateAdded { get; set; }

    [Required]
    public int TagId { get; set; }

    //Relations
    [ForeignKey("TagId")]
    public Tag Tag { get; set; }

    //Constructors

    public Product(string userId)
    {
      UserId = userId;
    }

    public Product(int productId, string name, string description, double price, int quantity, string userId, DateTime dateAdded)
    {
      ProductId = productId;
      Name = name;
      Description = description;
      Price = price;
      Quantity = quantity;
      UserId = userId;
      DateAdded = dateAdded;
    }

    public Product()
    {
    }
  }
}
