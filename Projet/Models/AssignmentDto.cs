using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AssignmentDto
    {
        public int ResourceId { get; set; }

        [Required(ErrorMessage = "Le type de ressource est obligatoire")]
        public string ResourceType { get; set; }

        [Required(ErrorMessage = "L'affectataire est obligatoire")]
        public string AssignedTo { get; set; }

        [Required(ErrorMessage = "Le type d'affectation est obligatoire")]
        public string AssignmentType { get; set; }

        public int? DepartmentId { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssignedDate { get; set; }

        public bool IsActive { get; set; }

        public AssignmentDto()
        {
            ResourceType = string.Empty;
            AssignedTo = string.Empty;
            AssignmentType = "Department";
            AssignedDate = DateTime.Now;
            IsActive = true;
        }

        public AssignmentDto(int resourceId, string resourceType, string assignedTo,
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
            return $"{ResourceType} #{ResourceId} -> {AssignedTo} ({AssignmentType}) - Active: {IsActive}";
        }
    }
}