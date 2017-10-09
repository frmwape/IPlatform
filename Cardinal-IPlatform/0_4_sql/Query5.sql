USE [test]
GO

Select Product.Code, Customer.AccountNumber, Sum(OrderDetail.UnitPrice) As TotalPrice
From Product
Inner Join OrderDetail On OrderDetail.ProductId = Product.id
Inner Join OrderHeader On OrderHeader.Id = OrderDetail.OrderHeaderId
Inner Join Customer On Customer.id = OrderHeader.CustomerId
Group By Product.Code, Customer.AccountNumber
Having Sum(OrderDetail.UnitPrice) > 100
Order By Product.Code, Customer.AccountNumber

Go