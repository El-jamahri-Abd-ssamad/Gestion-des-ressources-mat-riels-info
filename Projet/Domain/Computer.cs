public class Computer : Resource
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string HardDrive { get; set; }
    public string Screen { get; set; }

    public Computer()
    {
        CPU = string.Empty;
        RAM = string.Empty;
        HardDrive = string.Empty;
        Screen = string.Empty;
    }

    public Computer(string inventoryNumber, string brand, string cpu, string ram,
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
        return $"Computer #{InventoryNumber} - {Brand} (CPU: {CPU}, RAM: {RAM})";
    }
}