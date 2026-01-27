public class PrinterEntity : ResourceEntity
{
    public int PrintSpeed { get; set; } // Vitesse d'impression (pages/min)
    public string Resolution { get; set; } // Résolution (ex: 1200x1200 dpi)

    public PrinterEntity()
    {
        PrintSpeed = 0;
        Resolution = string.Empty;
    }

    public PrinterEntity(int id, string inventoryNumber, string brand, int printSpeed,
                        string resolution, DateTime? deliveryDate, int? supplierId,
                        string assignedTo, string assignmentType, int? departmentId)
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
    }

    public override string GetResourceType() => "Printer";

    public override string ToString()
    {
        return $"Printer #{InventoryNumber} - {Brand} (Speed: {PrintSpeed} ppm, Resolution: {Resolution}) - Assigned to: {AssignedTo}";
    }
}