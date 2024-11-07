using InventoryManagementDemo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Controllers
{
    internal class TransactionController
    {
        InventoryService _service;
        public TransactionController(InventoryService service)
        {
            _service = service;
        }

        public void AddStock()
        {
            try
            {
                Console.Write("Enter product ID to add stock: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity to add: ");
                int quantity = int.Parse(Console.ReadLine());

                _service.AddStock(productId, quantity);
                Console.WriteLine("Stock added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void RemoveStock()
        {
            try
            {
                Console.Write("Enter product ID to remove stock: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter quantity to remove: ");
                int quantity = int.Parse(Console.ReadLine());

                _service.RemoveStock(productId, quantity);
                Console.WriteLine("Stock removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewTransactionHistory()
        {
            try
            {
                var transactions = _service.GetAllTransactions();
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"ID: {transaction.TransactionId}, ProductID: {transaction.ProductId}, Type: {transaction.Type}, Quantity: {transaction.Quantity}, Date: {transaction.Date}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
