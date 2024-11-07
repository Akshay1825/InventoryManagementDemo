using InventoryManagementDemo.Repo;
using InventoryManagementDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementDemo.Controllers
{
    internal class SupplierController
    {
        InventoryService _service;
        public SupplierController(InventoryService service)
        {
            _service = service;
        }

        public void AddSupplier()
        {
            try
            {
                Console.Write("Enter supplier name: ");
                string name = Console.ReadLine();

                Console.Write("Enter contact information: ");
                string contactInfo = Console.ReadLine();

                var supplier = new Supplier
                {
                    Name = name,
                    ContactInfo = contactInfo,
                    InventoryId = 1
                };
                _service.AddSupplier(supplier);
                Console.WriteLine("Supplier added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void UpdateSupplier()
        {
            try
            {
                Console.Write("Enter supplier ID to update: ");
                int supplierId = int.Parse(Console.ReadLine());

                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();

                Console.Write("Enter new contact information: ");
                string newContactInfo = Console.ReadLine();

                _service.UpdateSupplier(supplierId, newName, newContactInfo);
                Console.WriteLine("Supplier updated successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void DeleteSupplier()
        {
            try
            {
                Console.Write("Enter supplier ID to delete: ");
                int supplierId = int.Parse(Console.ReadLine());
                _service.DeleteSupplier(supplierId);
                Console.WriteLine("Supplier deleted successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewSupplierDetails()
        {
            try
            {
                Console.Write("Enter supplier ID: ");
                int supplierId = int.Parse(Console.ReadLine());
                var supplier = _service.GetSupplierById(supplierId);

                if (supplier != null)
                {
                    Console.WriteLine($"Supplier ID: {supplier.SupplierId}, Name: {supplier.Name}, Contact: {supplier.ContactInfo}");
                }
                else
                {
                    Console.WriteLine("Supplier not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ViewAllSuppliers()
        {
            try
            {
                var suppliers = _service.GetAllSuppliers();
                foreach (var supplier in suppliers)
                {
                    Console.WriteLine($"ID: {supplier.SupplierId}, Name: {supplier.Name}, Contact: {supplier.ContactInfo}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
