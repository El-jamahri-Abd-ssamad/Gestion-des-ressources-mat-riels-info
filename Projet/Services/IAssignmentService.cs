using Projet.Models;
using System.Collections.Generic;

namespace Projet.Services
{
    public interface IAssignmentService
    {
        bool CreateAssignment(AssignmentDto assignment);
        List<AssignmentDto> GetAssignmentsByResource(int resourceId, string resourceType);
        List<AssignmentDto> GetActiveAssignments();
        List<AssignmentDto> GetAssignmentsByDepartment(int departmentId);
        bool RevokeAssignment(int assignmentId);
    }
}