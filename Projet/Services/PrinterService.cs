using Projet.Data;
using Projet.Domain;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet.Services
{
    public class PrinterService : IPrinterService
    {
        private readonly IPrinterDao printerDao;

        public PrinterService()
        {
            printerDao = new PrinterDaoDB();
        }

        public bool AddPrinter(PrinterDto dto)
        {
            try
            {
                Printer printer = new Printer
                {
                    InventoryNumber = dto.InventoryNumber,
                    Brand = dto.Brand,
                    PrintSpeed = dto.PrintSpeed,
                    Resolution = dto.Resolution,
                    DeliveryDate = dto.DeliveryDate,
                    SupplierId = dto.SupplierId,
                    AssignedTo = dto.AssignedTo,
                    AssignmentType = dto.AssignmentType,
                    DepartmentId = dto.DepartmentId,
                    CreatedAt = DateTime.Now
                };

                int id = printerDao.Insert(printer);
                return id > 0;
            }
            catch
            {
                return false;
            }
        }

        public PrinterDto GetPrinterByInventoryNumber(string inventoryNumber)
        {
            try
            {
                Printer printer = printerDao.GetByInventoryNumber(inventoryNumber);
                if (printer == null) return null;

                return new PrinterDto
                {
                    Id = printer.Id,
                    InventoryNumber = printer.InventoryNumber,
                    Brand = printer.Brand,
                    PrintSpeed = printer.PrintSpeed,
                    Resolution = printer.Resolution,
                    DeliveryDate = printer.DeliveryDate,
                    SupplierId = printer.SupplierId,
                    AssignedTo = printer.AssignedTo,
                    AssignmentType = printer.AssignmentType,
                    DepartmentId = printer.DepartmentId
                };
            }
            catch
            {
                return null;
            }
        }

        public List<PrinterDto> GetAllPrinters()
        {
            try
            {
                List<Printer> printers = printerDao.GetAll();
                return printers.Select(p => new PrinterDto
                {
                    Id = p.Id,
                    InventoryNumber = p.InventoryNumber,
                    Brand = p.Brand,
                    PrintSpeed = p.PrintSpeed,
                    Resolution = p.Resolution,
                    DeliveryDate = p.DeliveryDate,
                    SupplierId = p.SupplierId,
                    AssignedTo = p.AssignedTo,
                    AssignmentType = p.AssignmentType,
                    DepartmentId = p.DepartmentId
                }).ToList();
            }
            catch
            {
                return new List<PrinterDto>();
            }
        }

        public List<PrinterDto> GetPrintersByDepartment(int departmentId)
        {
            try
            {
                List<Printer> printers = printerDao.GetByDepartment(departmentId);
                return printers.Select(p => new PrinterDto
                {
                    Id = p.Id,
                    InventoryNumber = p.InventoryNumber,
                    Brand = p.Brand,
                    PrintSpeed = p.PrintSpeed,
                    Resolution = p.Resolution,
                    DeliveryDate = p.DeliveryDate,
                    SupplierId = p.SupplierId,
                    AssignedTo = p.AssignedTo,
                    AssignmentType = p.AssignmentType,
                    DepartmentId = p.DepartmentId
                }).ToList();
            }
            catch
            {
                return new List<PrinterDto>();
            }
        }

        public bool UpdatePrinter(PrinterDto dto)
        {
            try
            {
                Printer printer = new Printer
                {
                    Id = dto.Id,
                    InventoryNumber = dto.InventoryNumber,
                    Brand = dto.Brand,
                    PrintSpeed = dto.PrintSpeed,
                    Resolution = dto.Resolution,
                    DeliveryDate = dto.DeliveryDate,
                    SupplierId = dto.SupplierId,
                    AssignedTo = dto.AssignedTo,
                    AssignmentType = dto.AssignmentType,
                    DepartmentId = dto.DepartmentId,
                    UpdatedAt = DateTime.Now
                };

                printerDao.Update(printer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePrinter(string inventoryNumber)
        {
            try
            {
                printerDao.Delete(inventoryNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}