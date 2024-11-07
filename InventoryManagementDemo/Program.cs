using InventoryManagementDemo.Controllers;
using InventoryManagementDemo.Data;
using InventoryManagementDemo.Repo;

namespace InventoryManagementDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inventoryService = new InventoryService(new Context());
            var productController = new ProductController(inventoryService);
            var supplierController = new SupplierController(inventoryService);
            var transactionController = new TransactionController(inventoryService);
            var reportService = new ReportService(inventoryService);
            Console.WriteLine("Welcome to the Inventory Management System");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Supplier Management");
                Console.WriteLine("3. Transaction Management");
                Console.WriteLine("4. Generate Report");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                Console.WriteLine();
                switch (Console.ReadLine())
                {
                    case "1":
                        ProductMenu(productController);
                        break;
                    case "2":
                        SupplierMenu(supplierController);
                        break;
                    case "3":
                        TransactionMenu(transactionController);
                        break;
                    case "4":
                        reportService.GenerateReport();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ProductMenu(ProductController controller)
        {
            Console.WriteLine("Product Management:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. View Product Details");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Go Back");
            Console.Write("Enter your choice: ");
            Console.WriteLine();
            switch (Console.ReadLine())
            {
                case "1":
                    controller.AddProduct();
                    break;
                case "2":
                    controller.UpdateProduct();
                    break;
                case "3":
                    controller.DeleteProduct();
                    break;
                case "4":
                    controller.ViewProductDetails();
                    break;
                case "5":
                    controller.ViewAllProducts();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        static void SupplierMenu(SupplierController controller)
        {
            Console.WriteLine("Supplier Management:");
            Console.WriteLine("1. Add Supplier");
            Console.WriteLine("2. Update Supplier");
            Console.WriteLine("3. Delete Supplier");
            Console.WriteLine("4. View Supplier Details");
            Console.WriteLine("5. View All Suppliers");
            Console.WriteLine("6. Go Back");
            Console.Write("Enter your choice: ");
            Console.WriteLine();
            switch (Console.ReadLine())
            {
                case "1":
                    controller.AddSupplier();
                    break;
                case "2":
                    controller.UpdateSupplier();
                    break;
                case "3":
                    controller.DeleteSupplier();
                    break;
                case "4":
                    controller.ViewSupplierDetails();
                    break;
                case "5":
                    controller.ViewAllSuppliers();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        static void TransactionMenu(TransactionController controller)
        {
            Console.WriteLine("Transaction Management:");
            Console.WriteLine("1. Add Stock");
            Console.WriteLine("2. Remove Stock");
            Console.WriteLine("3. View Transaction History");
            Console.WriteLine("4. Go Back");
            Console.Write("Enter your choice: ");
            Console.WriteLine();
            switch (Console.ReadLine())
            {
                case "1":
                    controller.AddStock();
                    break;
                case "2":
                    controller.RemoveStock();
                    break;
                case "3":
                    controller.ViewTransactionHistory();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
