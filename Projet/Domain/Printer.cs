using System;

namespace Projet.Domain
{
    public class Printer
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public string Brand { get; set; }
        public int PrintSpeed { get; set; }
        public string Resolution { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int SupplierId { get; set; }
        public string AssignedTo { get; set; }
        public string AssignmentType { get; set; }
        public int DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Printer()
        {
            InventoryNumber = "";
            Brand = "";
            Resolution = "";
            AssignedTo = "";
            AssignmentType = "Department";
            PrintSpeed = 0;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Printer(string inventoryNumber, string brand, int printSpeed, string resolution,
                      DateTime deliveryDate, int supplierId, string assignedTo,
                      string assignmentType, int departmentId)
        {
            InventoryNumber = inventoryNumber;
            Brand = brand;
            PrintSpeed = printSpeed;
            Resolution = resolution;
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
            return $"Printer {InventoryNumber} - {Brand} ({PrintSpeed} ppm, {Resolution})";
        }
    }
}