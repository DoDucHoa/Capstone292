CREATE DATABASE BikeSaleSystemDB
GO

USE BikeSaleSystemDB
GO	

CREATE TABLE Depot --nha kho
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50),
	vailable NVARCHAR(50) DEFAULT N'Empty'
)
GO	

CREATE TABLE Account
(
	username NVARCHAR(50) PRIMARY KEY,
	password NVARCHAR(50) NOT NULL,
	fullname NVARCHAR(50) NOT NULL,
	email NCHAR(50) NOT NULL,
	isAdmin BIT NOT NULL DEFAULT 0 --false
)
GO	

CREATE TABLE AccountInfo
(
	username NVARCHAR(50) PRIMARY KEY,
	age INT NOT NULL,
	address NVARCHAR(50) DEFAULT N'N/A',
	birth DATE

	FOREIGN KEY (username) REFERENCES dbo.Account(username)
)
GO


CREATE TABLE BikeCategory --phan loai xe
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL
)
GO	

CREATE TABLE Company
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL
)

CREATE TABLE Bike
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	idCompany INT NOT NULL,
	version NCHAR(50) NOT NULL,
	cc INT NOT NULL

	FOREIGN KEY (idCategory) REFERENCES dbo.BikeCategory(id),
	FOREIGN KEY (idCompany) REFERENCES dbo.Company(id)
)
GO	

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE NOT NULL,
	idDepot INT NOT NULL,
	checkPay BIT NOT NULL --da thanh toan hay chua

	FOREIGN KEY (idDepot) REFERENCES dbo.Depot(id)
)
GO	

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idBike INT NOT NULL,

	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idBike) REFERENCES dbo.Bike(id)
)
GO	

DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT dbo.Depot
	        ( name)
	VALUES  ( N'Store ' + CAST(@i AS NVARCHAR(100)) -- name - nvarchar(50)
	          )
	SET @i = @i + 1
END
GO

CREATE PROC	USP_GetAccountByUserName --tao procedure
@username nvarchar(50)
AS	
BEGIN	
	SELECT * FROM dbo.Account WHERE	UserName = @username
END
GO

INSERT INTO dbo.Account
        ( username ,
          password ,
          fullname ,
          email ,
          isAdmin
        )
VALUES  ( N'sa' , -- username - nvarchar(50)
          N'123' , -- password - nvarchar(50)
          N'Hoa Do' , -- fullname - nvarchar(50)
          N'hhoa0978@gmail.com' , -- email - nchar(50)
          1  -- isAdmin - bit
        )
GO

INSERT INTO dbo.AccountInfo
        ( username, age, address, birth )
VALUES  ( N'sa', -- username - nvarchar(50)
          20, -- age - int
          N'101 TQK', -- address - nvarchar(50)
          '06-15-2000'  -- birth - date
          )
GO

INSERT INTO dbo.Account
        ( username ,
          password ,
          fullname ,
          email ,
          isAdmin
        )
VALUES  ( N'sb' , -- username - nvarchar(50)
          N'123' , -- password - nvarchar(50)
          N'Thanh Tri' , -- fullname - nvarchar(50)
          N'xxx@xxx.com' , -- email - nchar(50)
          0  -- isAdmin - bit
        )
INSERT INTO dbo.AccountInfo
        ( username, age, address, birth )
VALUES  ( N'sb', -- username - nvarchar(50)
          21, -- age - int
          N'101 TKT', -- address - nvarchar(50)
          '08-09-1999'  -- birth - date
          )
GO

INSERT INTO dbo.Account
        ( username ,
          password ,
          fullname ,
          email ,
          isAdmin
        )
VALUES  ( N'sc' , -- username - nvarchar(50)
          N'123' , -- password - nvarchar(50)
          N'An Anh' , -- fullname - nvarchar(50)
          N'xxx@xxx.com' , -- email - nchar(50)
          0  -- isAdmin - bit
        )
INSERT INTO dbo.AccountInfo
        ( username, age, address, birth )
VALUES  ( N'sc', -- username - nvarchar(50)
          22, -- age - int
          N'101 CMT8', -- address - nvarchar(50)
          '08-09-1998'  -- birth - date
          )
		  
GO

INSERT INTO dbo.Bike
        ( name ,
          idCategory ,
          price ,
          idCompany ,
          version ,
          cc
        )
VALUES  ( N'Winner X' , -- name - nvarchar(50)
          1 , -- idCategory - int
          50000000.0 , -- price - float
          1 , -- idCompany - int
          N'2019' , -- version - nchar(50)
          150  -- cc - int
        )
GO


INSERT INTO dbo.BikeCategory
        ( name )
VALUES  ( N'Standard'  -- name - nvarchar(50)
          ),
		  (N'Cruiser'),
		  (N'Sprot Bike'),
		  (N'Touring'),
		  (N'Scooter'),
		  (N'Off-road');
GO		

INSERT INTO dbo.Company
        ( name )
VALUES  ( N'Honda'  -- name - nvarchar(50)
          ),
		  (N'Yamaha'),
		  (N'Kawasaki'),
		  (N'Piaggio'),
		  (N'SYM')
GO

