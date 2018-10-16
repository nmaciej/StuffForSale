SELECT * FROM Tags

SELECT * FROM AspNetUsers
SELECT * FROM Products
SELECT * FROM Orders
SELECT * FROM OrderDetails

DELETE FROM AspNetUsers
DELETE FROM Products
DELETE FROM Orders
DELETE FROM OrderDetails

INSERT INTO Tags (Name) 
VALUES ('Electronics'),('Cars'),('Books')

INSERT INTO Tags (Name) 
VALUES ('Instruments')

UPDATE Orders
SET Active=1

SELECT * FROM ORDERS