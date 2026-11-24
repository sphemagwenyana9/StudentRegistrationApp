# StudentRegistrationApp

A web application to manage student registrations for courses. Built with ASP.NET Core MVC, Entity Framework Core, and SQL Server.

## Features
- Manage Students — Add, Edit, View, Delete students
- Manage Courses — Add, Edit, View, Delete courses
- Manage Registrations — Register a student for a course
- View all registrations with student and course details

## Tech Stack
- ASP.NET Core MVC
- Entity Framework Core (Database First)
- SQL Server — Database: `StudentRegistrationDB`
- C#, Razor Views, Bootstrap

## How to Run
1. Clone the repo
2. Open `StudentRegistrationApp.sln` in Visual Studio
3. Update the connection string in `appsettings.json` if needed:
   `Server=.;Database=StudentRegistrationDB;Trusted_Connection=True;TrustServerCertificate=True;`
4. Run the project (F5)

## Database
Database Name: `StudentRegistrationDB`
Tables: `Students`, `Courses`, `Registrations`
