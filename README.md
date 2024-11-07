# TaskManager

TaskManager is an intermediate-level full-stack task management system built with ASP.NET Core for the backend and Angular for the frontend. It provides comprehensive features for task creation, assignment, real-time collaboration, and analytics, making it easier for teams and individuals to stay organized and efficient.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Running the Application](#running-the-application)
- [Environment Variables](#environment-variables)
- [Database Configuration](#database-configuration)
- [Contributing](#contributing)
- [License](#license)

## Features

- **User Authentication & Authorization**: Secure access using ASP.NET Identity with role-based permissions for Admin, Manager, and Employee.
- **Task CRUD Operations**: Create, Read, Update, and Delete tasks with the ability to assign tasks to different users.
- **Task Categories and Statuses**: Organize tasks by categories (e.g., Development, Marketing) and track status (Pending, In Progress, Completed).
- **Real-Time Updates**: Get notified of task updates and comments in real-time with SignalR.
- **Commenting System**: Collaborate on tasks by adding comments, with real-time updates.
- **Dashboard and Analytics**: Visualize task distribution and progress using charts.
- **Responsive UI**: Frontend built with Angular Material for a consistent experience across all devices.

## Technologies Used

- **Frontend**: Angular, Angular Material, TypeScript
- **Backend**: ASP.NET Core, Entity Framework Core, SignalR
- **Database**: SQL Server (using Docker for local setup)
- **Other**: JWT for authentication, Chart.js for analytics, SendGrid for email notifications

## Prerequisites

To run this project locally, ensure you have the following installed:

- **.NET SDK** (6.0)
- **Node.js** (>=14.x) and Angular CLI
- **Docker Desktop** for running SQL Server in a container
- **SQL Server** (if not using Docker)

## Getting Started

### 1. Clone the Repository

  ```bash
  git clone https://github.com/your-username/TaskManager.git
  cd TaskManager
  ```
### 2. Install Dependencies
**Backend (ASP.NET Core)**
Navigate to the backend directory and restore .NET packages:
```bash
cd TaskManager.Api
dotnet restore
```
**Frontend (Angular)**
Navigate to the frontend directory and install Node dependencies:
```bash
cd TaskManager.Client
npm install
```
### 3. Configure the Database
The project uses SQL Server as its database. You can set up SQL Server using Docker or install it locally.

To start a SQL Server container using Docker, run:
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourPassword!" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```
Update the connection string in `appsettings.json` (found in `TaskManager.Api`) to match your database configuration.

### 4. Run Database Migrations
Navigate to the backend folder and run migrations to set up the database:

```bash
dotnet ef database update
```
### 5. Configure Environment Variables
To enable email notifications, create a `UserSecrets.json` or use environment variables for settings like SendGrid API key, database connection string, etc.

### 6. Run the Application
**Backend (ASP.NET Core)**
Start the ASP.NET Core API:

```bash
cd TaskManager.Api
dotnet run
```
**Frontend (Angular)**
Start the Angular frontend application:

```bash
cd TaskManager.Client
ng serve
```
The backend will be available at `http://localhost:5000`, and the frontend at `http://localhost:4200`.

## Project Structure
```bash
TaskManager/
├── TaskManager.Api/            # ASP.NET Core backend
│   ├── Controllers/             # API controllers
│   ├── Models/                  # Data models and entities
│   ├── Services/                # Business logic services
│   └── appsettings.json         # Application settings
├── TaskManager.Client/          # Angular frontend
│   ├── src/
│   ├── app/
│   └── angular.json             # Angular configuration
└── README.md                    # Project readme
```
## Running the Application
**Run Backend:** Open a terminal in the `TaskManager.Api` folder and run dotnet run.
**Run Frontend:** Open another terminal in the `TaskManager.Client` folder and run `ng serve`.
Visit `http://localhost:4200` to view the application in your browser.
## Environment Variables
Set up the following environment variables in a `UserSecrets.json` file or your environment:

DatabaseConnection: Connection string for SQL Server.
SendGridApiKey: API key for SendGrid (for email notifications).
Example:

```json
Copy code
{
  "DatabaseConnection": "Server=localhost;Database=TaskManager;User Id=sa;Password=YourPassword!",
  "SendGridApiKey": "your-sendgrid-api-key"
}
```
## Database Configuration
The project uses Entity Framework Core with SQL Server. Make sure your connection string is correct in `appsettings.json`:

```json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=TaskManager;User Id=sa;Password=YourPassword!"
}
```
## Contributing
Contributions are welcome! Please fork this repository, create a new branch, and submit a pull request with your changes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.
