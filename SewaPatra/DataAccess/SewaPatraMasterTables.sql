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
    Location VARCHAR(105),            -- Consider a more descriptive name
    Active Bit,                 -- Using Bit
    FOREIGN KEY (Area) REFERENCES Area_Master(Id),       -- Assuming Id is the PK in Area_Master
    FOREIGN KEY (Coordinator) REFERENCES Coordinator_master(ID) -- Assuming ID is the PK in Coordinator_master
);
CREATE TABLE DonationBox(
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Auto-incrementing ID (MySQL example)
    Box_Number VARCHAR(100),
    Active Bit  -- Use Bit for Active status
);
CREATE TABLE SewaPatraIssue (
    TranId VARCHAR(100) PRIMARY KEY,
    Entered_Date DATETIME NOT NULL,
    Donor INT NOT NULL,
    Coordinator INT NOT NULL,
    DonationBox INT NOT NULL,
    Issue_Date DATETIME NOT NULL,
    Recurring VARCHAR(255),
    Due_Date DATETIME,
    Remarks VARCHAR(MAX)
);

CREATE TABLE PaymentVoucher (
    P_TranId VARCHAR(255) PRIMARY KEY,
    Date VARCHAR(255),
    Ledger_Name VARCHAR(255),
    Coordinator VARCHAR(255),
    Amount VARCHAR(255),
    Remarks VARCHAR(255)
);
CREATE TABLE ReceiptVoucher (
    R_TranId VARCHAR(255) NOT NULL PRIMARY KEY,
    [Date] DATETIME,
    Sewapatra_No Int NOT NULL,
    Donor Int NOT NULL,
    Coordinator Int NOT NULL,
    Amount VARCHAR(255),
    Next_DueDate VARCHAR(255),
    Remarks VARCHAR(255)
);

--Coordinator Listing 
Select CM.id as [Coordinator ID],Name as [Name],Mobile_No As [Contact],Alternate_Mobile_No As [Alt.Contact],Address AS [Address],City As [City],Email,
Area_Under As [Area Code],Am.Area_name As [Area],AM.Area_type As [Area Type]
From Coordinator_master CM
Inner Join Area_Master AM On AM.Id=CM.Area_Under
Where 1=1 ORDER BY CM.Name ASC


--Donor Listing
Select DM.Id As [DonorId],DM.Mobile_no As [Contact],DM.Name As [name],DM.Address As [Address],Dm.City As [City],DM.Mobile_no2 as [Alt.Contact],
DM.Email As [Email],DM.Area As [Area Code],CM.Name AS [Coordinator Name],AM.Area_name As [Area]
from Donor_master DM 
Inner Join Area_Master AM On Am.ID=Dm.Area
Inner Join Coordinator_master CM ON CM.ID=DM.Coordinator

--Payment Register
Select P_TranId, [Date],Ledger_Name As [Bank Name],Amount,Cm.Name,Remarks
from PaymentVoucher PV
Inner Join Coordinator_master CM On CM.Id=PV.Coordinator
Where 1=1 ORDER BY PV.[Date] ASC

--Receipt Voucehr Register
Select R_TranId, [Date],db.Box_Number As [Donation Box],DM.Name As [Donor],Amount,Cm.Name As [Coordinator],Next_DueDate As [Next Due],Remarks
from ReceiptVoucher RV
Inner Join Coordinator_master CM On CM.Id=RV.Coordinator
Inner join DonationBox DB ON Db.Id=RV.Sewapatra_No
Inner Join Donor_master DM ON DM.Id=RV.Donor
Where 1=1 ORDER BY RV.[Date] ASC