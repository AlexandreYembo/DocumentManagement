# Document Management

### Requirements

* Git (for cloning repository)
* ASP.NET Core 2.1 SDK
* Microsoft Visual Studio 2017
* Microsoft SQL Server 2014 or higher

### Features

* Web API using ASP.NET Core 2.1
* Entity Framework Core
* Logs using default logger from ASP.NET Core
* Swagger (Swashbuckle)
* Migration project (Fluent Migrator)
* AutoMapper
* Unit Tests using MSTest + ASP.NET Core 2.1
* Frontend using AngularJS (basic structure)
* All exceptions are logged

### Building and executing

Clone repository:
```sh
git clone https://github.com/victormasutani/DocumentManagement.git
```

Execute script create schema in database (create a new database DocumentManagement):
```sh
DocumentManagement\DocumentManagement.FluentMigrator\create_schema.sql
```

Compile project migration project
```sh
DocumentManagement.FluentMigrator
```

Change database connection script from bat (if necessary)
```sh
DocumentManagement\DocumentManagement.FluentMigrator\bin\Debug\netstandard2.0\migration-up.bat
```

Execute migration
```sh
DocumentManagement\DocumentManagement.FluentMigrator\bin\Debug\netstandard2.0\migration-up.bat
```

If step above doesn't work, execute script to create tables inside DocumentManagement schema
```sh
DocumentManagement\DocumentManagement.FluentMigrator\create_tables.sql
```

Change database connection script from application (if necessary)
```sh
DocumentManagement\DocumentManagement.API\appsettings.json
```

Run projects
```sh
DocumentManagement\DocumentManagement.API
DocumentManagement\DocumentManagement.Web
```

Change API hosting port if necessary (default port running from VS2017 is 44349)
```sh
DocumentManagement\DocumentManagement.Web\wwwroot\app.js
```

### Testing

Unit test API project (from VS 2017 or VSCode)
```sh
DocumentManagement\DocumentManagement.Tests
dotnet test
```
