# 🚀 Enterprise Backend API - .NET 8

Professional REST API developed with .NET 8 following enterprise backend practices, scalable architecture principles and modern software engineering standards.

This project was built as a reference implementation of a professional backend architecture using ASP.NET Core, Entity Framework Core, JWT Authentication and SQL Server.

---

# 📌 Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- AutoMapper
- Swagger / OpenAPI
- Repository Pattern
- Dependency Injection
- RESTful API Design
- Async/Await
- Response Caching
- Clean Architecture Principles

---

# 🏗️ Architecture

The project follows a layered architecture focused on separation of responsibilities, maintainability and scalability.

```text
Controllers
   ↓
Services
   ↓
Repositories
   ↓
Entity Framework Core
   ↓
SQL Server
```

Main architectural concepts applied:

- SOLID Principles
- Repository Pattern
- DTO Pattern
- Dependency Injection
- Separation of Concerns
- Clean Code Practices
- Async Programming
- Scalable API Design

---

# 📂 Project Structure

```text
ApiEcommerce
│
├── Controllers
├── Services
├── Repository
├── Data
├── Models
├── DTOs
├── Mapping
├── Constants
├── Migrations
└── Infrastructure
```

---

# 🔐 Authentication

The API uses JWT Bearer Authentication for secure access to protected endpoints.

Features:

- User authentication
- Role-based authorization
- Secure password hashing
- Token validation
- Identity integration

---

# 🗄️ Database

SQL Server database managed with Entity Framework Core migrations.

Features:

- Entity relationships
- UUID/GUID primary keys
- Database seeding
- Optimized queries
- Pagination support
- Response caching

---

# ⚡ Features

- CRUD operations
- JWT Authentication
- Product management
- Category management
- Pagination
- Filtering
- Swagger documentation
- AutoMapper integration
- Async repository pattern
- Clean architecture structure
- Initial data seeding

---

# 📦 Initial Seeding

The application automatically seeds:

- Roles
- Users
- Categories
- Products

during application startup.

---

# 🔄 Pagination Example

```http
GET /api/products/page?pageNumber=1&pageSize=10
```

---

# 🔧 Run Project

## Clone repository

```bash
git clone https://github.com/your-user/enterprise-backend-dotnet.git
```

## Navigate to project

```bash
cd enterprise-backend-dotnet
```

## Apply migrations

```bash
dotnet ef database update
```

## Run project

```bash
dotnet run
```

---

# 📘 Swagger

Swagger UI available at:

```text
https://localhost:{port}/swagger
```

---

# 🧠 Engineering Practices

This project focuses on demonstrating:

- Professional backend structure
- Enterprise API design
- Maintainable codebase
- Scalable architecture
- Clean separation of responsibilities
- Modern .NET development practices

---

# 👨‍💻 Author

Developed as part of a professional backend engineering portfolio focused on enterprise-grade .NET applications.
