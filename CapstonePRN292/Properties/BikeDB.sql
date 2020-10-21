CREATE DATABASE BikeSaleSystemDB
GO

USE BikeSaleSystemDB
GO	

CREATE TABLE Depot --nha kho
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50),
	vailable BIT,
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

CREATE TABLE BikeCategory --phan loai xe
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL,
)
GO	

CREATE TABLE Bike
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL,
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0,
	company NVARCHAR(50) NOT NULL,
	version NCHAR(50) NOT NULL,
	cc INT NOT NULL

	FOREIGN KEY (idCategory) REFERENCES dbo.BikeCategory(id)
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



CREATE PROC	USP_GetAccountByUserName --tao procedure
@username nvarchar(50)
AS	
BEGIN	
	SELECT * FROM dbo.Account WHERE	UserName = @username
END
GO
