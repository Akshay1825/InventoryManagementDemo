using InventoryManagementDemo.Repo;
using InventoryManagementDemo.Models;
using InventoryManagementDemo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Controllers
{
    internal class ProductController
    {
        InventoryService _service;
        public ProductController(InventoryService service)
        {
            _service = service;
        }

        public void AddProduct()
        {
            try
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine();

                Console.Write("Enter description: ");
                string description = Console.ReadLine();

                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter price: ");
                int price = int.Parse(Console.ReadLine());

                var product = new Product
                {
                    Name = name,
                    Description = description,
                    Quantity = quantity,
                    Price = price,
                    InventoryId = 1
                };
                
                _service.AddProduct(product);
                Console.WriteLine("Product added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateProduct()
        {
            try
            {
                Console.Write("Enter product ID to update: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();

                Console.Write("Enter new description: ");
                string newDescription = Console.ReadLine();

                Console.Write("Enter new price: ");
                int newPrice = int.Parse(Console.ReadLine());

                _service.UpdateProduct(productId, newName, newDescription, newPrice);
                Console.WriteLine("Product updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteProduct()
        {
            try
            {
                Console.Write("Enter product ID to delete: ");
                int productId = int.Parse(Console.ReadLine());
                _service.DeleteProduct(productId);
                Console.WriteLine("Product deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewProductDetails()
        {
            try
            {
                Console.Write("Enter product ID: ");
                int productId = int.Parse(Console.ReadLine());
                var product = _service.GetProductById(productId);

                if (product != null)
                {
                    Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price}");
                }
                else
                {
                    Console.WriteLine("Product not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewAllProducts()
        {
            try
            {
                var products = _service.GetAllProducts();
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Quantity: {product.Quantity}, Price: {product.Price}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
