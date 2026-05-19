# Review Service

Microservice for handling course reviews in the LMS project.

## Features

- Get all reviews
- Get review by id
- Create review
- Update review
- Delete review
- Validation with DataAnnotations
- Swagger documentation
- SQL Server database
- Entity Framework Core
- Docker support

## Technologies

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- Docker

## Endpoints

### GET ALL REVIEWS

```http
GET /api/Reviews
```

### GET REVIEW BY ID

```http
GET /api/Reviews/{id}
```

### CREATE REVIEW

```http
POST /api/Reviews
```

### UPDATE REVIEW

```http
PUT /api/Reviews/{id}
```

### DELETE REVIEW

```http
DELETE /api/Reviews/{id}
```

## Example JSON

```json
{
  "userName": "Vita",
  "comment": "Very good course",
  "rating": 5,
  "courseId": 1
}
```

## Validation

The API validates:

- Required fields
- Rating must be between 1 and 5
- Comment minimum length
- Valid course id

## Run Project

```bash
dotnet run
```

## Run Migrations

```bash
dotnet ef database update
```

## Docker

Build Docker image:

```bash
docker build -t reviewservice .
```

Run Docker container:

```bash
docker run -p 8080:8080 reviewservice
```

## Azure Deployment

This service is prepared for deployment to Azure App Service.

### Deployment Steps

1. Create Azure App Service
2. Select Runtime Stack: .NET 10
3. Connect GitHub repository
4. Configure connection string
5. Deploy application
6. Test Swagger endpoint

### Azure Connection String

Add connection string in:

```text
Azure App Service → Settings → Environment variables → Connection strings
```

Name:

```text
DefaultConnection
```

Type:

```text
SQLAzure
```

### Swagger URL After Deployment

```text
https://your-review-service.azurewebsites.net/swagger
```

## Architecture

The service uses:

- Controller layer
- Service layer
- DTO pattern
- Entity Framework Core
- SQL Server database
- Dependency Injection

## Project Structure

```text
ReviewService.Api
│
├── Controllers
├── Data
├── Dtos
├── Models
├── Services
├── Migrations
├── Dockerfile
└── README.md
```

## Status

```text
CRUD API completed
Validation completed
Docker support added
Swagger configured
Database connected
Azure deployment prepared
```