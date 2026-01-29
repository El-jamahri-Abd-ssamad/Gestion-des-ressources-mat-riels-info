using Projet.Domain;

namespace Projet.Data
{
    public interface IAssignmentDao
    {
        int Insert(Assignment assignment);
        List<Assignment> GetByResource(int resourceId, string resourceType);
        List<Assignment> GetActiveAssignments();
        List<Assignment> GetByDepartment(int departmentId);
        void Revoke(int assignmentId);
    }
}
