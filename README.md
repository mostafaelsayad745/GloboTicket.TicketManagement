# GloboTicket Ticket Management System

The GloboTicket Ticket Management System is a cutting-edge, comprehensive solution designed to streamline the management of events, ticket sales, and user authentication. Utilizing Clean Architecture principles, also known as Onion Architecture, this project is structured to ensure high maintainability, scalability, and adaptability to evolving technologies and requirements.

## Project Overview

This system is part of the GloboTicket suite, aiming to provide an intuitive and efficient platform for event organizers to manage events and for customers to purchase tickets. By leveraging the latest technologies and architectural patterns, GloboTicket ensures a seamless, secure, and scalable solution for ticket management.

## Key Features

- **Event Management**: Comprehensive management of event details, including scheduling, location setting, and categorization.
- **Ticket Sales**: A robust system for handling ticket inventories, orders, and sales tracking.
- **Category Management**: Enhanced organization of events into categories for improved discoverability and management.
- **User Authentication and Authorization**: Secure and scalable user management with ASP.NET Core Identity, supporting features like sign-up, login, and role-based access control.
- **API Documentation**: Detailed API documentation generated with Swagger, facilitating easy integration and collaboration.

## Architecture

Adhering to Clean Architecture principles, the GloboTicket Ticket Management System is organized into the following layers:

- **Domain Layer**: The heart of the application, containing entities, interfaces, and domain logic.
- **Application Layer**: Encapsulates application-specific logic, command/query handling, and DTOs.
- **Infrastructure Layer**: Comprises persistence logic, identity management, and external service integrations.
- **Presentation Layer**: Hosts the API endpoints, providing the interface through which users and services interact with the application.

## Technologies Used

- **.NET 8**: The latest iteration of the .NET framework, offering enhanced performance, cross-platform support, and a rich set of features for building modern web applications.
- **Entity Framework Core**: A powerful ORM for .NET, used for data access and manipulation with strong typing, LINQ queries, and change tracking.
- **ASP.NET Core Identity**: A comprehensive system for managing users, passwords, roles, and authentication.
- **MediatR**: Implements the Mediator pattern to reduce dependencies between objects, simplifying request handling and processing.
- **AutoMapper**: Automates the mapping between objects, reducing boilerplate code for transforming data models.
- **Swagger (Swashbuckle)**: Generates interactive API documentation, allowing developers to test and explore API endpoints easily.

## Getting Started

### Prerequisites

- .NET 8 SDK installed on your machine.
- SQL Server or a compatible database for storing application data.

### Setup

1. **Clone the Repository**: `git clone https://github.com/mostafaelsayad745/GloboTicket.TicketManagement.git`
2. **Database Configuration**: Update the `appsettings.json` files in the API and Identity projects with your database connection strings.
3. **Apply Migrations**: Use the `dotnet ef database update` command in the Persistence and Identity projects to apply the database schema.
4. **Run the Application**: Execute `dotnet run` in the API project directory to start the application.

## Contributing

Contributions are highly appreciated! If you have suggestions for improving the GloboTicket Ticket Management System, please feel free to fork the repository, make changes, and submit a pull request. You can also open issues for bugs or feature requests.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
