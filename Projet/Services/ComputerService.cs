using Projet.Data;
using Projet.Domain;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerDao computerDao;

        public ComputerService()
        {
            computerDao = new ComputerDaoDB();
        }

        public bool AddComputer(ComputerDto dto)
        {
            try
            {
                Computer computer = new Computer
                {
                    InventoryNumber = dto.InventoryNumber,
                    Brand = dto.Brand,
                    CPU = dto.CPU,
                    RAM = dto.RAM,
                    HardDrive = dto.HardDrive,
                    Screen = dto.Screen,
                    DeliveryDate = dto.DeliveryDate,
                    SupplierId = dto.SupplierId,
                    AssignedTo = dto.AssignedTo,
                    AssignmentType = dto.AssignmentType,
                    DepartmentId = dto.DepartmentId,
                    CreatedAt = DateTime.Now
                };

                int id = computerDao.Insert(computer);
                return id > 0;
            }
            catch
            {
                return false;
            }
        }

        public ComputerDto GetComputerByInventoryNumber(string inventoryNumber)
        {
            try
            {
                Computer computer = computerDao.GetByInventoryNumber(inventoryNumber);
                if (computer == null) return null;

                return new ComputerDto
                {
                    Id = computer.Id,
                    InventoryNumber = computer.InventoryNumber,
                    Brand = computer.Brand,
                    CPU = computer.CPU,
                    RAM = computer.RAM,
                    HardDrive = computer.HardDrive,
                    Screen = computer.Screen,
                    DeliveryDate = computer.DeliveryDate,
                    SupplierId = computer.SupplierId,
                    AssignedTo = computer.AssignedTo,
                    AssignmentType = computer.AssignmentType,
                    DepartmentId = computer.DepartmentId
                };
            }
            catch
            {
                return null;
            }
        }

        public List<ComputerDto> GetAllComputers()
        {
            try
            {
                List<Computer> computers = computerDao.GetAll();
                return computers.Select(c => new ComputerDto
                {
                    Id = c.Id,
                    InventoryNumber = c.InventoryNumber,
                    Brand = c.Brand,
                    CPU = c.CPU,
                    RAM = c.RAM,
                    HardDrive = c.HardDrive,
                    Screen = c.Screen,
                    DeliveryDate = c.DeliveryDate,
                    SupplierId = c.SupplierId,
                    AssignedTo = c.AssignedTo,
                    AssignmentType = c.AssignmentType,
                    DepartmentId = c.DepartmentId
                }).ToList();
            }
            catch
            {
                return new List<ComputerDto>();
            }
        }

        public List<ComputerDto> GetComputersByDepartment(int departmentId)
        {
            try
            {
                List<Computer> computers = computerDao.GetByDepartment(departmentId);
                return computers.Select(c => new ComputerDto
                {
                    Id = c.Id,
                    InventoryNumber = c.InventoryNumber,
                    Brand = c.Brand,
                    CPU = c.CPU,
                    RAM = c.RAM,
                    HardDrive = c.HardDrive,
                    Screen = c.Screen,
                    DeliveryDate = c.DeliveryDate,
                    SupplierId = c.SupplierId,
                    AssignedTo = c.AssignedTo,
                    AssignmentType = c.AssignmentType,
                    DepartmentId = c.DepartmentId
                }).ToList();
            }
            catch
            {
                return new List<ComputerDto>();
            }
        }

        public bool UpdateComputer(ComputerDto dto)
        {
            try
            {
                Computer computer = new Computer
                {
                    Id = dto.Id,
                    InventoryNumber = dto.InventoryNumber,
                    Brand = dto.Brand,
                    CPU = dto.CPU,
                    RAM = dto.RAM,
                    HardDrive = dto.HardDrive,
                    Screen = dto.Screen,
                    DeliveryDate = dto.DeliveryDate,
                    SupplierId = dto.SupplierId,
                    AssignedTo = dto.AssignedTo,
                    AssignmentType = dto.AssignmentType,
                    DepartmentId = dto.DepartmentId,
                    UpdatedAt = DateTime.Now
                };

                computerDao.Update(computer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteComputer(string inventoryNumber)
        {
            try
            {
                computerDao.Delete(inventoryNumber);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}