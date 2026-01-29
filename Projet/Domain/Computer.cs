using System;

namespace Projet.Domain
{
    public class Computer
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

        public Computer()
        {
            InventoryNumber = "";
            Brand = "";
            CPU = "";
            RAM = "";
            HardDrive = "";
            Screen = "";
            AssignedTo = "";
            AssignmentType = "Department";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Computer(string inventoryNumber, string brand, string cpu, string ram,
                       string hardDrive, string screen, DateTime deliveryDate,
                       int supplierId, string assignedTo, string assignmentType, int departmentId)
        {
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
            return $"Computer {InventoryNumber} - {Brand} (CPU: {CPU}, RAM: {RAM})";
        }
    }
}