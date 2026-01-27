using System;

namespace Projet.Models
{
    public enum PanneStatus { Declaree = 0, EnCoursIntervention = 1, EnvoyeeAuFournisseur = 2, Reparee = 3, Remplacee = 4 }
    public enum Frequence { Rare = 0, Frequente = 1, Permanente = 2 }
    public enum NaturePanne { Logicielle = 0, Materielle = 1 }
    public enum DecisionType { ReparationChezFournisseur = 0, Remplacement = 1 }
}