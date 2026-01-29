using Microsoft.Data.SqlClient;
using Projet.Domain;
using System;
using System.Collections.Generic;

namespace Projet.Data
{
    public class PrinterDaoDB : IPrinterDao
    {
        // =========================
        // INSERT
        // =========================
        public int Insert(Printer p)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Printers 
                  (InventoryNumber, Brand, PrintSpeed, Resolution, DeliveryDate, 
                   SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt)
                  OUTPUT INSERTED.Id
                  VALUES (@inv,@brand,@speed,@res,@delivery,@supplier,@assigned,@type,@dept,@created)", cn))
            {
                cmd.Parameters.AddWithValue("@inv", p.InventoryNumber);
                cmd.Parameters.AddWithValue("@brand", p.Brand);
                cmd.Parameters.AddWithValue("@speed", p.PrintSpeed);
                cmd.Parameters.AddWithValue("@res", p.Resolution);
                cmd.Parameters.AddWithValue("@delivery", p.DeliveryDate);
                cmd.Parameters.AddWithValue("@supplier", p.SupplierId);
                cmd.Parameters.AddWithValue("@assigned", p.AssignedTo);
                cmd.Parameters.AddWithValue("@type", p.AssignmentType);
                cmd.Parameters.AddWithValue("@dept", p.DepartmentId);
                cmd.Parameters.AddWithValue("@created", DateTime.Now);

                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // =========================
        // GET BY ID
        // =========================
        public Printer GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, PrintSpeed, Resolution, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Printers
                  WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return MapPrinter(rd);
                    }
                }
            }
            return null;
        }

        // =========================
        // GET BY INVENTORY NUMBER
        // =========================
        public Printer GetByInventoryNumber(string inventoryNumber)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, PrintSpeed, Resolution, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Printers
                  WHERE InventoryNumber=@inv", cn))
            {
                cmd.Parameters.AddWithValue("@inv", inventoryNumber);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return MapPrinter(rd);
                    }
                }
            }
            return null;
        }

        // =========================
        // GET ALL
        // =========================
        public List<Printer> GetAll()
        {
            var list = new List<Printer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, PrintSpeed, Resolution, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Printers", cn))
            {
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapPrinter(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // GET BY DEPARTMENT
        // =========================
        public List<Printer> GetByDepartment(int departmentId)
        {
            var list = new List<Printer>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, InventoryNumber, Brand, PrintSpeed, Resolution, 
                         DeliveryDate, SupplierId, AssignedTo, AssignmentType, DepartmentId, CreatedAt, UpdatedAt
                  FROM Printers
                  WHERE DepartmentId=@dept", cn))
            {
                cmd.Parameters.AddWithValue("@dept", departmentId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(MapPrinter(rd));
                    }
                }
            }

            return list;
        }

        // =========================
        // UPDATE
        // =========================
        public void Update(Printer p)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Printers SET 
                  Brand=@brand, PrintSpeed=@speed, Resolution=@res,
                  DeliveryDate=@delivery, SupplierId=@supplier, AssignedTo=@assigned,
                  AssignmentType=@type, DepartmentId=@dept, UpdatedAt=@updated
                  WHERE InventoryNumber=@inv", cn))
            {
                cmd.Parameters.AddWithValue("@inv", p.InventoryNumber);
                cmd.Parameters.AddWithValue("@brand", p.Brand);
                cmd.Parameters.AddWithValue("@speed", p.PrintSpeed);
                cmd.Parameters.AddWithValue("@res", p.Resolution);
                cmd.Parameters.AddWithValue("@delivery", p.DeliveryDate);
                cmd.Parameters.AddWithValue("@supplier", p.SupplierId);
                cmd.Parameters.AddWithValue("@assigned", p.AssignedTo);
                cmd.Parameters.AddWithValue("@type", p.AssignmentType);
                cmd.Parameters.AddWithValue("@dept", p.DepartmentId);
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
                @"DELETE FROM Printers WHERE InventoryNumber=@inv", cn))
            {
                cmd.Parameters.AddWithValue("@inv", inventoryNumber);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =========================
        // MAPPING CENTRALISÉ
        // =========================
        private Printer MapPrinter(SqlDataReader rd)
        {
            return new Printer
            {
                Id = (int)rd["Id"],
                InventoryNumber = rd["InventoryNumber"].ToString(),
                Brand = rd["Brand"].ToString(),
                PrintSpeed = (int)rd["PrintSpeed"],
                Resolution = rd["Resolution"].ToString(),
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