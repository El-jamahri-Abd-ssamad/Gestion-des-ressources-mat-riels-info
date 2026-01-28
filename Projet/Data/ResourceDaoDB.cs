using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Projet.Entities;

namespace Projet.Data
{
    public class ResourceDaoDB
    {
        public List<Resource> GetByAssignedTo(int userId)
        {
            var list = new List<Resource>();
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, Label, InventoryNumber, Barcode, Type, AssignedTo FROM Resource WHERE AssignedTo=@uid", cn))
            {
                cmd.Parameters.AddWithValue("@uid", userId);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Resource
                        {
                            Id = (int)rd["Id"],
                            Label = rd["Label"].ToString(),
                            InventoryNumber = rd["InventoryNumber"] == DBNull.Value ? "" : rd["InventoryNumber"].ToString(),
                            Barcode = rd["Barcode"] == DBNull.Value ? "" : rd["Barcode"].ToString(),
                            Type = rd["Type"].ToString(),
                            AssignedTo = rd["AssignedTo"] == DBNull.Value ? 0 : (int)rd["AssignedTo"]
                        });
                    }
                }
            }
            return list;
        }

        public Resource GetById(int id)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, Label, InventoryNumber, Barcode, Type, AssignedTo FROM Resource WHERE Id=@id", cn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Resource
                        {
                            Id = (int)rd["Id"],
                            Label = rd["Label"].ToString(),
                            InventoryNumber = rd["InventoryNumber"] == DBNull.Value ? "" : rd["InventoryNumber"].ToString(),
                            Barcode = rd["Barcode"] == DBNull.Value ? "" : rd["Barcode"].ToString(),
                            Type = rd["Type"].ToString(),
                            AssignedTo = rd["AssignedTo"] == DBNull.Value ? 0 : (int)rd["AssignedTo"]
                        };
                    }
                }
            }
            return null;
        }
    }
}