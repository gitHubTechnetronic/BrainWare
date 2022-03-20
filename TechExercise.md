
Exercise 1: SQL

Please read the instructions and proceed carefully as over 90% of applicants get this wrong.

Given the following tables and associated fields:

Person
PersonId, NameFirst, NameLast

Order
OrderId, PersonId, OrderDateTime

Write a SQL query that retrieves every person and their most recent order (if one exists).  Results should look something like this:

PersonId	NameFirst	NameLast	LastOrderId	LastOrderDateTime
1	James	Doe	9843	1/1/2013 9:01 AM
2	John	Doe	NULL	NULL

In the above results, the first is a person with at least one order, the second row is a person without an order.


Exercise 2: High Availability Upgrades

How would you reduce or eliminate application downtime during code and database upgrades?  Assume a setup as described in Exercise 1 above.    Please make sure to include what tools you would use and how you would utilize them.



Exercise 3: Javascript

Calculate and print to the console the number of days between 1/1/2017 and the current date.   Then print to the console the current date formatted to look something like 12/1/2017 6:30:15 pm.  Feel free to use any public libraries as you see fit.


Exercise 4: C#

Write a data access method that takes a date as a parameter, calls a stored procedure (which returns all persons with orders for a specified date) and returns the results as a list of Person objects (PersonId, NameFirst, NameLast)

Make any assumptions that you feel are needed.  Please include a short description of those assumptions.



Exercise 5:

If you were to start a website project today using .net.  What are the tools/technologies you would use (e.g. front-end UI, data access, etc...).  Please also describe why you've selected each and what you would use each for.