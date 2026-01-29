using Microsoft.Data.SqlClient;
using Projet.Domain;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class AssignmentDaoDB : IAssignmentDao
    {
        // =========================
        // INSERT
        // =========================
        public int Insert(Assignment a)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Assignments 
                  (ResourceId, ResourceType, AssignedTo, AssignmentType, DepartmentId, AssignedDate, IsActive)
                  OUTPUT INSERTED.Id
                  VALUES (@resId,@resType,@assigned,@type,@dept,@date,@active)", cn))
            {
                cmd.Parameters.AddWithValue("@resId", a.ResourceId);
                cmd.Parameters.AddWithValue("@resType", a.ResourceType);
                cmd.Parameters.AddWithValue("@assigned", a.AssignedTo);
                cmd.Parameters.AddWithValue("@type", a.AssignmentType);
                cmd.Parameters.AddWithValue("@dept", a.DepartmentId);
                cmd.Parameters.AddWithValue("@date", a.AssignedDate);
                cmd.Parameters.AddWithValue("@active", a.IsActive);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // =========================
        // GET BY RESOURCE
        // =========================
        public List<Assignment> GetByResource(int resourceId, string resourceType)
        {
            var list = new List<Assignment>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, ResourceId, ResourceType, AssignedTo, AssignmentType, 
                         DepartmentId, AssignedDate, RevokedDate, IsActive
                  FROM Assignments
                  WHERE ResourceId=@resId AND ResourceType=@resType", cn))
            {
                cmd.Parameters.AddWithValue("@resId", resourceId);
                cmd.Parameters.AddWithValue("@resType", resourceType);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapAssignment(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // GET ACTIVE ASSIGNMENTS
        // =========================
        public List<Assignment> GetActiveAssignments()
        {
            var list = new List<Assignment>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, ResourceId, ResourceType, AssignedTo, AssignmentType, 
                         DepartmentId, AssignedDate, RevokedDate, IsActive
                  FROM Assignments
                  WHERE IsActive=1", cn))
            {
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapAssignment(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // GET BY DEPARTMENT
        // =========================
        public List<Assignment> GetByDepartment(int departmentId)
        {
            var list = new List<Assignment>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, ResourceId, ResourceType, AssignedTo, AssignmentType, 
                         DepartmentId, AssignedDate, RevokedDate, IsActive
                  FROM Assignments
                  WHERE DepartmentId=@dept AND IsActive=1", cn))
            {
                cmd.Parameters.AddWithValue("@dept", departmentId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapAssignment(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // REVOKE ASSIGNMENT
        // =========================
        public void Revoke(int assignmentId)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Assignments SET 
                  IsActive=0, RevokedDate=@revoked
                  WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", assignmentId);
                cmd.Parameters.AddWithValue("@revoked", DateTime.Now);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // MAPPING CENTRALISÉ
        // =========================
        private Assignment MapAssignment(SqlDataReader rd)
        {
            return new Assignment
            {
                Id = (int)rd["Id"],
                ResourceId = (int)rd["ResourceId"],
                ResourceType = rd["ResourceType"].ToString(),
                AssignedTo = rd["AssignedTo"].ToString(),
                AssignmentType = rd["AssignmentType"].ToString(),
                DepartmentId = rd["DepartmentId"] == DBNull.Value ? 0 : (int)rd["DepartmentId"],
                AssignedDate = (DateTime)rd["AssignedDate"],
                RevokedDate = rd["RevokedDate"] == DBNull.Value ? DateTime.Now : (DateTime)rd["RevokedDate"],
                IsActive = (bool)rd["IsActive"]
            };
        }
    }
}