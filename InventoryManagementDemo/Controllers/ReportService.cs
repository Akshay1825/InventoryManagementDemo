using InventoryManagementDemo.Repo;
using InventoryManagementDemo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Controllers
{
    internal class ReportService
    {
        private readonly InventoryService _inventoryService;

        public ReportService(InventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public void GenerateReport()
        {
            try
            {
                Console.WriteLine("Generating Report...");

                var products = _inventoryService.GetAllProducts();
                var suppliers = _inventoryService.GetAllSuppliers();
                var transactions = _inventoryService.GetAllTransactions();

                int totalProducts = products.Count;
                decimal totalStockValue = products.Sum(p => p.Quantity * p.Price);

                int totalSuppliers = suppliers.Count;

                int totalTransactions = transactions.Count;

                Console.WriteLine("\nProduct Details:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price}, Total Value: {product.Quantity * product.Price}");
                }

                Console.WriteLine("\nSupplier Details:");
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"ID: {supplier.SupplierId}, Name: {supplier.Name}, Contact Info: {supplier.ContactInfo}");
                }

                Console.WriteLine("\nTransaction Details:");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"ID: {transaction.TransactionId}, Product ID: {transaction.ProductId}, Type: {transaction.Type}, Quantity: {transaction.Quantity}, Date: {transaction.Date}");
                }

                Console.WriteLine("\nReport Summary:");
                Console.WriteLine($"Total Products: {totalProducts}");
                Console.WriteLine($"Total Suppliers: {totalSuppliers}");
                Console.WriteLine($"Total Transactions: {totalTransactions}");
                Console.WriteLine($"Total Stock Value: {totalStockValue}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating report: {ex.Message}");
            }
        }
    }
}
