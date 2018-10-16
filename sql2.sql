SELECT * FROM Products	

UPDATE Products
SET Quantity = 0
WHERE ProductId = 8

select * from Orders

UPDATE Orders
SET State = 1

select * from OrderDetails
where OrderId = 18

select cmd,* from sys.sysprocesses
where blocked > 0

SELECT 
 * 
from 
 sys.dm_tran_locks