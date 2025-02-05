﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        [ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
