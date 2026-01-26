using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ComputerDto : ResourceDto
    {
        [Required(ErrorMessage = "Le CPU est obligatoire")]
        [StringLength(100, ErrorMessage = "Le CPU ne peut pas dépasser 100 caractères")]
        public string CPU { get; set; }

        [Required(ErrorMessage = "La RAM est obligatoire")]
        [StringLength(50, ErrorMessage = "La RAM ne peut pas dépasser 50 caractères")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "Le disque dur est obligatoire")]
        [StringLength(50, ErrorMessage = "Le disque dur ne peut pas dépasser 50 caractères")]
        public string HardDrive { get; set; }

        [Required(ErrorMessage = "L'écran est obligatoire")]
        [StringLength(50, ErrorMessage = "L'écran ne peut pas dépasser 50 caractères")]
        public string Screen { get; set; }

        public ComputerDto()
        {
            CPU = string.Empty;
            RAM = string.Empty;
            HardDrive = string.Empty;
            Screen = string.Empty;
        }

        public ComputerDto(string inventoryNumber, string brand, string cpu, string ram,
                          string hardDrive, string screen, DateTime? deliveryDate,
                          int? supplierId, string assignedTo, string assignmentType, int? departmentId)
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
        }

        public override string GetResourceType() => "Computer";

        public override string ToString()
        {
            return $"Computer #{InventoryNumber} - {Brand} (CPU: {CPU}, RAM: {RAM}, HDD: {HardDrive}, Screen: {Screen})";
        }
    }
}
