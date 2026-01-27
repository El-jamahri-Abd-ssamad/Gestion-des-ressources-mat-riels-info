public class ResourceEntity
{
    public int Id { get; set; }
    public string InventoryNumber { get; set; }
    public string Brand { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public int? SupplierId { get; set; }
    public string AssignedTo { get; set; }
    public string AssignmentType { get; set; } // "Teacher" ou "Department"
    public int? DepartmentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public ResourceEntity()
    {
        InventoryNumber = Brand = AssignedTo = "";
        AssignmentType = "Department";
        CreatedAt = DateTime.Now;
        Id = 0;
    }
}