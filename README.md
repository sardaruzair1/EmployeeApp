# EmployeeApp
EmployeeApp In DOTNET MVC
.NET 6 CRUD Application using Code First Approach and Entity Framework
This is a simple CRUD (Create, Read, Update, Delete) application built using .NET 6, Code First Approach, and Microsoft Entity Framework. It allows you to manage a list of products, where you can add, view, update, and delete products.

Prerequisites
.NET 6 SDK
Visual Studio 2022 or Visual Studio Code
Getting Started
Clone or download the repository to your local machine.
Open the solution in Visual Studio 2022 or Visual Studio Code.
Build the solution.
Run the application.
Application Structure
The application consists of the following folders:

Controllers - Contains the API controllers.
Data - Contains the DbContext and migrations.
Models - Contains the model classes.
Properties - Contains the launchSettings.json file.
wwwroot - Contains the static files (CSS, JS, images).
Views - Contains the Razor views.
Configurations
The application uses Entity Framework to connect to a database and perform CRUD operations. The database connection string can be found in the appsettings.json file, which is located in the root directory of the project.

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProductDb;Trusted_Connection=True;"
}
By default, the application uses a localdb instance, but you can replace it with any other SQL Server instance.

Database Migrations
To create the database schema, open the Package Manager Console in Visual Studio and run the following command:

powershell
Copy code
Update-Database
This command will apply any pending migrations and create the database schema.

API Endpoints
The application exposes the following API endpoints:

HTTP Method	Endpoint	Description
GET	/api/products	Gets all products.
GET	/api/products/{id}	Gets a single product.
POST	/api/products	Creates a new product.
PUT	/api/products/{id}	Updates an existing product.
DELETE	/api/products/{id}	Deletes a product.
Credits
This application was created by sardar uzair. Feel free to use it as a starting point for your own projects.





