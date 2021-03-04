use MyDB

CREATE TABLE Countries(
	CountryId int NOT NULL,
	CountryName varchar(50) CONSTRAINT chkCountryName CHECK(CountryName IN('Italy', 'India', 'China')),
	RegionId int NOT NULL,
	CONSTRAINT pkCountry PRIMARY KEY(CountryId, RegionId)
)

INSERT INTO Countries VALUES (1, 'India', 1)


CREATE TABLE JobHistory(
EmployeeId  decimal(6,0) NOT NULL,
JobId INT NOT NULL,
DepartmentId INT NOT NULL,
StartDate DATE NOT NULL,
EndDate DATE NOT NULL CHECK(EndDate LIKE '--/--/----')
)

INSERT JobHistory(EmployeeId,JobId,DepartmentId,StartDate,EndDate) VALUES(1,20,30,01/02/2020,02/02/2021)


CREATE TABLE Jobs(
	JobId int CONSTRAINT pkJobId PRIMARY KEY,
	JobTitle varchar(50) CONSTRAINT DefJobTitle DEFAULT '',
	MinSalary int CONSTRAINT DefMinSalary DEFAULT 8000,
	MaxSalary int CONSTRAINT DefMaxSalary DEFAULT NULL
)
SELECT * FROM Jobs




