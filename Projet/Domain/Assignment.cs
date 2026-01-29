using System;

namespace Projet.Domain
{
    public class Assignment
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

        public Assignment()
        {
            ResourceType = "";
            AssignedTo = "";
            AssignmentType = "Department";
            AssignedDate = DateTime.Now;
            RevokedDate = DateTime.Now;
            IsActive = true;
        }

        public Assignment(int resourceId, string resourceType, string assignedTo,
                         string assignmentType, int departmentId)
        {
            ResourceId = resourceId;
            ResourceType = resourceType;
            AssignedTo = assignedTo;
            AssignmentType = assignmentType;
            DepartmentId = departmentId;
            AssignedDate = DateTime.Now;
            RevokedDate = DateTime.Now;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"{ResourceType} #{ResourceId} -> {AssignedTo} ({AssignmentType})";
        }
    }
}