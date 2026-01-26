
namespace WebApplication1.Domain
{
    public class Assignment
{
    public int ResourceId { get; set; }
    public string ResourceType { get; set; }
    public string AssignedTo { get; set; }
    public string AssignmentType { get; set; }
    public int? DepartmentId { get; set; }
    public DateTime AssignedDate { get; set; }
    public bool IsActive { get; set; }

    public Assignment()
    {
        ResourceType = string.Empty;
        AssignedTo = string.Empty;
        AssignmentType = "Department";
        AssignedDate = DateTime.Now;
        IsActive = true;
    }

    public Assignment(int resourceId, string resourceType, string assignedTo,
                     string assignmentType, int? departmentId)
    {
        ResourceId = resourceId;
        ResourceType = resourceType;
        AssignedTo = assignedTo;
        AssignmentType = assignmentType;
        DepartmentId = departmentId;
        AssignedDate = DateTime.Now;
        IsActive = true;
    }

    public override string ToString()
    {
        return $"{ResourceType} #{ResourceId} -> {AssignedTo} ({AssignmentType})";
    }
}
}