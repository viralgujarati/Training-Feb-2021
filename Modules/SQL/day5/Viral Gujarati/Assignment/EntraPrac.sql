USE MyDB

CREATE TABLE Cars
(CarId INT UNIQUE NOT NULL,
VIN INT PRIMARY KEY,
Make NVARCHAR(20),
Modal NVARCHAR(20),
Year INT,
Mileage DECIMAL(3,2),
AskPrice MONEY,
InvoicePrice MONEY);

ALTER TABLE Cars
ALTER COLUMN Mileage FLOAT;


INSERT INTO Cars
VALUES(1,1001,'Toyota','Camry',2010,23,1000,9500),
     (2,3001,'Maruti Suzuki','Breeza',2013,25,2000,7500)



		
CREATE TABLE Dealerships(
	DealerShipId int CONSTRAINT PkDealerShipId PRIMARY KEY IDENTITY,
	Name varchar(25) NOT NULL,
	Address varchar(50) NOT NULL,
	City varchar(20) NOT NULL,
	State varchar(20) NOT NULL)





CREATE TABLE SalesPersons(
	SalesPersonId int CONSTRAINT PkSalesPersonId PRIMARY KEY IDENTITY,
	Name varchar(25) NOT NULL,)



CREATE TABLE Customers(
	CustomerId int CONSTRAINT PkcustomerId PRIMARY KEY IDENTITY,
	Name varchar(25) NOT NULL,
	Address varchar(50) NOT NULL,
	City varchar(20) NOT NULL,
	State varchar(20) NOT NULL)



CREATE TABLE ReportsTo(
	ReportsToId int CONSTRAINT PkReportsToId PRIMARY KEY IDENTITY,
	SalesPersonId int CONSTRAINT FkReportSPId FOREIGN KEY REFERENCES SalesPersons(SalesPersonId),
	ManagingSalesPersonId int CONSTRAINT FkReportMSPId FOREIGN KEY REFERENCES SalesPersons(SalesPersonId))



CREATE TABLE WorksAt(
	WorksAtId int CONSTRAINT PkWorksAtId PRIMARY KEY IDENTITY, 
	SalesPersonId int CONSTRAINT FkWorksSPId FOREIGN KEY REFERENCES SalesPersons(SalesPersonId),
	DealerShipId int CONSTRAINT FkWorksDSId FOREIGN KEY REFERENCES Dealerships(DealerShipId),
	MonthWorked varchar(20) NOT NULL,
	BaseSalaryForMonth int NOT NULL,)

CREATE TABLE Inventory(
	InventoryId int CONSTRAINT PkInventoryId PRIMARY KEY IDENTITY,
	Vin int CONSTRAINT FkInventoryVin FOREIGN KEY REFERENCES Car(Vin),
	DealerShipId int CONSTRAINT FkInventoryDId FOREIGN KEY REFERENCES Dealerships(DealerShipId))



CREATE TABLE Sales(
	SaleId int CONSTRAINT PkSaleId PRIMARY KEY IDENTITY,
	Vin int CONSTRAINT FkSaleVin FOREIGN KEY REFERENCES Car(Vin),
	CustomerId int CONSTRAINT FkSaleCId FOREIGN KEY REFERENCES Customers(CustomerId),
	SalesPersonId int CONSTRAINT FkSaleSPId FOREIGN KEY REFERENCES SalesPersons(SalesPersonId),
	DealerShipId int CONSTRAINT FkSaleDId FOREIGN KEY REFERENCES Dealerships(DealerShipId),
	SalePrice int NOT NULL,
	SaleDate date NOT NULL)


Select * from SalesPersons