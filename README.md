# 📝 TODO App - ASP.NET Core Web API

A modern, full-featured TODO application built with ASP.NET Core Web API (.NET 8), Entity Framework Core, and following clean architecture principles. This project demonstrates best practices for building RESTful APIs with proper separation of concerns, comprehensive CRUD operations, and robust data validation.

## 🚀 Features

- ✅ **Complete CRUD Operations** - Create, Read, Update, Delete todo items
- 🔄 **Toggle Completion Status** - Quick completion status toggle endpoint
- 📊 **Entity Framework Core** - Code-first approach with SQL Server
- 🏗️ **Clean Architecture** - Proper separation with Models, DTOs, Services, and Controllers
- ✨ **Data Validation** - Comprehensive input validation with data annotations
- 📖 **Swagger Documentation** - Interactive API documentation and testing
- 🔒 **CORS Support** - Cross-origin resource sharing enabled
- ⚡ **Async/Await** - Asynchronous operations for optimal performance
- 🎯 **RESTful Design** - Following REST principles and HTTP standards

## 🏛️ Architecture

```
TodoApp/
├── Controllers/           # API Controllers
│   └── TodoController.cs
├── Services/             # Business Logic Layer
│   ├── ITodoService.cs
│   └── TodoService.cs
├── Models/               # Entity Models
│   └── TodoItem.cs
├── DTOs/                 # Data Transfer Objects
│   ├── TodoItemDto.cs
│   ├── CreateTodoItemDto.cs
│   └── UpdateTodoItemDto.cs
├── Data/                 # Data Access Layer
│   └── TodoDbContext.cs
├── Migrations/           # EF Core Migrations
└── Program.cs           # Application Entry Point
```

## 🛠️ Technology Stack

- **Framework**: ASP.NET Core Web API (.NET 8)
- **ORM**: Entity Framework Core
- **Database**: SQL Server (LocalDB for development)
- **Documentation**: Swagger/OpenAPI
- **Architecture**: Clean Architecture with Service Layer
- **Validation**: Data Annotations

## 📋 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/todo` | Get all todo items |
| GET | `/api/todo/{id}` | Get specific todo by ID |
| POST | `/api/todo` | Create new todo item |
| PUT | `/api/todo/{id}` | Update existing todo |
| DELETE | `/api/todo/{id}` | Delete todo item |
| PATCH | `/api/todo/{id}/toggle` | Toggle completion status |

## 🚦 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or SQL Server Express/LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Fahim2280/To-Do-Api.git
   cd todo-app-webapi
   ```

2. **Install dependencies**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   Edit `appsettings.json` and update the connection string:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TodoAppDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Install Entity Framework Tools** (if not already installed)
   ```bash
   dotnet tool install --global dotnet-ef
   ```

5. **Create and run migrations**
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

6. **Run the application**
   ```bash
   dotnet run
   ```

7. **Access the API**
   - API: `https://localhost:7xxx` (port may vary)
   - Swagger UI: `https://localhost:7xxx/swagger`

## 📝 Usage Examples

### Create a new todo
```bash
curl -X POST "https://localhost:7xxx/api/todo" \
-H "Content-Type: application/json" \
-d '{
  "title": "Learn ASP.NET Core",
  "description": "Complete the Web API tutorial"
}'
```

### Get all todos
```bash
curl -X GET "https://localhost:7xxx/api/todo"
```

### Update a todo
```bash
curl -X PUT "https://localhost:7xxx/api/todo/1" \
-H "Content-Type: application/json" \
-d '{
  "title": "Learn ASP.NET Core - Updated",
  "description": "Complete the advanced Web API tutorial",
  "isCompleted": true
}'
```

### Toggle completion status
```bash
curl -X PATCH "https://localhost:7xxx/api/todo/1/toggle"
```

## 🗂️ Data Model

### TodoItem Entity
```csharp
public class TodoItem
{
    public int Id { get; set; }
    public string Title { get; set; }        // Required, max 200 chars
    public string? Description { get; set; }  // Optional, max 1000 chars
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

## 🧪 Testing

The API includes comprehensive Swagger documentation for testing all endpoints. After running the application, navigate to `/swagger` to access the interactive API documentation.

### Manual Testing with Swagger
1. Start the application
2. Open `https://localhost:7xxx/swagger`
3. Use the interactive interface to test all endpoints

## 📦 NuGet Packages

The following packages are required:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
```

## 🔧 Configuration

### Database Configuration
Update the connection string in `appsettings.json` to match your SQL Server setup:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=TodoAppDb;Trusted_Connection=true;"
  }
}
```

### CORS Configuration
CORS is configured to allow all origins for development. Update the CORS policy in `Program.cs` for production use.

## 📚 Learning Resources

This project demonstrates:

- ✅ **Clean Architecture** - Separation of concerns with proper layering
- ✅ **Repository Pattern** - Abstracted data access through service layer
- ✅ **DTO Pattern** - Data transfer objects for API contracts
- ✅ **Code-First Migrations** - Database schema management
- ✅ **Dependency Injection** - Proper IoC container usage
- ✅ **Async Programming** - Non-blocking operations
- ✅ **API Documentation** - Swagger/OpenAPI integration

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Your Name**
- GitHub: [Fahim2280](https://github.com/Fahim2280)
- LinkedIn: [Md Fahim Alam](https://www.linkedin.com/in/mdfahimalam/)

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Entity Framework Core for seamless data access
- Swagger for API documentation
- The .NET community for continuous inspiration

---

