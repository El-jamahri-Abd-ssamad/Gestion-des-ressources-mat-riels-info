using Microsoft.Data.SqlClient;
using Projet.Domain;
using System.Collections.Generic;

namespace Projet.Data
{
    public class OfferItemDaoDB
    {
        public void Insert(OfferItem item)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO OfferItem (OfferId, Label, UnitPrice, Quantity)
                  VALUES (@oid,@label,@price,@qty)", cn))
            {
                cmd.Parameters.AddWithValue("@oid", item.IdOffer);
                cmd.Parameters.AddWithValue("@label", item.IdTenderItem);
                cmd.Parameters.AddWithValue("@price", item.UnitPrice);
                cmd.Parameters.AddWithValue("@qty", item.Quantity);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
