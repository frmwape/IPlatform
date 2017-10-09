
USE [test]
GO

Select 'ALL CUSTOMERS' As Customers, 'ALL PRODUCTS' As Products, sum(OrderDetail.UnitPrice) As [Total Price]
From OrderDetail

Union
Select 'ALL CUSTOMERS', Product.Code, sum(OrderDetail.UnitPrice)
From Product
Inner Join OrderDetail On OrderDetail.ProductId = Product.Id
Group By Product.Code

Union 
Select Customer.AccountNumber, 'ALL PRODUCTS', sum(OrderDetail.UnitPrice)
From Customer
Inner Join OrderHeader On OrderHeader.Customerid = Customer.id
Inner Join OrderDetail On OrderHeader.id = OrderDetail.OrderHeaderId
Where Customer.AccountNumber = 'CUST001'
Group By Customer.AccountNumber

Union 
Select Customer.AccountNumber, Product.Code, sum(OrderDetail.UnitPrice)
From Customer
Inner Join OrderHeader On OrderHeader.Customerid = Customer.id
Inner Join OrderDetail On OrderHeader.id = OrderDetail.OrderHeaderId
Inner Join Product On Product.id = OrderDetail.ProductId
Where Customer.AccountNumber = 'CUST001'
Group By Customer.AccountNumber, Product.Code

Union 
Select Customer.AccountNumber, 'ALL PRODUCTS', sum(OrderDetail.UnitPrice)
From Customer
Inner Join OrderHeader On OrderHeader.Customerid = Customer.id
Inner Join OrderDetail On OrderHeader.id = OrderDetail.OrderHeaderId
Where Customer.AccountNumber = 'CUST002'
Group By Customer.AccountNumber

Union 
Select Customer.AccountNumber, Product.Code, sum(OrderDetail.UnitPrice)
From Customer
Inner Join OrderHeader On OrderHeader.Customerid = Customer.id
Inner Join OrderDetail On OrderHeader.id = OrderDetail.OrderHeaderId
Inner Join Product On Product.id = OrderDetail.ProductId
Where Customer.AccountNumber = 'CUST002'
Group By Customer.AccountNumber, Product.Code

Go