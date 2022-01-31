# BrainWare Order List

This is a very small sample web application written in a very simplistic manner.

Grab the code and refactor it so that it meets your standard for production ready code.

There is no need to add additional functionality and you do not need to keep the existing code or project structure.

The only requirement is that it returns the list of orders and that it meets your standards!

Fork this project to your personal repo and commit all your changes to that branch. 

## Changes for Running Locally

Update the connection string in the class <project root>\Web\Infrastructure\Database.cs.

Change the AttachDbFile name to the full path of the BrainWare.mdf file (located under <project root>\Web\App_Data\).


## Original Output Example
![page image](output.GIF?raw=true)


## Setup

### Database Setup
- Start SQL Server Management Studio as Administrator
- Once connected to your local SQL Server instance
- Right click on the Database node and select Attach
- Select the file BrainWare\Web\App_Data\BrainWare.mdf

- You can also deploy the project ProjectDB to your local SQL Server instance
- Then execute in SQL Server Management Studio the file BrainWare\ProjectDB\PopulateDB.sql

### Visual Studio
- Open solution BrainWare\BrainWare.sln
- Update the database connection string in file Web\Infrastructure\Database.cs
- Set the project Web, as the start up project
- Press F5
- Expected a browser is open with the result of the first order


## Refactor Notes
### MVC
- Added data access layer
- Added Stored Procedures
- Added repository
- Added ViewModels
- Added simple authorization token
- Added code to Test
- Added some custom error pages
- Several code changes…


#### More refactoring to consider
- Adding EF or Dapper
- Adding an IOC container and more decoupling  Note: Watch out for Leaky Abstractions i.e.(try not to use Lazy<>)
- Adding Login Features
- Adding more Unit Test and creating separate test data
- Adding details to the API Help pages. Note: Do not use Swagger because of risk of third party vulnerabilities Example(https://nvd.nist.gov/vuln/detail/CVE-2021-21363)
Also make sure the API is secure (A Cautionary Tale from a coworker) and like the insurance companies and many other organizations do not share or auto generate the API documentation.  The API documentation should be secured and shared with only entities that need it and changes communicated with them on a timely bases.
- Adding Angular
- Improve UI of the custom error pages
- Change Production Web.Release.config for connectionstring 
- Upgrading .net framework and use System.Text.Json
- Separate the Service Layer from Web Project
- Upgrade bootstrap and other Nuget packages
- Make sure we have explicitly type for readability
- Several other code changes…
	
### Blazor Server
- Added vscode project for a bonus example with minimal refactoring.  
- Run on cmdline in Blazor folder “dotnet watch”





