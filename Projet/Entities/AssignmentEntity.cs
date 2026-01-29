using System;

namespace Projet.Entities
{
    public class AssignmentEntity
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string ResourceType { get; set; }
        public string AssignedTo { get; set; }
        public string AssignmentType { get; set; }
        public int DepartmentId { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime RevokedDate { get; set; }
        public bool IsActive { get; set; }

        public AssignmentEntity()
        {
            Id = 0;
            ResourceId = 0;
            ResourceType = "";
            AssignedTo = "";
            AssignmentType = "Department";
            DepartmentId = 0;
            AssignedDate = DateTime.Now;
            RevokedDate = DateTime.Now;
            IsActive = true;
        }

        public AssignmentEntity(int id, int resourceId, string resourceType, string assignedTo,
                               string assignmentType, int departmentId, DateTime assignedDate)
        {
            Id = id;
            ResourceId = resourceId;
            ResourceType = resourceType;
            AssignedTo = assignedTo;
            AssignmentType = assignmentType;
            DepartmentId = departmentId;
            AssignedDate = assignedDate;
            RevokedDate = DateTime.Now;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"Id {Id} ResourceId {ResourceId} ResourceType {ResourceType} AssignedTo {AssignedTo}";
        }
    }
}