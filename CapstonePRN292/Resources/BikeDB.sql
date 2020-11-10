CREATE DATABASE BikeSaleSystemDB
GO

USE BikeSaleSystemDB
GO	

CREATE TABLE Customer
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(50) NOT NULL,
	email VARCHAR(50) NOT NULL,
	address NVARCHAR(100) NOT NULL,
	birth DATE NOT NULL
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
	birth DATE,

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
	version INT NOT NULL,
	cc INT NOT NULL,
	quantity INT NOT NULL,

	FOREIGN KEY (idCategory) REFERENCES dbo.BikeCategory(id),
	FOREIGN KEY (idCompany) REFERENCES dbo.Company(id)
)
GO

CREATE TABLE PaymentMethod
(
	id INT IDENTITY PRIMARY KEY,
	method VARCHAR(50) NOT NULL
)
GO

CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	totalPrice FLOAT NOT NULL,
	quantity INT NOT NULL DEFAULT 1,
	idPaymentMethod INT NOT NULL,
	idBike INT NOT NULL,
	idCustomer INT NOT NULL,

	FOREIGN KEY (idCustomer) REFERENCES dbo.Customer(id),
	FOREIGN KEY (idBike) REFERENCES dbo.Bike(id),
	FOREIGN KEY (idPaymentMethod) REFERENCES dbo.PaymentMethod(id)
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

INSERT INTO dbo.AccountInfo
        ( username, age, address, birth )
VALUES  ( N'sa', -- username - nvarchar(50)
          20, -- age - int
          N'101 TQK', -- address - nvarchar(50)
          '06-15-2000'  -- birth - date
          )
GO

INSERT INTO dbo.PaymentMethod
        ( method )
VALUES  (
          'Credit Cards'  -- method - varchar(50)
          ),
		  ('Mobile Payment'),
		  ('Bank Transfer'),
		  ('Ewallet'),
		  ('Prepaid Card'),
		  ('Direct Deposit'),
		  ('Cash')
GO          

INSERT INTO dbo.Customer
        ( name, email, address, birth )
VALUES  (  
          N'Hoa Do', -- name - nvarchar(50)
          N'hoado@gmail.com', -- age - int
          N'101 TKT', -- address - nvarchar(100)
          '06-15-2000' 
          ),
		  (  
          N'Thanh Tri', -- name - nvarchar(50)
          N'thanhtri@gmail.com', -- age - int
          N'101 TQK', -- address - nvarchar(100)
          '03-03-1999'  
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

INSERT INTO dbo.Bike
        ( 
          name ,
          idCategory ,
          price ,
          idCompany ,
          version ,
          cc ,
          quantity
        )
VALUES  ( 
          N'Winner X' , -- name - nvarchar(50)
          1 , -- idCategory - int
          50000000.0 , -- price - float
          1 , -- idCompany - int
          2019 , -- version - int
          150 , -- cc - int
          10  -- quantity - int
        )
GO


