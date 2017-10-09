USE [test]
GO

Select Product.Code, Product.UnitPrice As [Product Price], OrderDetail.UnitPrice As [Sold Price]
From Product
Inner Join OrderDetail On OrderDetail.ProductId = Product.id
Where OrderDetail.UnitPrice > Product.UnitPrice
Order By Product.Code

Go