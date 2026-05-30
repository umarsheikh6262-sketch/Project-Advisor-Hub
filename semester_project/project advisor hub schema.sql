CREATE DATABASE ProjectAdvisorHub;
-- GO
-- USE ProjectAdvisorHub;
-- GO




-- 1. Users Table
CREATE TABLE Users (
    UserID INT NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

-- 2. Advisors Table
CREATE TABLE Advisors (
    AdvisorID VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    FieldOfStudy VARCHAR(100),
    Designation VARCHAR(50),
    Department VARCHAR(100),
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Advisors PRIMARY KEY (AdvisorID),
    CONSTRAINT UQ_Advisor_Email UNIQUE (Email)
);

-- 3. Groups Table (with GroupName)
CREATE TABLE Groups (
    GroupID VARCHAR(50) NOT NULL,
    GroupName NVARCHAR(100) NOT NULL,   -- Added to fix errors
    AdvisorID VARCHAR(50) NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_Groups PRIMARY KEY (GroupID),
    CONSTRAINT FK_Groups_Advisors FOREIGN KEY (AdvisorID) 
        REFERENCES Advisors(AdvisorID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 4. Students Table
CREATE TABLE Students (
    RollNo VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    Session VARCHAR(20) NOT NULL,
    Program VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    GroupID VARCHAR(50) NULL,
    CONSTRAINT PK_Students PRIMARY KEY (RollNo),
    CONSTRAINT UQ_Student_Email UNIQUE (Email),
    CONSTRAINT FK_Students_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 5. Projects Table (with EvaluationStatus)
CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) NOT NULL,
    GroupID VARCHAR(50) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Deadline DATETIME NOT NULL,
    EvaluationStatus NVARCHAR(50) DEFAULT 'Pending', -- Added to fix errors
    CONSTRAINT PK_Projects PRIMARY KEY (ProjectID),
    CONSTRAINT UQ_Project_Group UNIQUE (GroupID),
    CONSTRAINT FK_Projects_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 6. Submissions Table
CREATE TABLE Submissions (
    GroupID VARCHAR(50) NOT NULL,
    ProposalPath NVARCHAR(MAX),
    ProposalDate DATETIME,
    DocumentationPath NVARCHAR(MAX),
    DocumentationDate DATETIME,
    CONSTRAINT PK_Submissions PRIMARY KEY (GroupID),
    CONSTRAINT FK_Submissions_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE CASCADE
);

-- Seed Admin User
INSERT INTO Users (UserID, Username, Password, Role)
VALUES (1, 'admin', 'admin123', 'Admin');

IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE [object_id] = OBJECT_ID(N'dbo.Projects') AND name = 'Grade'
)
BEGIN
    ALTER TABLE dbo.Projects ADD Grade INT NULL;
END;

IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE [object_id] = OBJECT_ID(N'dbo.Projects') AND name = 'EvaluationStatus'
)
BEGIN
    ALTER TABLE dbo.Projects ADD EvaluationStatus NVARCHAR(50) NULL;
    ALTER TABLE dbo.Projects ADD CONSTRAINT DF_Projects_EvaluationStatus DEFAULT ('Pending') FOR EvaluationStatus;
    UPDATE dbo.Projects SET EvaluationStatus = 'Pending' WHERE EvaluationStatus IS NULL;
END;

IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE [object_id] = OBJECT_ID(N'dbo.Groups') AND name = 'GroupName'
)
BEGIN
    ALTER TABLE dbo.Groups ADD GroupName NVARCHAR(100) NOT NULL DEFAULT('');
END;



IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_Projects_EvaluationStatus'
      AND object_id = OBJECT_ID(N'dbo.Projects')
)
BEGIN
    CREATE NONCLUSTERED INDEX IX_Projects_EvaluationStatus
    ON dbo.Projects (EvaluationStatus)
    INCLUDE (GroupID, Deadline);
END
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = N'IX_Groups_AdvisorID'
      AND object_id = OBJECT_ID(N'dbo.Groups')
)
BEGIN
    CREATE NONCLUSTERED INDEX IX_Groups_AdvisorID
    ON dbo.Groups (AdvisorID);
END
GO

-- Quick checks
SELECT * FROM Students;
SELECT * FROM Advisors;
select * from Groups


