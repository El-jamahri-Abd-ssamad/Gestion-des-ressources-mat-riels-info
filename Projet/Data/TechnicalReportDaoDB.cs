using System;
using Microsoft.Data.SqlClient;
using Projet.Entities;

namespace Projet.Data
{
    public class TechnicalReportDaoDB
    {
        public int Insert(TechnicalReport tr)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO TechnicalReport (IdIntervention, DetailedDescription, DateOccurred, Frequency, Nature, SentToResponsible)
                  OUTPUT INSERTED.Id
                  VALUES (@i,@d,@date,@freq,@nature,@sent)", cn))
            {
                cmd.Parameters.AddWithValue("@i", tr.IdIntervention);
                cmd.Parameters.AddWithValue("@d", tr.DetailedDescription);
                cmd.Parameters.AddWithValue("@date", tr.DateOccurred);
                cmd.Parameters.AddWithValue("@freq", tr.Frequency);
                cmd.Parameters.AddWithValue("@nature", tr.Nature);
                cmd.Parameters.AddWithValue("@sent", tr.SentToResponsible);
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public TechnicalReport GetByInterventionId(int interventionId)
        {
            using (SqlConnection cn = DbFactory.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT Id, IdIntervention, DetailedDescription, DateOccurred, Frequency, Nature, SentToResponsible
                  FROM TechnicalReport WHERE IdIntervention=@i", cn))
            {
                cmd.Parameters.AddWithValue("@i", interventionId);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new TechnicalReport
                        {
                            Id = (int)rd["Id"],
                            IdIntervention = (int)rd["IdIntervention"],
                            DetailedDescription = rd["DetailedDescription"].ToString(),
                            DateOccurred = (DateTime)rd["DateOccurred"],
                            Frequency = rd["Frequency"].ToString(),
                            Nature = rd["Nature"].ToString(),
                            SentToResponsible = (bool)rd["SentToResponsible"]
                        };
                    }
                }
            }
            return null;
        }
    }
}