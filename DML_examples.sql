--DML (Data Manipulation Language) example
--INSERT
INSERT INTO Categories (Name)
				VALUES ('Printers')

INSERT INTO Products (Name,Stock,Price,CategoryId)
			   VALUES('Canon',5,1500,3)
--UPDATE
UPDATE Products SET Name='ACER' , Stock=6, Price= 15000
				WHERE ID=2
--DELETE
DELETE FROM Products WHERE ID IN (4,5)