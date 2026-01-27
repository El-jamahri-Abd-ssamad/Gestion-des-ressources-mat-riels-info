
using Projet.Domain;

namespace Projet.Data
{
    public interface IAssignmentDao
    {
        void AddAssignment(Assignment assignment);
        List<Assignment> GetAssignmentsByResource(int resourceId, string resourceType);
        List<Assignment> GetActiveAssignments();
        List<Assignment> GetAssignmentsByDepartment(int departmentId);
        void RevokeAssignment(int assignmentId);
    }
}
