# Asynchronous Commenting System

-This project is a full-stack web application that allows users to register, login, and post comments asynchronously. Built with React for the frontend and .NET 6 for the backend, it features JWT authentication to secure endpoints and Entity Framework Core for data management.

## Features

- User registration and login using JWT authentication.
- Posting and fetching comments asynchronously.
- Secure endpoints with user-specific access.
- Real-time update of comments without needing to reload the page.

## Technologies

- **Frontend:** React
- **Backend:** .NET 6, ASP.NET Core
- **Database:** SQL Server
- **Authentication:** JWT

## Getting Started

### Prerequisites

- .NET 6 SDK
- Node.js and npm
- SQL Server

### Setting Up the Database

1. Create a new SQL Server database.
2. Update the connection string in `appsettings.json` under the `DefaultConnection` key with your database details.
