 CREATE DATABASE ProjectAdvisorHub;
-- GO
-- USE ProjectAdvisorHub;
-- GO

-- 1. Create Users Table (Independent)
CREATE TABLE Users (
    UserID INT NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

-- 2. Create Advisors Table (Independent)
CREATE TABLE Advisors (
    AdvisorID VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    FieldOfStudy VARCHAR(100),       -- e.g., "Machine Learning"
    Designation VARCHAR(50),         -- e.g., "Assistant Professor"
    Department VARCHAR(100),         -- e.g., "Computer Science"
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Advisors PRIMARY KEY (AdvisorID),
    CONSTRAINT UQ_Advisor_Email UNIQUE (Email)
);

-- 3. Create Student Groups Table 
-- Includes AdvisorID to enforce exactly ONE advisor per group
CREATE TABLE Groups (
    GroupID VARCHAR(50) NOT NULL,
    AdvisorID VARCHAR(50) NULL,      -- Nullable if a group is formed before assigning an advisor
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_Groups PRIMARY KEY (GroupID),
    -- If an advisor is deleted, the group stays but their advisor link is cleared
    CONSTRAINT FK_Groups_Advisors FOREIGN KEY (AdvisorID) 
        REFERENCES Advisors(AdvisorID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 4. Create Students Table
CREATE TABLE Students (
    RollNo VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    Session VARCHAR(20) NOT NULL,    -- e.g., "2022-2026"
    Program VARCHAR(50) NOT NULL,    -- e.g., "BSCS"
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    GroupID VARCHAR(50) NULL,        -- Nullable because students might not have a group yet
    CONSTRAINT PK_Students PRIMARY KEY (RollNo),
    CONSTRAINT UQ_Student_Email UNIQUE (Email),
    -- If a group is deleted, student accounts remain intact but group link is set to NULL
    CONSTRAINT FK_Students_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 5. Create Projects Table (Strict 1-to-1 with Groups via Unique Constraint)
CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) NOT NULL,
    GroupID VARCHAR(50) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Deadline DATETIME NOT NULL,
    CONSTRAINT PK_Projects PRIMARY KEY (ProjectID),
    CONSTRAINT UQ_Project_Group UNIQUE (GroupID), -- Ensures 1 group cannot have multiple projects
    CONSTRAINT FK_Projects_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 6. Create Submissions Table
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

---
-- Seed Admin User Data
INSERT INTO Users (UserID, Username, Password, Role)
VALUES (1, 'admin', 'admin123', 'Admin');

select * from Students;