
USE [test]
GO

Select OrderDetail.OrderHeaderId As [Order ID], Sum(UnitPrice) As [Total Value Per Order]
From [dbo].[OrderDetail]
Inner Join OrderHeader On OrderHeader.Id = OrderDetail.OrderHeaderId
Inner Join [dbo].[Customer] On Customer.Id = OrderHeader.CustomerId
Where Customer.AccountNumber = 'CUST001'
Group By OrderDetail.OrderHeaderId
Order By OrderDetail.OrderHeaderId

Go