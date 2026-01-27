namespace WebApplication1.Domain
{
    public class Printer : Resource
    {
        public int PrintSpeed { get; set; }
        public string Resolution { get; set; }

        public Printer()
        {
            PrintSpeed = 0;
            Resolution = string.Empty;
        }

        public Printer(string inventoryNumber, string brand, int printSpeed, string resolution,
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
            return $"Printer #{InventoryNumber} - {Brand} (Speed: {PrintSpeed} ppm)";
        }
    }
}