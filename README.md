# NexusERP

A modern **ERP Backend System** built with **ASP.NET Core Web API** following **Clean Architecture** and **CQRS** principles.

The goal of this project is to simulate a real-world ERP system while applying software engineering best practices, scalable architecture, and enterprise-level design patterns.

---

## 🚀 Tech Stack

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- MediatR (CQRS)
- FluentValidation
- JWT Authentication
- Clean Architecture
- Dependency Injection
- Global Exception Handling
- RESTful APIs
- LINQ

---

## 🏗️ Architecture

The project follows **Clean Architecture** and is divided into four layers:

```
├── Domain
├── Application
├── Infrastructure
└── WebApi
```

### Responsibilities

- **Domain**
  - Entities
  - Enums
  - Interfaces
  - Domain Rules

- **Application**
  - CQRS (Commands & Queries)
  - Handlers
  - DTOs
  - Validators
  - Behaviors
  - Custom Responses
  - Business Logic

- **Infrastructure**
  - Entity Framework Core
  - Database Configurations
  - Services
  - Authentication
  - External Integrations

- **WebApi**
  - Controllers
  - Middleware
  - Dependency Injection
  - API Configuration

---

# ✨ Features

## Authentication

- JWT Authentication
- ASP.NET Identity
- Role-based Authorization

---

## Categories

- Create Category
- Update Category
- Soft Delete Category
- Get Category By Id
- Get All Categories
- Search
- Pagination

---

## Products

- Create Product
- Update Product
- Soft Delete Product
- Get Product By Id
- Get All Products
- Search
- Price Filtering
- Pagination

---

## Customers

- Create Customer
- Update Customer
- Soft Delete Customer
- Get Customer By Id
- Get All Customers
- Search
- Pagination
- Automatic Customer Code Generation

---

## Suppliers

- Create Supplier
- Update Supplier
- Soft Delete Supplier
- Get Supplier By Id
- Get All Suppliers
- Search
- Pagination
- Automatic Supplier Code Generation

---

# 🔥 Current Highlights

- Clean Architecture
- CQRS with MediatR
- FluentValidation Pipeline
- Global Exception Middleware
- Generic Pagination Extension
- Soft Delete with Global Query Filters
- SQL Server Sequences
- Automatic Code Generator Service
- Entity Configurations using Fluent API

---

# 📂 Project Structure

```
src
│
├── NexusERP.Domain
├── NexusERP.Application
├── NexusERP.Infrastructure
└── NexusERP.WebApi
```

---

# 🛣️ Roadmap

The following features are planned for future releases:

## Inventory

- Stock Management
- Stock Transactions
- Warehouse Support
- Stock Movement History

---

## Purchase Module

- Purchase Orders
- Purchase Details
- Receive Products
- Increase Stock Automatically

---

## Sales Module

- Sales Orders
- Sales Details
- Invoice Generation
- Reduce Stock Automatically

---

## Dashboard

- Sales Statistics
- Revenue Reports
- Top Selling Products
- Low Stock Alerts

---

## Financial Features

- Expenses
- Payments
- Customer Balances
- Supplier Balances

---

## Notifications

- Low Stock Notifications
- Email Notifications

---

## API Improvements

- Refresh Tokens
- API Versioning
- Response Caching
- Rate Limiting
- Health Checks

---

## Integrations

- Cloud Image Storage
- Email Service
- SMS Service
- Payment Gateway

---

## Performance

- Redis Caching
- Background Jobs (Hangfire)
- Logging (Serilog)
- Monitoring

---

## Documentation

- Swagger Improvements
- API Documentation
- Postman Collection

---

## Testing

- Unit Testing
- Integration Testing

---

# 📌 Project Goals

This project is being developed to:

- Practice enterprise-level backend development.
- Apply Clean Architecture principles.
- Build scalable and maintainable APIs.
- Learn real ERP business workflows.
- Prepare for real-world .NET Backend positions.

---

# 🤝 Contributing

Contributions, suggestions, and feedback are always welcome.

If you find any issues or have ideas for improvements, feel free to open an issue or submit a pull request.

---

# 👨‍💻 Author

**Ahmed Raafat**

Backend .NET Developer

GitHub: https://github.com/ahmadraafat22

LinkedIn: www.linkedin.com/in/ahmed-raafat-8a1a2a286

---

## ⭐ Support

If you found this project useful, don't forget to **give it a Star ⭐**.
