
### Exercise 1: SQL

Please read the instructions and proceed carefully as over 90% of applicants get this wrong.

Given the following tables and associated fields:

Person

PersonId, NameFirst, NameLast

Order

OrderId, PersonId, OrderDateTime

Write a SQL query that retrieves every person and their most recent order (if one exists).  Results should look something like this:

|PersonId	|NameFirst	|NameLast	|LastOrderId	|LastOrderDateTime|
| --- | --- | --- | --- | --- |
|1	|James	|Doe	|9843	|1/1/2013 9:01 AM|
|2	|John	|Doe	|NULL	|NULL|

In the above results, the first is a person with at least one order, the second row is a person without an order.

https://github.com/gitHubTechnetronic/BrainWare/blob/dc668830adc745cc13197a5775318208d0d7cd0e/ProjectDB/Stored%20Procedures/proc_PersonOrders.sql#L13-L18
I have worked on international projects so it is important to know if the DateTime in database is UTC or Local Time and do you want to display UTC or Local Time.

### Exercise 2: High Availability Upgrades

How would you reduce or eliminate application downtime during code and database upgrades?  Assume a setup as described in Exercise 1 above.    Please make sure to include what tools you would use and how you would utilize them.

I have experience with several deployment methods, worked with many different tools and created tools for companies that had trouble with deployments.

Which tools to use has to do with the cost and the budgetary constraints of the project (How much you want to spend on the tools). At a previous contract, an exorbitant amount was spent on Octopus Deploy (Consultants, training and full time employees).

Deployment problems often start at the beginning…so Unit testing, Code Review, Using Versioning, E2E testing, asking how to deploy during development, UAT environment with transitional settings for layer separation, and having hotfix procedures in place, can help mitigate some of these problems.

Analyze if you have Deployment Rings. Develop microservices and implement CI/CD. Use tools like (Action, Pipelines and/or Octopus Deploy). Use blue/green (A/B) deployment with load balancing.

I have worked on projects where my designs have been valuable, so without a consulting fee this is as far as I can go with free details.


### Exercise 3: Javascript

Calculate and print to the console the number of days between 1/1/2017 and the current date.   Then print to the console the current date formatted to look something like 12/1/2017 6:30:15 pm.  Feel free to use any public libraries as you see fit.

https://github.com/gitHubTechnetronic/BrainWare/blob/dc668830adc745cc13197a5775318208d0d7cd0e/Web/Scripts/App/ConsoleLogDate.js#L5-L21

### Exercise 4: C#

Write a data access method that takes a date as a parameter, calls a stored procedure (which returns all persons with orders for a specified date) and returns the results as a list of Person objects (PersonId, NameFirst, NameLast)

Make any assumptions that you feel are needed.  Please include a short description of those assumptions.

https://github.com/gitHubTechnetronic/BrainWare/blob/dc668830adc745cc13197a5775318208d0d7cd0e/DataAccessLibrary/DapperDataAccess.cs#L65-L75

Using Dapper ORM we call the Stored Procedure ignoring UTC or Local Time differences (This is handled on UI). 

https://github.com/gitHubTechnetronic/BrainWare/blob/dc668830adc745cc13197a5775318208d0d7cd0e/ProjectDB/Stored%20Procedures/proc_PersonOrdersByDate.sql#L6-L21

The results go back to the Repository.

https://github.com/gitHubTechnetronic/BrainWare/blob/7a5cf3b700bef13193c23ac5c55bc9ca3e2b621d/Web/ViewModels/PersonOrdersRepository.cs#L19-L37

After it is converted to the ViewModel it returns to the OrderService.

https://github.com/gitHubTechnetronic/BrainWare/blob/f5945ab97817ee288bf4956547bf64e6bfc1d03f/Web/Infrastructure/OrderService.cs#L48-L53

And then back to the API Controller.

https://github.com/gitHubTechnetronic/BrainWare/blob/dc668830adc745cc13197a5775318208d0d7cd0e/Web/Controllers/API/OrderController.cs#L51-L58

### Exercise 5:

If you were to start a website project today using .net.  What are the tools/technologies you would use (e.g. front-end UI, data access, etc...).  Please also describe why you've selected each and what you would use each for.

This all depends on the type of website project, industry and users.

VS and/or VSCode, .net 6, Blazor PWA, Blazor MVC and API, Git

Azure functions, Azure Monitor

SQL Server, Azure SQL, Azure Blob Storage

I have worked on projects where my designs have been valuable so without a consulting fee this is as far as I can go with free details.
