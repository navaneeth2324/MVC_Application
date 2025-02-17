# MVC_Application# MVC Application

This is an ASP.NET Core MVC application that manages items, including their categories, serial numbers, and associated clients.

## Features

- **Item Management**: Create, edit, and delete items.
- **Category Management**: Assign categories to items.
- **Serial Number Management**: Assign serial numbers to items.
- **Client Management**: Associate clients with items.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

## Getting Started

### Prerequisites

- .NET 8 SDK
- SQL Server

### Setup

1. Clone the repository:

```
git clone https://github.com/your-repo/mvc-application.git
cd mvc-application
```
2. Update the connection string in `appsettings.json`:
```
"ConnectionStrings": {
    "DefaultConnection": "YourConnectionStringHere"
}
```

3. Apply migrations and update the database:
```
Add-Migration
Update-Database
``` 
4. Run the application:
```
dotnet run
```

## Project Structure

- **Controllers**: Contains the controllers for handling HTTP requests.
- **Models**: Contains the data models.
- **Views**: Contains the Razor views for rendering UI.

## Code Overview

### Program.cs

Configures the application, sets up services, and defines the HTTP request pipeline.

### ItemsController.cs

Handles CRUD operations for items, including creating, editing, and deleting items.

### Item.cs

Defines the `Item` model with properties for `Id`, `Name`, `Price`, `SerialNumber`, `Category`, and associated `ItemClients`.

## License

This project is licensed under the MIT License.
