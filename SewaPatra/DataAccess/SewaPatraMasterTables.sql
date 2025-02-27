CREATE TABLE Area_Master (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Area_name VARCHAR(25),
    Area_type VARCHAR(15),
    Under VARCHAR(15)
);

CREATE TABLE Coordinator_master (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(125) NOT NULL,
    Mobile_No VARCHAR(15) NOT NULL,
    Alternate_Mobile_No VARCHAR(15),  -- Optional alternate number
    Address VARCHAR(125),
    City VARCHAR(25),
    Email VARCHAR(255) UNIQUE,       -- Increased length and made unique
    Area_Under VARCHAR(25),
    Active Bit,                 -- Using Bit
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP  -- Automatically sets creation time
);

CREATE TABLE Donor_master (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Mobile_no VARCHAR(15) NOT NULL,  -- Made NOT NULL
    Name VARCHAR(125) NOT NULL,      -- Made NOT NULL
    Address VARCHAR(125),
    City VARCHAR(25),
    Mobile_no2 VARCHAR(15),
    Email VARCHAR(255),            -- Increased length for emails
    Area INT,                       -- Foreign key
    Coordinator INT,                -- Foreign key
    Location VARCHAR(5),            -- Consider a more descriptive name
    Active Bit,                 -- Using Bit
    FOREIGN KEY (Area) REFERENCES Area_Master(Id),       -- Assuming Id is the PK in Area_Master
    FOREIGN KEY (Coordinator) REFERENCES Coordinator_master(ID) -- Assuming ID is the PK in Coordinator_master
);

    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing ID (MySQL example)
    Box_Number VARCHAR(100),
    Active Bit  -- Use Bit for Active status
);