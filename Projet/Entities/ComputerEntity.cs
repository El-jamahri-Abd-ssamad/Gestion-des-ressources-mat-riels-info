using System;

namespace Projet.Entities
{
    public class ComputerEntity
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Brand { get; set; }
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string Screen { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }
        public string AssignedTo { get; set; }
        public string AssignmentType { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ComputerEntity()
        {
            Id = 0;
            InventoryNumber = "";
            Brand = "";
            CPU = "";
            RAM = "";
            HardDrive = "";
            Screen = "";
            AssignedTo = "";
            AssignmentType = "Department";
            SupplierId = 0;
            DepartmentId = 0;
            DeliveryDate = DateTime.Now;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public ComputerEntity(int id, string inventoryNumber, string brand, string cpu,
                             string ram, string hardDrive, string screen, DateTime deliveryDate,
                             int supplierId, string assignedTo, string assignmentType, int departmentId)
        {
            Id = id;
            InventoryNumber = inventoryNumber;
            Brand = brand;
            CPU = cpu;
            RAM = ram;
            HardDrive = hardDrive;
            Screen = screen;
            DeliveryDate = deliveryDate;
            SupplierId = supplierId;
            AssignedTo = assignedTo;
            AssignmentType = assignmentType;
            DepartmentId = departmentId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Id {Id} InventoryNumber {InventoryNumber} Brand {Brand} CPU {CPU} RAM {RAM}";
        }
    }
}