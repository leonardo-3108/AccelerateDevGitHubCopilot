# Library App

## Description

Library App is a sample application designed to manage library operations such as managing patrons and loans. It is built using .NET 8.0 and follows a modular architecture with separate projects for core application logic, console interface, and infrastructure.

## Project Structure

- `AccelerateDevGitHubCopilot.sln`
- `README.md`
- `src/`
  - `Library.ApplicationCore/`
    - `Entities/`
    - `Enums/`
    - `Interfaces/`
    - `Library.ApplicationCore.csproj`
    - `Services/`
  - `Library.Console/`
    - `appSettings.json`
    - `CommonActions.cs`
    - `ConsoleApp.cs`
    - `ConsoleState.cs`
    - `Json/`
    - `Library.Console.csproj`
    - `Program.cs`
  - `Library.Infrastructure/`
    - `Data/`
    - `Library.Infrastructure.csproj`
- `tests/`
  - `UnitTests/`
    - `ApplicationCore/`

## Key Classes and Interfaces

- **Library.ApplicationCore**
  - `Entities/`
    - `Patron`: Represents a library patron.
    - `Loan`: Represents a loan of a library item.
  - `Enums/`
    - `LoanStatus`: Enum for the status of a loan.
  - `Interfaces/`
    - `IPatronRepository`: Interface for patron repository.
    - `ILoanRepository`: Interface for loan repository.
  - `Services/`
    - `PatronService`: Service for managing patrons.
    - `LoanService`: Service for managing loans.

- **Library.Console**
  - `ConsoleApp`: Main class for the console application.
  - `CommonActions`: Contains common actions for the console application.
  - `ConsoleState`: Manages the state of the console application.

- **Library.Infrastructure**
  - `Data/`
    - `JsonData`: Utility class for loading and saving data to JSON files.
    - `JsonPatronRepository`: Implementation of `IPatronRepository` using JSON.
    - `JsonLoanRepository`: Implementation of `ILoanRepository` using JSON.

## Usage

1. Clone the repository:

   ```sh
   git clone https://github.com/yourusername/library-app.git
   ```

2. Navigate to the project directory:

   ```sh
   cd library-app
   ```

3. Build the solution:

   ```sh
   dotnet build
   ```

4. Run the console application:

   ```sh
   dotnet run --project src/Library.Console/Library.Console.csproj
   ```

## License

This project is licensed under the MIT License. See the LICENSE file for details. ```