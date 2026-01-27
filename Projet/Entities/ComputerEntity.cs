
namespace WebApplication1.Entities
{
    public class ComputerEntity : ResourceEntity
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string Screen { get; set; }

        public ComputerEntity()
        {
            CPU = string.Empty;
            RAM = string.Empty;
            HardDrive = string.Empty;
            Screen = string.Empty;
        }

        public ComputerEntity(int id, string inventoryNumber, string brand, string cpu,
                              string ram, string hardDrive, string screen, DateTime? deliveryDate,
                              int? supplierId, string assignedTo, string assignmentType, int? departmentId)
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
        }

        public override string GetResourceType() => "Computer";

        public override string ToString()
        {
            return $"Computer #{InventoryNumber} - {Brand} (CPU: {CPU}, RAM: {RAM}, HDD: {HardDrive}, Screen: {Screen}) - Assigned to: {AssignedTo}";
        }
    }
}