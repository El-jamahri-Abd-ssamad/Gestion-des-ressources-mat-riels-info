using Microsoft.Data.SqlClient;
using Projet.Domain;
using System.Collections.Generic;

namespace Projet.Data
{
    public class TenderItemDaoDB
    {
        public List<TenderItem> GetByTenderId(int tenderId)
        {
            var list = new List<TenderItem>();

            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Id, IdTender, Label, Quantity FROM TenderItem WHERE IdTender=@tid", cn))
            {
                cmd.Parameters.AddWithValue("@tid", tenderId);
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new TenderItem
                        {
                            Id = (int)rd["Id"],
                            IdTender = (int)rd["IdTender"],
                            Label = rd["Label"].ToString(),
                            Quantity = (int)rd["Quantity"]
                        });
                    }
                }
            }

            return list;
        }
    }
}
