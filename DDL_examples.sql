--DDL (Data Definition language) example

--CREATE TABLE
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Price MONEY NOT NULL,
	Stock INT NOT NULL,
	CategoryId INT NOT NULL,

	FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE ProductFeatures
(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Height INT NOT NULL,
	Weight INT NOT NULL,
	ProductId INT NOT NULL,

	FOREIGN KEY(ProductId) REFERENCES Products(Id)
)

--ALTER TABLE

ALTER TABLE Products
ADD Descriptions nvarchar(50)

ALTER TABLE Products
DROP COLUMN Descriptions

ALTER TABLE Products
ALTER COLUMN Descriptions nvarchar(max)

--DELETE
DELETE FROM Categories

--TRUNCATE
TRUNCATE TABLE Categories --iliþkilendirildiði için bu komutla silemeyiz

--DROP TABLE
DROP TABLE Products --tüm tablo bir alt tabloyla bir iliþki yoksa içindeki verilerle birlikte silinir