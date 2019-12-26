# Product Catalog Manager API

It is a RESTful API solution in .NET Core for managing a Product Catalog. Consumers can use the API to add, edit, remove, view and search Products, and export all Product Catalog items.

## Requirements

- Product Code is specified by the API caller and must be unique and can contains only alphanumeric characters. (API validating uniqueness)
- Product prices must be greater than 0 and must be lower than 999. (API validating Price)
- Optionally, a product can have a picture, specified as a URL. (API validating well-formed URLs)
- Project includes automated tests for core API functionality. (Unit tests, integration tests -Xunit-)
- Project should provide API Documentation (Swagger for .NET Core)
- API versioning support
- API performance monitoring with BenchmarkDotNet library.
- Storing the Product data in Sql Server Database in Azure Cloud.
- API does not have any authentication/authorization mechanism.

## Product Model

    *Id* (int/guid – auto generated),
    
    *Code* (string - unique),
    
    *Name* (string - mandatory),
    
    *Picture* (string - optional), //the URL of the picture
    
    *Price* (decimal - mandatory),
    
    *UpdatedAt* (datetime - mandatory),

### Installing

Change Database userId and password in appsettings.json file

You should create database for your application which can store the data from your domain classes. So, firstly, you need to create a migration.

Open the Package Manager Console from the menu Tools -> NuGet Package Manager -> Package Manager Console in Visual Studio and execute the following command to add a migration.

```
add-migration MyFirstMigration
```

Now, after creating a migration snapshot, it's time to create the database. Use the following command to create or update the database schema.

```
Update-Database
```

The Update command will create the database based on the context and domain classes and the migration snapshot, which is created using the add-migration or add command.

If this is the first migration, then it will also create a table called __EFMigrationsHistory, which will store the name of all migrations, as and when they will be applied to the database.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Roadmap
* Authentication/authorization mechanism.
* Caching mechanism for some api requests.
* Detailed Logging mechanism. And if necessary, using NoSql dbfor log data.
* And it is going to be good achievement that storing the Picture datas in a Cloud storage service (e.g. Azure Blob Storage or AWS S3).

