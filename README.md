# Job Portal Admin Panel

## Overview

This is the admin panel for handling job postings, employer management, and related administrative tasks.

## Features

- Manage Job Posts
- Handle Employer Registrations
- Assign Job Categories and Types
- Role-based Access Control (Admin & User)

## Installation & Setup

1. Clone the repository:

    ```bash
    git clone https://github.com/your-repo/job-portal-admin.git
    cd job-portal-admin
    ```
2. Set up the database:
    - Update the `appsettings.json` with your SQL Server connection string.
3. Apply migrations:
    ```bash
    dotnet ef database update
    ```
4. Run the application:
    ```bash
    dotnet run
    ```
## Seeding Roles & Admin User

The system automatically seeds default roles and an admin user during the first run.

### Default Admin Credentials:

- **Email:** admin@example.com
- **Password:** Admin@123

## Usage

- Access the panel at `https://localhost:5001`
- Login with admin credentials to manage jobs and employers.

## Contributing

Feel free to fork and contribute by submitting a pull request.

