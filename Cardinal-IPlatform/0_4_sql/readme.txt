What is expected in this test
-----------------------------
This test is all about SQL Server and querying the database to get information out of a SQL Server database

You should have a database called TEST on the local SQL Server instance. This database will serve as the data to query.

Questions
---------
Write queries to answer the list of questions below

1)	Get all the order numbers for customer with account number CUST001
2)	Get the total value per order for customer with account number CUST001
3)	Get all the order numbers with undelivered order lines
4)	Get all the order numbers where a product was sold for more than the product’s unit price. Display the product’s code, unit 	price and the order’s unit price
5)	Get a breakdown of all sales
		Per customer
		Per product

	where the total sales is per customer per product is greater than 100.00

	The result should look as follows:
		PROD1	CUST001		1416.33
		PROD2	CUST001		413.55
		PROD3	CUST001		1565.91
		PROD2	CUST002		234.5
		PROD3	CUST002		123.99

6)	Get a breakdown of all sales
		Per customer
		Per product
		For all customers
		For all product

	The result should look as follows:
	ALL CUSTOMERS	ALL PRODUCTS	3815.98
	ALL CUSTOMERS	PROD1			1478.03
	ALL CUSTOMERS	PROD2			648.05
	ALL CUSTOMERS	PROD3			1689.9
	CUST001			ALL PRODUCTS	3395.79
	CUST001			PROD1			1416.33
	CUST001			PROD2			413.55
	CUST001			PROD3			1565.91
	CUST002			ALL PRODUCTS	420.19
	CUST002			PROD1			61.7
	CUST002			PROD2			234.5
	CUST002			PROD3			123.99


