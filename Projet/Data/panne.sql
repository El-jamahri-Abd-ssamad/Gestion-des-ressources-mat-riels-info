USE PRJT;

-- Tables pour le module Maintenance (Dev 5)
CREATE TABLE Resource (
    Id INT IDENTITY PRIMARY KEY,
    Label VARCHAR(150) NOT NULL,
    InventoryNumber VARCHAR(100) UNIQUE,
    Barcode VARCHAR(100),
    Type VARCHAR(50) NOT NULL, -- ex: Computer, Printer
    AssignedTo INT NULL, -- FK vers [User](Id)
    CONSTRAINT FK_Resource_User FOREIGN KEY (AssignedTo) REFERENCES [User](Id)
);

CREATE TABLE Fault (
    Id INT IDENTITY PRIMARY KEY,
    IdResource INT NOT NULL,
    DeclaredBy INT NOT NULL, -- User.Id (enseignant)
    DateDeclared DATETIME NOT NULL,
    Description TEXT NOT NULL,
    Status VARCHAR(20) NOT NULL DEFAULT 'Declared', -- Declared, InProgress, SentToSupplier, Repaired, Replaced
    CONSTRAINT FK_Fault_Resource FOREIGN KEY (IdResource) REFERENCES Resource(Id),
    CONSTRAINT FK_Fault_User FOREIGN KEY (DeclaredBy) REFERENCES [User](Id)
);

CREATE TABLE Intervention (
    Id INT IDENTITY PRIMARY KEY,
    IdFault INT NOT NULL,
    TechnicianId INT NOT NULL, -- User.Id
    DateTaken DATETIME NOT NULL,
    IsReparable BIT NULL, -- 1 = Réparable, 0 = Sévère (nécessite constat)
    Outcome VARCHAR(50) NULL, -- e.g. 'Repaired','SentToSupplier'
    Notes TEXT NULL,
    CONSTRAINT FK_Intervention_Fault FOREIGN KEY (IdFault) REFERENCES Fault(Id),
    CONSTRAINT FK_Intervention_Technician FOREIGN KEY (TechnicianId) REFERENCES [User](Id)
);

CREATE TABLE TechnicalReport (
    Id INT IDENTITY PRIMARY KEY,
    IdIntervention INT NOT NULL,
    DetailedDescription TEXT NOT NULL,
    DateOccurred DATETIME NOT NULL,
    Frequency VARCHAR(20) NOT NULL, -- Rare, Frequent, Permanent
    Nature VARCHAR(20) NOT NULL, -- Software, Hardware
    SentToResponsible BIT DEFAULT 1,
    CONSTRAINT FK_TechReport_Intervention FOREIGN KEY (IdIntervention) REFERENCES Intervention(Id)
);

CREATE INDEX IX_Fault_Resource ON Fault(IdResource);
CREATE INDEX IX_Fault_Status ON Fault(Status);
CREATE INDEX IX_Resource_Type ON Resource(Type);

