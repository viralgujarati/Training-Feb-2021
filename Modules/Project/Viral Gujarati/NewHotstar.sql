USE HOTSTARDATA;

CREATE TABLE UserAccount(
	 CustomerID INT PRIMARY KEY Identity(1,1),
	 Name NVARCHAR(30)  NOT NULL,
	 PhoneNumber int  NOT NULL,
	 Email NVARCHAR(30) UNIQUE NOT NULL,
	 Address NVARCHAR(30) NOT NULL,
	 DOB Date  
)


-- Category Table
CREATE TABLE Categories(
	CategoryId INT PRIMARY KEY IDENTITY(1,1),
	CategoryName VARCHAR(40) NOT NULL,
	
)

-- SubCategory Table
CREATE TABLE SubCategories(
	SubCategoryId INT PRIMARY KEY IDENTITY(1,1),
	SubCategoryName VARCHAR(40) NOT NULL,
	ParentCategoryId INT FOREIGN KEY REFERENCES Categories("CategoryId")
)




-- PLAN Information

CREATE TABLE "Plan"(
	PlanID INT PRIMARY KEY IDENTITY(1,1),   
	PlanCategory NVARCHAR(50) NOT NULL,
	--SubscriptionPlan NVARCHAR(30) NOT NULL,
	
)

CREATE TABLE SubcriptionPriceList(
	Id INT PRIMARY KEY Identity(1,1),   
	PlanId INT FOREIGN KEY REFERENCES "Plan"("PlanID"),
	Validity varchar(20) NOT NULL, 
	Price MONEY NOT NULL
)
	

--CREATE TABLE PlanFeatures(
--	ID INT Primary Key,
--	Feature NVARCHAR(MAX),
--	FREE BINARY,
--	VIP BINARY,
--	PREMIUM BINARY
--	)

-- Content Table

CREATE TABLE Content(
ContentId INT PRIMARY KEY IDENTITY(1,1),
ContentLink NVARCHAR(MAX) NOT NULL,
ContentPosterLink NVARCHAR(MAX) NOT NULL,
Title VARCHAR(50),
--Episode VARCHAR(50),
Genre VARCHAR(50),
"Description" NVARCHAR(MAX),
ReleaseDate datetime,
SuitableAge int,
SubCategoryId INT FOREIGN KEY REFERENCES SubCategories("SubCategoryId"),
CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId) NOT NULL,
PlanId INT FOREIGN KEY REFERENCES "Plan"(PlanID),
ContentLanguage VARCHAR(40)
)



CREATE TABLE SubscriptionDetail(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT FOREIGN KEY REFERENCES UserAccount(CustomerID) NOT NULL,
	PlanID INT FOREIGN KEY REFERENCES "Plan"(PlanID) NOT NULL,
	SubcriptionPriceListId INT FOREIGN KEY REFERENCES SubcriptionPriceList(ID),
	DateOfSubscription Datetime NOT NULL,
	ValidThrough Datetime
)

CREATE TABLE Shows (
	ShowID INT PRIMARY KEY IDENTITY(1,1),
	ShowName VARCHAR(50) NOT NULL,
	Episode INT,
	Season INT,
	ContentId INT FOREIGN KEY REFERENCES Content("ContentId")
)


-- Views 



CREATE VIEW vMovies
AS (
    SELECT *
    FROM Content
    WHERE CategoryId = (SELECT CategoryId
            FROM Categories
            WHERE CategoryName= 'Movies')
)

CREATE VIEW vSport
AS (
    SELECT *
    FROM Content
    WHERE CategoryId = (SELECT CategoryId
            FROM Categories
            WHERE CategoryName= 'Sport')
)


CREATE VIEW vFreeMovie
AS (
    SELECT *
    FROM Content
    WHERE PlanId = (SELECT PlanId
            FROM "Plan"
            WHERE PlanCategory = 'Free')
)

CREATE VIEW vPremiumMovie
AS (
    SELECT *
    FROM Content
    WHERE PlanId = (SELECT PlanId
            FROM "Plan"
            WHERE PlanCategory = 'Premium')
)



CREATE PROCEDURE SelectAllbyLanguage @Language nvarchar(30)
AS
SELECT * FROM Content WHERE CategoryId = (Select CategoryId  FROM Categories
            WHERE CategoryName= 'Movies')
			AND ContentLanguage = @Language



GO; 

exec SelectAllbyLanguage @Language = english


Create PROCEDURE SelectAllbyGenre @genre nvarchar(30)
AS
SELECT * FROM Content WHERE Genre =  @Genre 
			AND Genre = @genre

GO; 

exec SelectAllbyGenre @genre = Drama

