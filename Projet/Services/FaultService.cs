using System;
using System.Collections.Generic;
using Projet.Data;
using Projet.Entities;

namespace Projet.Services
{
    public class FaultService : IFaultService
    {
        FaultDaoDB faultDao = new FaultDaoDB();
        InterventionDaoDB interventionDao = new InterventionDaoDB();
        TechnicalReportDaoDB reportDao = new TechnicalReportDaoDB();

        public int DeclareFault(Fault fault)
        {
            // règle métier : statut initial = Declared
            fault.Status = "Declared";
            fault.DateDeclared = DateTime.Now;
            return faultDao.Insert(fault);
        }

        public List<Fault> GetAllFaults()
        {
            return faultDao.GetAll();
        }

        public List<Fault> GetFaultsByResource(int resourceId)
        {
            return faultDao.GetByResourceId(resourceId);
        }

        public Fault GetFaultById(int id)
        {
            return faultDao.GetById(id);
        }

        public int CreateIntervention(Intervention intervention)
        {
            int id = interventionDao.Insert(intervention);
            faultDao.UpdateStatus(intervention.IdFault, "InProgress");
            return id;
        }

        public Intervention GetInterventionById(int id)
        {
            return interventionDao.GetById(id);
        }

        public int AddTechnicalReport(TechnicalReport report)
        {
            int id = reportDao.Insert(report);
            return id;
        }

        public TechnicalReport GetReportByIntervention(int interventionId)
        {
            return reportDao.GetByInterventionId(interventionId);
        }

        public void UpdateFaultStatus(int faultId, string status)
        {
            faultDao.UpdateStatus(faultId, status);
        }

        public void UpdateFaultStatus(object idFault, string v)
        {
            throw new NotImplementedException();
        }
    }
}