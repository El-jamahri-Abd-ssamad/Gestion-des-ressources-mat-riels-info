using Microsoft.Data.SqlClient;
using Projet.Domain;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class ComputerDaoDB : IComputerDao
    {
        // =========================
        // INSERT
        // =========================
        public int Insert(Computer c)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Computers 
                  (InventoryNumber, Brand, CPU, RAM, HardDrive, Screen, DeliveryDate, 
                   SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt)
                  OUTPUT INSERTED.Id
                  VALUES (@inv,@brand,@cpu,@ram,@hdd,@screen,@delivery,@supplier,@assigned,@type,@dept,@created)", cn))
            {
                cmd.Parameters.AddWithValue("@inv", c.InventoryNumber);
                cmd.Parameters.AddWithValue("@brand", c.Brand);
                cmd.Parameters.AddWithValue("@cpu", c.CPU);
                cmd.Parameters.AddWithValue("@ram", c.RAM);
                cmd.Parameters.AddWithValue("@hdd", c.HardDrive);
                cmd.Parameters.AddWithValue("@screen", c.Screen);
                cmd.Parameters.AddWithValue("@delivery", c.DeliveryDate);
                cmd.Parameters.AddWithValue("@supplier", c.SupplierId);
                cmd.Parameters.AddWithValue("@assigned", c.AssignedTo);
                cmd.Parameters.AddWithValue("@type", c.AssignmentType);
                cmd.Parameters.AddWithValue("@dept", c.DepartmentId);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // =========================
        // GET BY ID
        // =========================
        public Computer GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, CPU, RAM, HardDrive, Screen, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Computers
                  WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return MapComputer(rd);
                    }
                }
            }
            return null;
        }

        // =========================
        // GET BY INVENTORY NUMBER
        // =========================
        public Computer GetByInventoryNumber(string inventoryNumber)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, CPU, RAM, HardDrive, Screen, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Computers
                  WHERE InventoryNumber=@inv", cn))
            {
                cmd.Parameters.AddWithValue("@inv", inventoryNumber);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return MapComputer(rd);
                    }
                }
            }
            return null;
        }

        // =========================
        // GET ALL
        // =========================
        public List<Computer> GetAll()
        {
            var list = new List<Computer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, CPU, RAM, HardDrive, Screen, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Computers", cn))
            {
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapComputer(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // GET BY DEPARTMENT
        // =========================
        public List<Computer> GetByDepartment(int departmentId)
        {
            var list = new List<Computer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, CPU, RAM, HardDrive, Screen, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Computers
                  WHERE DepartmentId=@dept", cn))
            {
                cmd.Parameters.AddWithValue("@dept", departmentId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapComputer(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // UPDATE
        // =========================
        public void Update(Computer c)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Computers SET 
                  Brand=@brand, CPU=@cpu, RAM=@ram, HardDrive=@hdd, Screen=@screen,
                  DeliveryDate=@delivery, SupplierId=@supplier, AssignedTo=@assigned,
                  AssignmentType=@type, DepartmentId=@dept, UpdatedAt=@updated
                  WHERE InventoryNumber=@inv", cn))
            {
                cmd.Parameters.AddWithValue("@inv", c.InventoryNumber);
                cmd.Parameters.AddWithValue("@brand", c.Brand);
                cmd.Parameters.AddWithValue("@cpu", c.CPU);
                cmd.Parameters.AddWithValue("@ram", c.RAM);
                cmd.Parameters.AddWithValue("@hdd", c.HardDrive);
                cmd.Parameters.AddWithValue("@screen", c.Screen);
                cmd.Parameters.AddWithValue("@delivery", c.DeliveryDate);
                cmd.Parameters.AddWithValue("@supplier", c.SupplierId);
                cmd.Parameters.AddWithValue("@assigned", c.AssignedTo);
                cmd.Parameters.AddWithValue("@type", c.AssignmentType);
                cmd.Parameters.AddWithValue("@dept", c.DepartmentId);
                cmd.Parameters.AddWithValue("@updated", DateTime.Now);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // DELETE
        // =========================
        public void Delete(string inventoryNumber)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"DELETE FROM Computers WHERE InventoryNumber=@inv", cn))
            {
                cmd.Parameters.AddWithValue("@inv", inventoryNumber);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // MAPPING CENTRALISÉ
        // =========================
        private Computer MapComputer(SqlDataReader rd)
        {
            return new Computer
            {
                Id = (int)rd["Id"],
                InventoryNumber = rd["InventoryNumber"].ToString(),
                Brand = rd["Brand"].ToString(),
                CPU = rd["CPU"].ToString(),
                RAM = rd["RAM"].ToString(),
                HardDrive = rd["HardDrive"].ToString(),
                Screen = rd["Screen"].ToString(),
                DeliveryDate = rd["DeliveryDate"] == DBNull.Value ? DateTime.Now : (DateTime)rd["DeliveryDate"],
                SupplierId = rd["SupplierId"] == DBNull.Value ? 0 : (int)rd["SupplierId"],
                AssignedTo = rd["AssignedTo"].ToString(),
                AssignmentType = rd["AssignmentType"].ToString(),
                DepartmentId = rd["DepartmentId"] == DBNull.Value ? 0 : (int)rd["DepartmentId"],
                CreatedAt = (DateTime)rd["CreatedAt"],
                UpdatedAt = rd["UpdatedAt"] == DBNull.Value ? DateTime.Now : (DateTime)rd["UpdatedAt"]
            };
        }
    }
}