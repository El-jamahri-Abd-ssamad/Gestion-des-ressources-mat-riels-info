using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PrinterDto : ResourceDto
    {
        [Required(ErrorMessage = "La vitesse d'impression est obligatoire")]
        [Range(1, 1000, ErrorMessage = "La vitesse doit être entre 1 et 1000 pages/min")]
        public int PrintSpeed { get; set; }

        [Required(ErrorMessage = "La résolution est obligatoire")]
        [StringLength(50, ErrorMessage = "La résolution ne peut pas dépasser 50 caractères")]
        public string Resolution { get; set; }

        public PrinterDto()
        {
            PrintSpeed = 0;
            Resolution = string.Empty;
        }

        public PrinterDto(string inventoryNumber, string brand, int printSpeed, string resolution,
                         DateTime? deliveryDate, int? supplierId, string assignedTo,
                         string assignmentType, int? departmentId)
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
        }

        public override string GetResourceType() => "Printer";

        public override string ToString()
        {
            return $"Printer #{InventoryNumber} - {Brand} (Speed: {PrintSpeed} ppm, Resolution: {Resolution})";
        }
    }
}