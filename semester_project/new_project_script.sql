
create database ProjectAdvisorHub;
-- 2. Create Student Groups Table
-- Must be created first so students and projects can reference it.
CREATE TABLE Groups (
    GroupID VARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_Groups PRIMARY KEY (GroupID)
);

-- 3. Create Students Table
CREATE TABLE Students (
    RollNo VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    Session VARCHAR(20) NOT NULL,    -- e.g., "2022-2026"
    Program VARCHAR(50) NOT NULL,    -- e.g., "BSCS", "BSEE"
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    GroupID VARCHAR(50) NULL,        -- Nullable because students might not have a group yet
    CONSTRAINT PK_Students PRIMARY KEY (RollNo),
    CONSTRAINT UQ_Student_Email UNIQUE (Email),
    -- If a group is deleted, we just clear the GroupID from the student rather than deleting the student entirely.
    CONSTRAINT FK_Students_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE SET NULL ON UPDATE CASCADE
);

-- 4. Create Advisors Table
CREATE TABLE Advisors (
    AdvisorID VARCHAR(50) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    FatherName VARCHAR(100),
    FieldOfStudy VARCHAR(100),       -- e.g., "Machine Learning", "Cybersecurity"
    Designation VARCHAR(50),         -- e.g., "Assistant Professor"
    Department VARCHAR(100),         -- e.g., "Computer Science"
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    CONSTRAINT PK_Advisors PRIMARY KEY (AdvisorID),
    CONSTRAINT UQ_Advisor_Email UNIQUE (Email)
);

-- 5. Create Projects Table
-- Each project is assigned directly to a unique group (1-to-1 relationship per project instance).
CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) NOT NULL,
    GroupID VARCHAR(50) NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    Deadline DATETIME NOT NULL,
    CONSTRAINT PK_Projects PRIMARY KEY (ProjectID),
    CONSTRAINT UQ_Project_Group UNIQUE (GroupID), -- Ensures a group doesn't accidentally get assigned multiple projects
    -- Cascades deletion: If a group is deleted, its project specification details are deleted too.
    CONSTRAINT FK_Projects_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE CASCADE ON UPDATE CASCADE
);

-- 6. Create GroupAdvisors Junction Table
-- Since your requirements state a group can have "one or multiple advisors", this many-to-many
-- bridge table cleanly handles multi-advisor allocations without breaking database normalization forms.
CREATE TABLE GroupAdvisors (
    GroupID VARCHAR(50) NOT NULL,
    AdvisorID VARCHAR(50) NOT NULL,
    AssignedAt DATETIME DEFAULT GETDATE(),
    CONSTRAINT PK_GroupAdvisors PRIMARY KEY (GroupID, AdvisorID),
    -- Cascades deletion: If a group is deleted, its advisor links drop automatically.
    CONSTRAINT FK_GA_Groups FOREIGN KEY (GroupID) 
        REFERENCES Groups(GroupID) ON DELETE CASCADE ON UPDATE CASCADE,
    -- Cascades deletion: If an advisor is deleted, their group links drop automatically.
    CONSTRAINT FK_GA_Advisors FOREIGN KEY (AdvisorID) 
        REFERENCES Advisors(AdvisorID) ON DELETE CASCADE ON UPDATE CASCADE
);


--User Table also exists--
CREATE TABLE Users (
    UserID INT NOT NULL PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);
INSERT INTO Users (UserID, Username, Password, Role)
VALUES (1, 'admin', 'admin123', 'Admin');
