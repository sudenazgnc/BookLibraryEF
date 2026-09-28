# BookLibraryEF

A simple library management web application developed with **ASP.NET Core MVC**, **Entity Framework Core**, and **SQL Server**. The project demonstrates MVC architecture, relational data modeling, CRUD-style operations, book rentals, database migrations, and Docker-based development.

## Features

- List books with author information
- Add new books
- Add users
- Rent books to users
- Prevent the same user from renting the same book more than once
- Entity Framework Core Code First migrations
- SQL Server database integration
- Docker and Docker Compose configuration

## Technologies

- C#
- .NET 8
- ASP.NET Core MVC
- Entity Framework Core 8
- SQL Server
- Razor Views
- Docker / Docker Compose

## Project Structure

```text
BookLibraryEF/
├── Controllers/
├── Data/
├── Migrations/
├── Models/
├── Views/
├── wwwroot/
├── Dockerfile
├── compose.yml
├── Program.cs
└── BookLibraryEF.csproj
```

## Run with Docker

### 1. Clone the repository

```bash
git clone <YOUR-GITHUB-REPOSITORY-URL>
cd BookLibraryEF
```

### 2. Create the environment file

Copy `.env.example` to `.env` and set a strong SQL Server SA password.

```bash
cp .env.example .env
```

On Windows PowerShell, you can use:

```powershell
Copy-Item .env.example .env
```

Then edit `.env` if needed.

> `.env` is ignored by Git and should not be committed.

### 3. Start the application

```bash
docker compose up --build
```

Open:

```text
http://localhost:5000
```

The web application connects to the SQL Server container using the connection string supplied through Docker Compose.

### 4. Stop the application

```bash
docker compose down
```

## Database

The project uses Entity Framework Core migrations. The initial migration is included in the `Migrations/` directory.

When the application is running outside the Development environment, the application applies pending migrations during startup.

## Notes

This is a university/course project created to practice ASP.NET Core MVC, Entity Framework Core, relational database design, and containerized development.

The repository intentionally excludes Visual Studio caches, build artifacts, local environment files, and user-specific project settings.
