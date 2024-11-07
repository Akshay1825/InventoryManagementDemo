using InventoryManagementDemo.Data;
using InventoryManagementDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Repo
{
    internal class InventoryService
    {
        Context _context;

        public InventoryService(Context context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            if (_context.Products.Any(p => p.Name == product.Name))
                throw new Exception("Product with the same name already exists");
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(int productId, string newName, string newDescription, int newPrice)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
                throw new Exception("Product not found");
            product.Name = newName;
            product.Description = newDescription;
            product.Price = newPrice;
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
                throw new Exception("Product not found");
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.SingleOrDefault(p => p.ProductId == productId);
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public void AddSupplier(Supplier supplier)
        {
            if (_context.Suppliers.Any(s => s.Name == supplier.Name))
                throw new Exception("Supplier with the same name already exists");
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(int supplierId, string newName, string newContactInfo)
        {
            var supplier = _context.Suppliers.SingleOrDefault(s => s.SupplierId == supplierId);
            if (supplier == null)
                throw new Exception("Supplier not found");
            supplier.Name = newName;
            supplier.ContactInfo = newContactInfo;
            _context.SaveChanges();
        }

        public void DeleteSupplier(int supplierId)
        {
            var supplier = _context.Suppliers.SingleOrDefault(s => s.SupplierId == supplierId);
            if (supplier == null)
                throw new Exception("Supplier not found");
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return _context.Suppliers.SingleOrDefault(s => s.SupplierId == supplierId);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public void AddStock(int productId, int quantity)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
                throw new Exception("Product not found");
            product.Quantity += quantity;
            var transaction = new Transaction
            {
                ProductId = productId,
                Type = "Add Stock",
                Quantity = quantity,
                Date = DateTime.Now,
                InventoryId = product.InventoryId
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void RemoveStock(int productId, int quantity)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == productId);
            if (product == null)
                throw new Exception("Product not found");
            if (product.Quantity < quantity)
                throw new Exception("Insufficient stock to remove");
            product.Quantity -= quantity;
            var transaction = new Transaction
            {
                ProductId = productId,
                Type = "Remove Stock",
                Quantity = quantity,
                Date = DateTime.Now,
                InventoryId = product.InventoryId
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public List<Transaction> GetAllTransactions()
        {
            return _context.Transactions.ToList();
        }

        public List<Transaction> GetTransactionsByProductId(int productId)
        {
            return _context.Transactions.Where(t => t.ProductId == productId).ToList();
        }
    }
}
