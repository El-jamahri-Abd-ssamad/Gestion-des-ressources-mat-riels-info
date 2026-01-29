using System;

namespace Projet.Entities
{
    public class PrinterEntity
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

        public PrinterEntity()
        {
            Id = 0;
            InventoryNumber = "";
            Brand = "";
            Resolution = "";
            AssignedTo = "";
            AssignmentType = "Department";
            PrintSpeed = 0;
            SupplierId = 0;
            DepartmentId = 0;
            DeliveryDate = DateTime.Now;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public PrinterEntity(int id, string inventoryNumber, string brand, int printSpeed,
                            string resolution, DateTime deliveryDate, int supplierId,
                            string assignedTo, string assignmentType, int departmentId)
        {
            Id = id;
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
            return $"Id {Id} InventoryNumber {InventoryNumber} Brand {Brand} PrintSpeed {PrintSpeed} ppm";
        }
    }
}