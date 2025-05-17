Student Management System – User Guide

Backend: Dot Net Core – Web API – Entity Framework Code First Approach – SQL Server - Clear Architecture

✅ Prerequisites
Ensure the following are installed on your machine:
•	.NET SDK 6.0 or later
•	SQL Server
•	Visual Studio 2022+ (or Visual Studio Code + C# Extensions)
•	Git
•	EF Core CLI Tools (included in .NET SDK)
________________________________________
🔁 1. Clone the Backend Repository
git clone https://github.com/SheikGH/SMS_Asp.NetCore_WebAPI_Backend.git
Navigate into the project folder:
cd SMS_Asp.NetCore_WebAPI_Backend
________________________________________
⚙️ 2. Open the Project
Open the solution in Visual Studio (SMS.sln) or open the folder in VS Code.
________________________________________
🛠️ 3. Configure the Database Connection
Open appsettings.json in the SMS.API project and update your SQL Server connection string:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SMS_DB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Make sure the database name SMS_DB and SQL Server instance (e.g., localhost, .\SQLEXPRESS) match your setup.

Set up database details in the appsettings.json 
 
________________________________________
🧱 4. Run EF Core Migration and Update Database
Make sure SMS.API is the startup project, then open the Package Manager Console (PMC):
Option A: Using PMC in Visual Studio
PM> Add-Migration InitialCreate -Project SMS.Infrastructure -StartupProject SMS.API
PM> Update-Database -Project SMS.Infrastructure -StartupProject SMS.API

Run the following command in Package Manager Console so that it will automatically create database and its tables
PM> Add-Migration InitialCreate
Build started...
Build succeeded.
To undo this action, use Remove-Migration.
PM> Update-Database
Build started...
Build succeeded.

 

Option B: Using .NET CLI
dotnet ef migrations add InitialCreate -p SMS.Infrastructure -s SMS.API
dotnet ef database update -p SMS.Infrastructure -s SMS.API

echo Migration-DB Start...
dotnet ef migrations add InitialCreate -p SMS.Infrastructure -s SMS.API
dotnet ef database update -p SMS.Infrastructure -s SMS.API
echo Migration-DB End...
These commands will automatically create the SMS_DB database and all related tables.
________________________________________
▶️ 5. Run the API
•	In Visual Studio: Press F5 or click on the Run button.
•	In CLI: Navigate to SMS.API project and run:
cd SMS.API
dotnet run
Once the application runs, it should open Swagger UI at:
http://localhost:5071/swagger/index.html

________________________________________
📌 6. Verify Endpoints in Swagger
Test the following APIs in Swagger:
Students
•	GET /api/Students
•	POST /api/Students
•	PUT /api/Students/{id}
•	GET /api/Students/{id}/Nationality
•	PUT /api/Students/{id}/Nationality/{id}
Family Members
•	GET /api/Students/{id}/FamilyMembers/
•	POST /api/Students/{id}/FamilyMembers/
•	PUT /api/FamilyMembers/{id}
•	DELETE /api/FamilyMembers/{id}
•	GET /api/FamilyMembers/{id}/Nationality/{id}
•	PUT /api/FamilyMembers/{id}/Nationality/{id}
Nationalities
•	GET /api/Nationalities

________________________________________
🧪 7. Run Unit Tests (Optional)
In Visual Studio:
•	Open Test Explorer → Run All Tests.
In CLI:
cd SMS.Tests
dotnet test
________________________________________


 
 

