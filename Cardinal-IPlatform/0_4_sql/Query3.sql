USE [test]
GO

Select Distinct OrderNumber From
OrderHeader
Inner Join OrderDetail On OrderDetail.OrderHeaderId = OrderHeader.Id
Where ((OrderDetail.QtyOrdered - OrderDetail.QtyShipped) > 0)
Order By OrderNumber

Go