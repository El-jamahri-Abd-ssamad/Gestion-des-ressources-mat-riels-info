using System;
using System.ComponentModel.DataAnnotations;

namespace Projet.Models
{
    public class AssignmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "L'ID de la ressource est obligatoire")]
        public int ResourceId { get; set; }

        [Required(ErrorMessage = "Le type de ressource est obligatoire")]
        public string ResourceType { get; set; }

        [Required(ErrorMessage = "L'affectataire est obligatoire")]
        public string AssignedTo { get; set; }

        [Required(ErrorMessage = "Le type d'affectation est obligatoire")]
        public string AssignmentType { get; set; }

        public int DepartmentId { get; set; }

        public DateTime AssignedDate { get; set; }

        public DateTime RevokedDate { get; set; }

        public bool IsActive { get; set; }

        public AssignmentDto()
        {
            ResourceType = "?????";
            AssignedTo = "?????";
            AssignmentType = "Department";
            AssignedDate = DateTime.Now;
            RevokedDate = DateTime.Now;
            IsActive = true;
            ResourceId = 0;
            DepartmentId = 0;
        }

        public AssignmentDto(int id, int resourceId, string resourceType, string assignedTo,
                            string assignmentType, int departmentId, DateTime assignedDate,
                            DateTime revokedDate, bool isActive)
        {
            Id = id;
            ResourceId = resourceId;
            ResourceType = resourceType;
            AssignedTo = assignedTo;
            AssignmentType = assignmentType;
            DepartmentId = departmentId;
            AssignedDate = assignedDate;
            RevokedDate = revokedDate;
            IsActive = isActive;
        }

        public override string ToString()
        {
            return $@"Id: {Id} ResourceId: {ResourceId} ResourceType: {ResourceType}
                    AssignedTo: {AssignedTo} AssignmentType: {AssignmentType}
                    DepartmentId: {DepartmentId} IsActive: {IsActive}";
        }
    }
}