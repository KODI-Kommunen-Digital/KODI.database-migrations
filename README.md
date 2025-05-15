# Database Migrations

We have created this project to maintain our database system. We create something called as a 'migration' which is any change done to the database which can also be reverted if needed. This helps in version control of our database. We are using fluent migration to 
achieve this which is written in .NET

## Setup
### Installation
First install these softwares in your local
- [MySql 8.0](https://dev.mysql.com/downloads/file/?id=518834) 
- [DotNet 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-7.0.203-windows-x64-installer)

### Create two schemas on local

First we need to create two schemas on our local. Create two schemas with these name
- heidi_core
- heidi_city_0

```sql
CREATE SCHEMA heidi_core;
CREATE SCHEMA heidi_city_0;
```

Then, create a user with these credentials and **give all privilages** (can be done in administrator tab)
- username: devuser
- password: devpassword

```sql
CREATE USER 'devuser'@'localhost' IDENTIFIED BY 'devpassword';
GRANT ALL ON *.* TO 'devuser'@'localhost';
FLUSH PRIVILEGES;
```

### Execute migrations

Then run the migrations on your local machine. 
First clone this project on your local machine. Then, go to  **rootfile/DatabaseMigrations**

## Detailed documentation 

[Document](https://github.com/HEIDI-Heimat-Digital/documentation/wiki)

## Add a new file named "App.config" 

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <connectionStrings>
        <add name="CoreDBConnection" connectionString="server=localhost;user=devuser;password=devpassword;database=heidi_core"/>
        <add name="CityDBZeroConnection" connectionString="server=localhost;user=devuser;password=devpassword;database=heidi_city_0"/>
    </connectionStrings>
</configuration>
```

Run the following commands in command prompt in the current location  **rootfile/DatabaseMigrations**
```bash
dotnet build
dotnet run
```

### Create new database for a city
We then create a clone of the "heidi_city_0" database. Let's call it "heidi_city_1". 
Then, we add a entry into the city table with the connection string of database "heidi_city_1"

```sql
USE heidi_core;
INSERT INTO cities (id, name, connectionString) VALUES (1, "City 1", "server=localhost;user=devuser;password=devpassword;database=heidi_city_1");

```

## Additional Parameters
#### dbType
Run migrations project only on the particular  type ofdatabase
- all (default)
- core
- city

#### migrate
The direction the migrations are run
- up (default)
- down

#### targetVersion
An integer value that needs to be provided if we want to up or down migrate to

Example commands
```bash
dotnet run dbtype=city
dotnet run migrate=up
dotnet run migrate=down dbType=core targetVersion=20250305143733
```
