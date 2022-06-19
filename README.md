# Introduction 

Project Managment tool is a WEB API project designed for the managment of Projects.
It consists of records of projects, employees and work tasks.
Some of the functionalities of the project include creating, reading, updating and deleting projects by admins, while on the other hand, the user can assign tasks, or add new ones.
Another thing the user is able to filter projects by employee name and sort by end or start date.


The project also supports that user can select a specific project where he is shown all the information related to the project. The user can filter work tasks by whether the task is assigned to someone or not, by employee, whether completed or not, by the date of the task deadline, by name, by job description. Tasks are shown with pagination.

# Technologies

•	ASP .NET 6.0 Web API, 

•	Microsoft SQL Server, 

•	JWT, 

•	Hangfire


# Prerequisites

•	Microsoft Visual Studio 2022,

•	Microsoft SQL Server Management Studio 18,

•	Git


# Setup

# Visual studio setup

Before all, you need to clone the github repository and rebuild the whole solution in Visual Studio.
After rebuilding the solution, you have to update the database to create all the tables. To update the database, you have to open your solution and choose UserManagement.Database as the default project in the Package Manager Console. Use this command:

update-database

# Command Line Setup

First you will need to install the ASP.NET 5.0 SDK and Runtime from the official website. After that, open up a command line and navigate to the directory where you project was cloned. Type in:

dotnet ef database update

after updating the database, you can run the following command:

dotnet watch run

And the application will run.
