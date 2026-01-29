using Projet.Data;
using Projet.Domain;
using Projet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projet.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentDao assignmentDao;

        public AssignmentService()
        {
            assignmentDao = new AssignmentDaoDB();
        }

        public bool CreateAssignment(AssignmentDto dto)
        {
            try
            {
                Assignment assignment = new Assignment
                {
                    ResourceId = dto.ResourceId,
                    ResourceType = dto.ResourceType,
                    AssignedTo = dto.AssignedTo,
                    AssignmentType = dto.AssignmentType,
                    DepartmentId = dto.DepartmentId,
                    AssignedDate = DateTime.Now,
                    IsActive = true
                };

                int id = assignmentDao.Insert(assignment);
                return id > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<AssignmentDto> GetAssignmentsByResource(int resourceId, string resourceType)
        {
            try
            {
                List<Assignment> assignments = assignmentDao.GetByResource(resourceId, resourceType);
                return assignments.Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    ResourceId = a.ResourceId,
                    ResourceType = a.ResourceType,
                    AssignedTo = a.AssignedTo,
                    AssignmentType = a.AssignmentType,
                    DepartmentId = a.DepartmentId,
                    AssignedDate = a.AssignedDate,
                    RevokedDate = a.RevokedDate,
                    IsActive = a.IsActive
                }).ToList();
            }
            catch
            {
                return new List<AssignmentDto>();
            }
        }

        public List<AssignmentDto> GetActiveAssignments()
        {
            try
            {
                List<Assignment> assignments = assignmentDao.GetActiveAssignments();
                return assignments.Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    ResourceId = a.ResourceId,
                    ResourceType = a.ResourceType,
                    AssignedTo = a.AssignedTo,
                    AssignmentType = a.AssignmentType,
                    DepartmentId = a.DepartmentId,
                    AssignedDate = a.AssignedDate,
                    RevokedDate = a.RevokedDate,
                    IsActive = a.IsActive
                }).ToList();
            }
            catch
            {
                return new List<AssignmentDto>();
            }
        }

        public List<AssignmentDto> GetAssignmentsByDepartment(int departmentId)
        {
            try
            {
                List<Assignment> assignments = assignmentDao.GetByDepartment(departmentId);
                return assignments.Select(a => new AssignmentDto
                {
                    Id = a.Id,
                    ResourceId = a.ResourceId,
                    ResourceType = a.ResourceType,
                    AssignedTo = a.AssignedTo,
                    AssignmentType = a.AssignmentType,
                    DepartmentId = a.DepartmentId,
                    AssignedDate = a.AssignedDate,
                    RevokedDate = a.RevokedDate,
                    IsActive = a.IsActive
                }).ToList();
            }
            catch
            {
                return new List<AssignmentDto>();
            }
        }

        public bool RevokeAssignment(int assignmentId)
        {
            try
            {
                assignmentDao.Revoke(assignmentId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}