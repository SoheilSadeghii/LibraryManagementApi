# 📚 Library Management API

A RESTful Web API built with ASP.NET Core as a practice project to strengthen backend development skills.

## 🚀 Features

- JWT Authentication
- User Registration & Login
- Role-Based Authorization (Admin/User)
- CRUD for Books
- CRUD for Authors
- CRUD for Categories
- Search
- Filtering
- Sorting
- Pagination
- Request Validation
- Global Exception Handling
- Swagger Documentation
- Repository Pattern
- Dependency Injection
- In-Memory Fake Repository (No Database)

---

## 🛠 Technologies

- ASP.NET Core Web API
- C#
- JWT Authentication
- Swagger / OpenAPI
- Dependency Injection

---

## 📁 Project Structure

```
Controllers/
DTOs/
Extensions/
Helpers/
Middleware/
Models/
Repositories/
Services/
Validators/
```

---

## 🔑 Authentication

The API uses JWT Bearer Authentication.

Two roles are available:

- Admin
- User

Only Admin users can create, update, or delete resources.

---

## 📖 API Endpoints

### Authentication

- POST /api/auth/register
- POST /api/auth/login

### Books

- GET /api/books
- GET /api/books/{id}
- POST /api/books
- PUT /api/books/{id}
- DELETE /api/books/{id}

### Authors

- GET /api/authors
- POST /api/authors
- PUT /api/authors/{id}
- DELETE /api/authors/{id}

### Categories

- GET /api/categories
- POST /api/categories
- PUT /api/categories/{id}
- DELETE /api/categories/{id}

---

## 🔍 Query Examples

Search

```
GET /api/books?search=clean
```

Filtering

```
GET /api/books?categoryId=2
```

Sorting

```
GET /api/books?sort=price
```

Descending

```
GET /api/books?sort=-price
```

Pagination

```
GET /api/books?page=1&pageSize=10
```

---

## 🎯 Learning Goals

This project was built to practice:

- REST API design
- Repository Pattern
- Authentication & Authorization
- API Validation
- Clean Project Structure
- Dependency Injection
- Middleware
- Pagination & Filtering

---

## 📄 License

This project is for educational purposes.
