using System;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class PrinterDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro d'inventaire est obligatoire")]
        public string InventoryNumber { get; set; }

        [Required(ErrorMessage = "La marque est obligatoire")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "La vitesse d'impression est obligatoire")]
        [Range(1, 1000, ErrorMessage = "La vitesse doit être entre 1 et 1000")]
        public int PrintSpeed { get; set; }

        [Required(ErrorMessage = "La résolution est obligatoire")]
        public string Resolution { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int SupplierId { get; set; }

        [Required(ErrorMessage = "L'affectation est obligatoire")]
        public string AssignedTo { get; set; }

        [Required(ErrorMessage = "Le type d'affectation est obligatoire")]
        public string AssignmentType { get; set; }

        public int DepartmentId { get; set; }

        public PrinterDto()
        {
            InventoryNumber = "?????";
            Brand = "?????";
            Resolution = "?????";
            AssignedTo = "?????";
            AssignmentType = "Department";
            PrintSpeed = 0;
            DeliveryDate = DateTime.Now;
            SupplierId = 0;
            DepartmentId = 0;
        }

        public PrinterDto(int id, string inventoryNumber, string brand, int printSpeed,
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
        }

        public override string ToString()
        {
            return $@"Id: {Id} InventoryNumber: {InventoryNumber} Brand: {Brand}
                    PrintSpeed: {PrintSpeed} ppm Resolution: {Resolution}
                    DeliveryDate: {DeliveryDate} AssignedTo: {AssignedTo} Type: {AssignmentType}";
        }
    }
}