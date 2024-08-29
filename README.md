# ShipIt Inventory Management

## Setup Instructions
Open the project in VSCode.
VSCode should automatically set up and install everything you'll need apart from the database connection!

### Setting up the Database.
Create 2 new postgres databases - one for the main program and one for our test database.

`createdb -h localhost -p 5432 -U postgres <ShipItDb>`
`createdb -h localhost -p 5432 -U postgres <ShipItDbTest>`
(run this in the CLI in the directory C:/Program Files/PostgreSQL/16/bin)

Ask a team member for a dump of the production databases to create and populate your tables.

Populate both databases running in the directory of your project:
`psql -U postgres -d postgresql://localhost:5432/ShipItDb -f ShipIt-database-dump.sql`
`psql -U postgres -d postgresql://localhost:5432/ShipItDbTest -f ShipIt-database-dump.sql`


Then for each of the projects, add a `.env` file at the root of the project.
That file should contain a property named `POSTGRES_CONNECTION_STRING`.
It should look something like this:
```
POSTGRES_CONNECTION_STRING=Server=127.0.0.1;Port=5432;Database=your_database_name;User Id=your_database_user; Password=your_database_password;
```


Download and install the SDK 3.1.100:
https://dotnet.microsoft.com/en-us/download/dotnet/3.1


## Running The API
Once set up, simply run `dotnet run` in the ShipIt directory.

## Running The Tests
To run the tests you should be able to run `dotnet test` in the ShipItTests directory.

## Deploying to Production

Create indexes for your tables using
`psql <yourDbName> <yourUsername>` (e.g. `psql PostItDb postgres`)
This allows you to write SQL commands in the CLI (always remember the semicolon at the end of each line)
Run `CREATE INDEX idx_YourNewIndex ON <yourTable> (<yourColumn>);`