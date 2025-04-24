# ProductApp
# About
This is a Product Management Portal built using ASP.NET Core. It includes features for managing products, such as creating, viewing, updating, and deleting products. The project is structured using layered architecture and follows best practices for testing and logging.

## Prerequisites

Before you run the project, ensure you have the following installed:

- **.NET 9 SDK**: [Download .NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Visual Studio 2022** or **Visual Studio Code** with the **C# extension**.
- **SQL Server** or any other supported database for the application (configured in `appsettings.json`).

## Getting Started

Follow the steps below to set up and run the project locally.

### 1. Clone the Repository

Clone the repository to your local machine using Git:

```bash
git clone https://github.com/your-username/ProductManagementPortal.git
cd ProductManagementPortal
```

### 2. Restore Dependencies
Restore the project dependencies using the following command:

```bash
dotnet restore
```

### 3. Build the Project
Build the project to ensure that everything is set up correctly:

```bash
dotnet build
```
### 4. Set up Database (Using SQL Script)
Create Database
```bash
CREATE DATABASE ProductAppDb
```
Create Schema
```bash
CREATE SCHEMA ProductApp;
```
Create Table
```bash
CREATE TABLE ProductApp.Products(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Price DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(50),
    Category NVARCHAR(100),
    Quantity INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedDate DATETIME NULL
);
```
Update the connection string in your appsettings.json file to match your SQL Server configuration:
```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=DbName;User Id=UserName;Password=xxxxx;TrustServerCertificate=True;"
}
```

### 5. Run the Application
Run the application using the following command:
```bash
dotnet run
```

This will start the application on http://localhost:xxxx by default. You can access the Product Management Portal through your web browser.

## Features
Product Listing: View all products in a tabular format.

Create Product: Add new products with fields such as Name, Description, Price, Status, Category, and Quantity.

Edit Product: Update the product details.

Delete Product: Remove products from the list.

CRUD Operations: Full create, read, update, and delete functionalities.

## Testing
Unit tests are written using xUnit and Moq for mocking dependencies.

To run the tests, use the following command:

```bash
dotnet test
```
Ensure the test project is set up to reference the main project, and that all necessary dependencies are included.

## Project Structure
- src/: Contains the main application, including:
- ProductApp.Web: The web application layer.
- ProductApp.Application: The application logic layer, including services and interfaces.
- ProductApp.Domain: The domain model, including product entities.
- ProductApp.Infrastructure: Contains database-related services (e.g., Entity Framework implementations).
- ProductApp.Utilites: Hold shared functionality and helper classes that are reusable across multiple layers of application.

- tests/: Contains the test project which verifies the application functionality.

## Acknowledgements
- ASP.NET Core 9 for web development.
- xUnit and Moq for unit testing and mocking dependencies.
- Bootstrap for UI design.

## Project Structure
```
ProductApp/
│
├── ProductApp.Web/                # Presentation Layer (UI/Controllers)
│   ├── Controllers/
│   │   └── ProductsController.cs
│   ├── Views/
│   │   └── Products/
│   │       ├── Index.cshtml
│   │       ├── Create.cshtml
│   │       ├── Edit.cshtml
│   │       └── Delete.cshtml
│   └── wwwroot/
│       └── css/
│       └── js/
│
├── ProductApp.Application/         # Application Layer
│   ├── Interfaces/
│   │   └── IProductService.cs
│   └── Services/
│       └── ProductService.cs
│
├── ProductApp.Domain/              # Domain Layer
│   └── Product.cs
│
├── ProductApp.Infrastructure/      # Data Access Layer
│   ├── Data/
│   │   ├── DapperContext.cs
│   │   ├── IProductRepository.cs
│   │   └── ProductRepository.cs
│   └── Configuration/
│       └── DatabaseConfig.cs
│ 
│ ── ProductApp.Utilities/              # Shared Layer
│   └── BaseEntity.cs
│
└── ProductApp.sln                  # Solution file
```
