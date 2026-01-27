-- Tables pour le module Maintenance & Pannes
CREATE TABLE Pannes (
    Id INT IDENTITY PRIMARY KEY,
    ResourceId INT NOT NULL,
    DeclaredByUserId NVARCHAR(450) NULL,
    DateDeclared DATETIME2 NOT NULL,
    DescriptionCourte NVARCHAR(MAX) NULL,
    Status INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL,
    UpdatedAt DATETIME2 NULL
    -- Ajouter FOREIGN KEY vers Resources si la table existe :
    -- , CONSTRAINT FK_Pannes_Resources FOREIGN KEY (ResourceId) REFERENCES Resources(Id)
);

CREATE TABLE Interventions (
    Id INT IDENTITY PRIMARY KEY,
    PanneId INT NOT NULL,
    TechnicianId NVARCHAR(450) NULL,
    DateIntervention DATETIME2 NOT NULL,
    ActionsTaken NVARCHAR(MAX) NULL,
    IsRepairable BIT NULL,
    ResultSummary NVARCHAR(MAX) NULL,
    CONSTRAINT FK_Interventions_Pannes FOREIGN KEY (PanneId) REFERENCES Pannes(Id)
);

CREATE TABLE Constats (
    Id INT IDENTITY PRIMARY KEY,
    PanneId INT NOT NULL,
    TechnicianId NVARCHAR(450) NULL,
    DateConstat DATETIME2 NOT NULL,
    DescriptionDetaillee NVARCHAR(MAX) NULL,
    DateApparition DATETIME2 NOT NULL,
    Frequence INT NOT NULL,
    Nature INT NOT NULL,
    SentToResponsable BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Constats_Pannes FOREIGN KEY (PanneId) REFERENCES Pannes(Id)
);

CREATE TABLE Decisions (
    Id INT IDENTITY PRIMARY KEY,
    ConstatId INT NOT NULL,
    ResponsableId NVARCHAR(450) NULL,
    DateDecision DATETIME2 NOT NULL,
    DecisionType INT NOT NULL,
    Reason NVARCHAR(MAX) NULL,
    WarrantyValid BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Decisions_Constats FOREIGN KEY (ConstatId) REFERENCES Constats(Id)
);