using System.Collections.Generic;
using Projet.Entities;

namespace Projet.Services
{
    public interface IFaultService
    {
        int DeclareFault(Fault fault); // enseignant
        List<Fault> GetAllFaults();
        List<Fault> GetFaultsByResource(int resourceId);
        Fault GetFaultById(int id);
        int CreateIntervention(Intervention intervention); // technicien prend en charge
        Intervention GetInterventionById(int id);
        int AddTechnicalReport(TechnicalReport report); // constat technique
        TechnicalReport GetReportByIntervention(int interventionId);
        void UpdateFaultStatus(int faultId, string status);
        void UpdateFaultStatus(object idFault, string v);
    }
}