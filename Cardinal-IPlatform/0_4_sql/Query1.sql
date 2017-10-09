
USE [test]
GO

Select OrderNumber
From [dbo].[OrderHeader]
Inner Join [dbo].[Customer] On Customer.Id = OrderHeader.CustomerId
Where Customer.AccountNumber = 'CUST001'
Order By OrderNumber

Go
