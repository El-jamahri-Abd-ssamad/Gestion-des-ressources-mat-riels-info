
namespace WebApplication1.Entities
{
    public class AssignmentEntity
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public string ResourceType { get; set; } // "Computer" ou "Printer"
    public string AssignedTo { get; set; }
    public string AssignmentType { get; set; } // "Teacher" ou "Department"
    public int? DepartmentId { get; set; }
    public DateTime AssignedDate { get; set; }
    public DateTime? RevokedDate { get; set; }
    public bool IsActive { get; set; }

    public AssignmentEntity()
    {
        ResourceType = string.Empty;
        AssignedTo = string.Empty;
        AssignmentType = "Department";
        AssignedDate = DateTime.Now;
        IsActive = true;
    }

    public AssignmentEntity(int id, int resourceId, string resourceType, string assignedTo,
                           string assignmentType, int? departmentId, DateTime assignedDate)
    {
        Id = id;
        ResourceId = resourceId;
        ResourceType = resourceType;
        AssignedTo = assignedTo;
        AssignmentType = assignmentType;
        DepartmentId = departmentId;
        AssignedDate = assignedDate;
        IsActive = true;
    }

    public override string ToString()
    {
        return $"Assignment #{Id} - Resource: {ResourceType} #{ResourceId} -> {AssignedTo} ({AssignmentType}) - Active: {IsActive}";
    }
}
}
