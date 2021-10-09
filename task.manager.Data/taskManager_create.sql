-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2021-09-20 20:57:03.643

-- tables
-- Table: Manager
CREATE TABLE Manager (
    Id int  NOT NULL ,
    Name varchar(20)  NOT NULL,
    Surname varchar(20)  NOT NULL,
    Email varchar(20)  NOT NULL,
    Active bit  NOT NULL,
    CONSTRAINT Id PRIMARY KEY  (Id)
);

-- Table: Project
CREATE TABLE Project (
    Id int  NOT NULL,
    Name varchar(20)  NOT NULL,
    Active bit  NOT NULL,
    Duration decimal(7,4)  NOT NULL,
    Remaining decimal(7,4)  NOT NULL,
    Manager_Id int  NOT NULL,
    Worker_Id int  NOT NULL,
    CONSTRAINT Project_pk PRIMARY KEY  (Id)
);

-- Table: Status
CREATE TABLE Status (
    Id int  NOT NULL,
    Name varchar(20)  NOT NULL,
    CONSTRAINT Status_pk PRIMARY KEY  (Id)
);

-- Table: Task
CREATE TABLE Task (
    Id int  NOT NULL,
    Name varchar(20)  NOT NULL,
    Estimation decimal(3,2)  NOT NULL,
    Active bit  NOT NULL,
    Remaining decimal(3,2)  NOT NULL,
    Manager_Id int  NOT NULL,
    Status_Id int  NOT NULL,
    Project_Id int  NOT NULL,
    Member_Id int  NOT NULL,
    CONSTRAINT Task_pk PRIMARY KEY  (Id)
);

-- Table: Worker
CREATE TABLE Worker (
    Id int  NOT NULL,
    Name varchar(20)  NOT NULL,
    Surname varchar(20)  NOT NULL,
    Email varchar(20)  NOT NULL,
    Active bit  NOT NULL,
    CONSTRAINT Worker_pk PRIMARY KEY  (Id)
);

-- foreign keys
-- Reference: Project_Manager (table: Project)
ALTER TABLE Project ADD CONSTRAINT Project_Manager
    FOREIGN KEY (Manager_Id)
    REFERENCES Manager (Id);

-- Reference: Project_Worker (table: Project)
ALTER TABLE Project ADD CONSTRAINT Project_Worker
    FOREIGN KEY (Worker_Id)
    REFERENCES Worker (Id);

-- Reference: Task_Manager (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_Manager
    FOREIGN KEY (Manager_Id)
    REFERENCES Manager (Id);

-- Reference: Task_Member (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_Member
    FOREIGN KEY (Member_Id)
    REFERENCES Worker (Id);

-- Reference: Task_Project (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_Project
    FOREIGN KEY (Project_Id)
    REFERENCES Project (Id);

-- Reference: Task_Status (table: Task)
ALTER TABLE Task ADD CONSTRAINT Task_Status
    FOREIGN KEY (Status_Id)
    REFERENCES Status (Id);

-- End of file.

