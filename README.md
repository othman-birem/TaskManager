# Task Management System

An intermediate-level full-stack project built with ASP.NET Core and Angular. This project provides a robust and user-friendly Task Management System with features such as user authentication, task categorization, real-time updates, and email notifications. This README includes an overview, dependencies, and instructions on setting up and running the project.

## Features

- **User Authentication & Authorization**
  - ASP.NET Identity or JWT-based authentication
  - Role-based access control (Admin, Manager, Employee)

- **Task Management**
  - CRUD operations for tasks (Create, Read, Update, Delete)
  - Assign tasks to different users
  - Task categories (e.g., Development, Marketing) and statuses (Pending, In Progress, Completed)

- **Real-Time Updates**
  - Real-time task updates using SignalR
  - Notifications on task assignments and status changes

- **Commenting System**
  - Add comments to tasks
  - Real-time comment updates

- **Dashboard and Analytics**
  - Overview dashboard with task statuses and progress tracking
  - Task distribution charts across categories and users

- **Responsive UI**
  - Mobile-friendly design using Angular Material or Bootstrap

- **Email Notifications**
  - Send email alerts for task assignments and completions using SendGrid

## Dependencies

- **Backend**: ASP.NET Core, Entity Framework Core, SignalR, SendGrid
- **Frontend**: Angular, Angular Material or Bootstrap
- **Database**: SQL Server
- **Other**: Docker (for containerization)

## Installation Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/TaskManager.git
   cd TaskManager
