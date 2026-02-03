using Projet.Domain;
using Projet.Domain.enums;
using System.Collections.Generic;

namespace Projet.Data
{
    public interface IBesoinDao
    {
        List<Besoin> GetBesoinsEnvoyes();
        void UpdateStatut(int besoinCode, StatutBesoin statut);
    }
}